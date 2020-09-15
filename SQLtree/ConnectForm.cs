using System;
using System.Windows.Forms;
using SQLtree;
using SQLtree.Properties;

namespace MsSqlServer
{
  public partial class ConnectForm : Form
  {
    public ConnectForm()
    {
      InitializeComponent();
    }

    /// <summary>
    /// Подключение к MS SQL Server
    /// </summary>
    public System.Data.SqlClient.SqlConnection Connection
    {
      get { return mssql.Connection; }
    }

    MSSQLhelper mssql = new MSSQLhelper();
    
    #region Поля для хранения настроек
    string OldServer = "";
    string OldDatabase = "";
    string OldLogin = "";
    string OldPassword = "";
    bool WindowsAuth;
    #endregion

    bool UnsavedChanges = false; //признак наличия несохраненных изменений
    bool FormLoaded = false;
    const string ServerName = "ServerName";
    /// <summary>
    /// Имя текущего пользователя Windows
    /// </summary>
    string CurrentUser;
    
    /// <summary>
    /// Краткое сообщение об ошибке
    /// </summary>
    string ErrMsg = "";

    /// <summary>
    /// Подробное сообщение об ошибке
    /// </summary>
    string DetailedError="";

    string StatusMsg;

    bool OptionsChanged()
    {
      bool LoginChanged = false;
      bool PasswordChanged = false;
      bool ServerChanged = String.Compare(cboServers.Text, OldServer, true) != 0;
      bool DatabaseChanged = String.Compare(cboDatabase.Text, OldDatabase, true) != 0;
      bool AuthChanged = WindowsAuth != rbWindows.Checked;
      if (rbMSSQL.Checked)
      {
        LoginChanged = String.Compare(tbLogin.Text, OldLogin, true) != 0;
        PasswordChanged = String.Compare(tbPassword.Text, OldPassword, false) != 0;
      }
      return ServerChanged || DatabaseChanged || AuthChanged || LoginChanged || PasswordChanged;
    }

    void RefreshServerList()
    {
      Status.Text = "Получение списка серверов...";
      statusStrip1.Update();
      cboServers.Items.Clear();
      cboServers.Items.AddRange(mssql.VisibleServers());
      Status.Text = "Обновлен список серверов";
    }

    private void RefreshDatabaseList()
    {
      Status.Text = "Получение списка баз данных...";
      statusStrip1.Update();
      cboDatabase.Items.Clear();
      cboDatabase.Items.AddRange(mssql.DatabaseList());
      Status.Text = "Обновлен список баз данных";
    }

    /// <summary>
    /// Проверка возможности подключения
    /// </summary>
    void CheckConnectionAbility()
    {
      if (rbMSSQL.Checked)
      {
        btnConnect.Enabled = (cboServers.Text.Length > 0) &&
          (tbLogin.Text.Length > 0);
      }
      if(rbWindows.Checked)
        btnConnect.Enabled = cboServers.Text.Length > 0;
    }

    void AppIdle(Object sender, EventArgs e)
    {
      CheckConnectionAbility();
      UnsavedChanges = OptionsChanged();
      tbLogin.Enabled = rbMSSQL.Checked;
      tbPassword.Enabled = rbMSSQL.Checked;
    }

    private void btnConnect_Click(object sender, EventArgs e)
    {
      Status.Text = "Подключение к серверу...";
      statusStrip1.Update();
      if (rbMSSQL.Checked)
        mssql.Connect(cboServers.Text, tbLogin.Text, tbPassword.Text, cboDatabase.Text);
      else
        mssql.Connect(cboServers.Text, cboDatabase.Text);
      if (mssql.ErrorMessage.Length > 0)
      {
        Status.Text = "Не удалось подключиться к серверу";
        MessageBox.Show("Не удалось подключиться к серверу. Сведения об ошибке:\n\n" +
          mssql.ErrorMessage, "Ошибка подключения", MessageBoxButtons.OK,
          MessageBoxIcon.Exclamation);
      }
      else
      {
        Status.Text = "Выполнено подключение к серверу";
        DialogResult = DialogResult.OK;
        Settings.Default["ServerName"] = cboServers.Text;
        Settings.Default.Save();
        //RefreshDatabaseList();
      }
      //mssql.Disconnect();
    }

    private void RefreshTableList()
    {
    }

    private void Form1_FormClosed(object sender, FormClosedEventArgs e)
    {

    }

    private void Form1_Load(object sender, EventArgs e)
    {
      Application.Idle += AppIdle;
      CurrentUser = GetCurrentUserName();
      lbWinUser.Text = "(" + CurrentUser + ")";
      cboDatabase.Text = Database.Name;
      cboServers.Text = Settings.Default[ServerName].ToString();
      FormLoaded = true;
    }

    private void cboServers_TextChanged(object sender, EventArgs e)
    {
    }

    private void RefreshServers_Click(object sender, EventArgs e)
    {
      RefreshServerList();
    }

    private void btnSave_Click(object sender, EventArgs e)
    {

     }

    private void cboDatabase_TextChanged(object sender, EventArgs e)
    {
      if (!FormLoaded)
      {
        return;
      }
    }

    /// <summary>
    /// Возвращает имя текущего пользователя Windows
    /// </summary>
    /// <returns></returns>
    static string GetCurrentUserName()
    {
      var wi = System.Security.Principal.WindowsIdentity.GetCurrent();
      return wi.Name;
    }
   }
}