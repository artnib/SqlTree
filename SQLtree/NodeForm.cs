using System;
using System.Windows.Forms;

namespace SQLtree
{
  public partial class NodeForm : Form
  {
    public NodeForm()
    {
      InitializeComponent();
    }

    /// <summary>
    /// Имя абонента
    /// </summary>
    public string NodeName
    {
      get { return tbName.Text; }
      set { tbName.Text = value; }
    }

    /// <summary>
    /// Номер абонента
    /// </summary>
    public UInt16 Phone
    {
      get { return UInt16.Parse(tbPhone.Text); }
      set { tbPhone.Text = value.ToString(); }
    }

    /// <summary>
    /// Очищает текстовые поля
    /// </summary>
    public void Clear()
    {
      tbName.Clear();
      tbPhone.Clear();
    }

    bool CorrectPhone(string phone)
    {
      UInt16 num;
      const UInt16 min = 100;
      const UInt16 max = 999;
      if (UInt16.TryParse(tbPhone.Text, out num))
      {
        return num >= min && num <= max;
      }
      else
        return false;
    }

    void CheckFields()
    {
      btnSave.Enabled = tbName.Text.Trim().Length > 0 &&
        CorrectPhone(tbPhone.Text);
    }

    private void textBox2_TextChanged(object sender, EventArgs e)
    {
      CheckFields();
    }

    private void tbName_TextChanged(object sender, EventArgs e)
    {
      CheckFields();
    }
  }
}