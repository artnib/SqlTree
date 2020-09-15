using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using MsSqlServer;

namespace SQLtree
{
  public partial class TreeForm : Form
  {
    public TreeForm()
    {
      InitializeComponent();
      nf = new NodeForm();
      parents = new List<Int16>();
      sep = new string[] { delim };
     }

    private void mnuAdd_Click(object sender, EventArgs e)
    {
      
    }

    SqlConnection connection;
    NodeForm nf;
    SqlCommand command;
    List<Int16> parents;
    string[] sep;
    const string delim = " : ";
    SqlCommand EditProc;
    SqlCommand DelProc;
    List<TreeNode> children;

    void CheckEditProc()
    {
      if (EditProc == null)
      {
        EditProc = connection.CreateCommand();
        EditProc.CommandText = Database.EditNode;
        EditProc.CommandType = CommandType.StoredProcedure;
        EditProc.Parameters.Add(ProcParam.Name, SqlDbType.NChar, 100);
        EditProc.Parameters.Add(ProcParam.OldPhone, SqlDbType.SmallInt);
        EditProc.Parameters.Add(ProcParam.NewPhone, SqlDbType.SmallInt);
      }
    }

    void CheckDelProc()
    {
      if (DelProc == null)
      {
        DelProc = connection.CreateCommand();
        DelProc.CommandText = Database.DelNode;
        DelProc.CommandType = CommandType.StoredProcedure;
        DelProc.Parameters.Add(ProcParam.Phone, SqlDbType.SmallInt);
      }
    }

    string NodeText(object Phone, object Name)
    {
      return String.Format("{0}{2}{1}", Phone, Name, delim);
    }

    private void Form1_Load(object sender, EventArgs e)
    {
      var cf = new ConnectForm();
      var dr = cf.ShowDialog();
      if (dr != DialogResult.OK)
        Application.Exit();
      connection = cf.Connection;
      tv.BeginUpdate();
      var command = connection.CreateCommand();
      command.CommandText = Database.GetRootNodes;
      command.CommandType = CommandType.StoredProcedure;
      using (var reader = command.ExecuteReader())
      {
        while (reader.Read())
        {
          tv.Nodes.Add(reader[0].ToString(),
            NodeText(reader[0], reader[1]));
          parents.Add((Int16)reader[0]);
        }
      }
      command.CommandText = Database.GetChildNodes;
      command.Parameters.Add(ProcParam.Parent, SqlDbType.SmallInt);
      TreeNode[] tn;
      while (parents.Count > 0)
      {
        command.Parameters[0].Value = parents[0];
        tn = tv.Nodes.Find(parents[0].ToString(), true);
        if (tn.Length > 0)
        {
          using (var reader = command.ExecuteReader())
          {
            while (reader.Read())
            {
              tn[0].Nodes.Add(reader[0].ToString(),
                NodeText(reader[0], reader[1]));
              parents.Add(reader.GetInt16(0));
            }
          }
          parents.RemoveAt(0);
        }
      }
      tv.EndUpdate();
    }

    private void TreeForm_FormClosed(object sender, FormClosedEventArgs e)
    {
      if (connection != null)
        connection.Close();
    }

    private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
    {

    }

    void AddNode(TreeNode ParentNode)
    {
      nf.Clear();
      var result = nf.ShowDialog();
      if (result == DialogResult.OK)
      {
        command = connection.CreateCommand();
        command.CommandText = Database.AddNode;
        command.CommandType = CommandType.StoredProcedure;
        command.Parameters.Add(ProcParam.Phone, SqlDbType.SmallInt).Value =
          nf.Phone;
        command.Parameters.Add(ProcParam.Name, SqlDbType.NChar, 100).Value =
          nf.NodeName;
        if (ParentNode != null)
        {
          command.Parameters.Add(ProcParam.Parent, SqlDbType.SmallInt).Value =
            UInt16.Parse(ParentNode.Name);
        }
        if (command.ExecuteNonQuery() > 0)
        {
          var tn = new TreeNode();
          tn.Name = nf.Phone.ToString();
          tn.Text = NodeText(nf.Phone, nf.NodeName);
          if (ParentNode == null)
            tv.Nodes.Add(tn);
          else
            ParentNode.Nodes.Add(tn);
          tv.SelectedNode = tn;
        }
      }
    }

    void EditNode(TreeNode Node)
    {
      var parts = Node.Text.Split(sep, StringSplitOptions.None);
      var OldPhone = UInt16.Parse(parts[0]);
      nf.Phone = OldPhone;
      nf.NodeName = parts[1].Trim();
      var result = nf.ShowDialog();
      if (result == DialogResult.OK)
      {
        CheckEditProc();
        EditProc.Parameters[ProcParam.Name].Value = nf.NodeName;
        EditProc.Parameters[ProcParam.NewPhone].Value = nf.Phone;
        EditProc.Parameters[ProcParam.OldPhone].Value = OldPhone;
        if (EditProc.ExecuteNonQuery() > 0)
        {
          Node.Name = nf.Phone.ToString();
          Node.Text = NodeText(nf.Phone, nf.NodeName);
        }
      }
    }

    void FindChildren(TreeNode Node, List<TreeNode> children)
    {
      foreach (TreeNode tn in Node.Nodes)
      {
        children.Add(tn);
        FindChildren(tn, children);
      }
    }

    private void mnuAddRoot_Click(object sender, EventArgs e)
    {
      AddNode(null);
    }

    private void mnuAddChild_Click(object sender, EventArgs e)
    {
      AddNode(tv.SelectedNode);
    }

    private void mnuEdit_Click(object sender, EventArgs e)
    {
      var tn = tv.SelectedNode;
      if (tn == null)
        return;
      EditNode(tn);
    }

    private void mnuDel_Click(object sender, EventArgs e)
    {
      var tn = tv.SelectedNode;
      if (tn == null)
        return;
      children = new List<TreeNode>();
      FindChildren(tn, children);
      var ncount = children.Count;
      if (ncount > 0)
      {
        if (MessageBox.Show(
          String.Format("Удалить вместе с дочерними узлами ({0} шт.)?", ncount),
          Text, MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != DialogResult.Yes)
          return;
      }
      CheckDelProc();
      children.Add(tn); //выделенный родительский узел тоже надо удалить
      var trans = connection.BeginTransaction();
      DelProc.Transaction = trans;
      try
      {
        foreach (TreeNode n in children)
        {
          DelProc.Parameters[ProcParam.Phone].Value = UInt16.Parse(n.Name);
          DelProc.ExecuteNonQuery();
        }
        trans.Commit();
        foreach (TreeNode n in children)
          n.Remove();
      }
      catch (SqlException se)
      {
        trans.Rollback();
        MessageBox.Show(se.Message, "Ошибка удаления", MessageBoxButtons.OK, 
          MessageBoxIcon.Error);
      }
    }
  }
}