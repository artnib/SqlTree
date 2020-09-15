using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Diagnostics;

namespace MsSqlServer
{
  /// <summary>
  /// Класс для работы с архивом выгрузки на базе MS SQL Server 2000/2005/2008
  /// </summary>
  class MSSQLhelper
  {
    SqlConnection SqlCon;
    internal SqlConnection Connection
    {
      get { return SqlCon; }
    }

    string ErrMsg="";
    string server = "";
    string database = "";
    string login = "";
    string password = "";
    bool WindowsAuth;
    List<string> DbList = null;
    
    #region Public properties

    /// <summary>
    /// Имя сервера
    /// </summary>
    public string Server
    {
      get { return server; }
      set 
      {
        if (String.Compare(server, value, true)!=0)
        {
          server = value;
          DbList = null;
        }
      }
    }

    /// <summary>
    /// База данных
    /// </summary>
    public string Database
    {
      set { database = value; }
    }

    /// <summary>
    /// Признак использования аутентификации Windows
    /// </summary>
    public bool WindowsAuthentication
    {
      set { WindowsAuth = value; }
    }

    /// <summary>
    /// Имя пользователя
    /// </summary>
    public string Login
    {
      set { login = value; }
    }

    /// <summary>
    /// Пароль пользователя
    /// </summary>
    public string Password
    {
      set { password = value; }
    }

    /// <summary>
    /// Сообщение об ошибке
    /// </summary>
    public string ErrorMessage
    {
      get { return ErrMsg; }
    }

    #endregion
    
    #region Public methods

    /// <summary>
    /// Подключение к серверу
    /// </summary>
    /// <param name="Server">Имя сервера</param>
    /// <param name="Database">База данных</param>
    /// <returns>true при успешном подключении</returns>
    public bool Connect(string Server, string Database)
    {
      ErrMsg = "";
      WindowsAuth = true;
      this.Server = Server;
      database = Database;
      SqlConnectionStringBuilder csb = new SqlConnectionStringBuilder();
      csb.DataSource = Server;
      csb.IntegratedSecurity = true;
      csb.InitialCatalog = database;
      SqlCon = new SqlConnection(csb.ConnectionString);
      try
      {
        SqlCon.Open();
      }
      catch(SqlException se)
      {
        ErrMsg = se.Message;
        return false;
      }
      return true;
    }

    /// <summary>
    /// Подключение к серверу
    /// </summary>
    /// <param name="Server">Имя сервера</param>
    /// <param name="Login">Имя пользователя</param>
    /// <param name="Password">Пароль</param>
    /// <param name="Database">База данных</param>
    /// <returns>true при успешном подключении</returns>
    public bool Connect(string Server, string Login, string Password, string Database)
    {
      ErrMsg = "";
      WindowsAuth = false;
      this.Server = Server;
      login = Login;
      password = Password;
      database = Database;
      SqlConnectionStringBuilder csb = new SqlConnectionStringBuilder();
      csb.DataSource = Server;
      csb.IntegratedSecurity = false;
      csb.UserID = Login;
      csb.Password = Password;
      csb.InitialCatalog = database;
      SqlCon = new SqlConnection(csb.ConnectionString);
      try
      {
        SqlCon.Open();
      }
      catch (SqlException se)
      {
        ErrMsg = se.Message;
        return false;
      }
      return true;
    }
    
    /// <summary>
    /// Отключение
    /// </summary>
    public void Disconnect()
    {
      if(SqlCon.State == ConnectionState.Open)
        SqlCon.Close();
    }
    
    /// <summary>
    /// Получение списка серверов
    /// </summary>
    /// <returns>Список серверов</returns>
    public string[] VisibleServers()
    { 
      List<string> result =new List<string>();
      SqlDataSourceEnumerator dse=SqlDataSourceEnumerator.Instance;
      DataTable dt=dse.GetDataSources();
      string ServerName, server, instance;

      foreach(DataRow row in dt.Rows)
      {
        server = row["ServerName"].ToString();
        instance = row["InstanceName"].ToString();
        if (instance.Length == 0)
          ServerName = server;
        else
          ServerName = server + "\\" + instance;
        result.Add(ServerName);
      }
      return result.ToArray();
    }

    public string[] Tables()
    {
      CheckConnection();
      SqlCon.ChangeDatabase(database);
      DataTable tables = SqlCon.GetSchema("Tables");
      List<string> TableList=new List<string>();
      foreach(DataRow dr in tables.Rows)
      {
        TableList.Add(dr["table_name"].ToString());
      }
      return TableList.ToArray();
    }

    /// <summary>
    /// Получение списка баз данных
    /// </summary>
    /// <returns>Список баз данных</returns>
    public string[] DatabaseList()
    { 
      //способ, работающий для MS SQL Server 2000, 2005, 2008
      //1) получать данные напрямую из системной таблицы нежелательно.
      //Хорошо бы использовать системные процедуры (sp_helpdb),
      //views или SQL-DMO/SMO
      //2) желательно исключать из списка системные базы данных
      ErrMsg = "";
      string DbName = "";
      string strSQL="SELECT name FROM master..sysdatabases ORDER BY name";
      if (DbList == null)
      {
        DbList = new List<string>();
        SqlCommand cmd = new SqlCommand(strSQL, SqlCon);
        try
        {
          SqlDataReader reader = cmd.ExecuteReader();
          while (reader.Read())
          {
            DbName = reader.GetString(0);
            DbList.Add(DbName);
          }
          reader.Close();
        }
        catch (Exception ex)
        {
          Trace.TraceError(ex.Message);
          ErrMsg = ex.Message;
        }
      }
      return DbList.ToArray();
    }

    /// <summary>
    /// Проверка существования базы данных
    /// </summary>
    /// <param name="Name">Имя базы данных</param>
    /// <returns>true, если база данных существует</returns>
    public bool DatabaseExists(string Name)
    {
      CheckConnection();
      if (DbList == null)
        DatabaseList();
      foreach (string DbName in DbList)
        if (String.Compare(DbName, Name, true) == 0)
          return true;
      return false;
    }

    #endregion

    #region Private methods
    
    void Connect()
    {
      if (WindowsAuth)
        Connect(server, database);
      else
        Connect(server, login, password, database);
    }

    /// <summary>
    /// Проверка подключения
    /// </summary>
    private void CheckConnection()
    {
      if (SqlCon == null)
        Connect();
      if (SqlCon.State == ConnectionState.Closed)
        SqlCon.Open();
    }
    
    #endregion
  }
}