namespace MsSqlServer
{
  partial class ConnectForm
  {
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    /// Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
      if (disposing && (components != null))
      {
        components.Dispose();
      }
      base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
      this.components = new System.ComponentModel.Container();
      this.label1 = new System.Windows.Forms.Label();
      this.btnConnect = new System.Windows.Forms.Button();
      this.label4 = new System.Windows.Forms.Label();
      this.rbWindows = new System.Windows.Forms.RadioButton();
      this.rbMSSQL = new System.Windows.Forms.RadioButton();
      this.groupBox1 = new System.Windows.Forms.GroupBox();
      this.lbWinUser = new System.Windows.Forms.Label();
      this.tbPassword = new System.Windows.Forms.TextBox();
      this.label6 = new System.Windows.Forms.Label();
      this.label5 = new System.Windows.Forms.Label();
      this.tbLogin = new System.Windows.Forms.TextBox();
      this.cboServers = new System.Windows.Forms.ComboBox();
      this.statusStrip1 = new System.Windows.Forms.StatusStrip();
      this.Status = new System.Windows.Forms.ToolStripStatusLabel();
      this.cboDatabase = new System.Windows.Forms.ComboBox();
      this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
      this.groupBox1.SuspendLayout();
      this.statusStrip1.SuspendLayout();
      this.SuspendLayout();
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Location = new System.Drawing.Point(12, 9);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(190, 13);
      this.label1.TabIndex = 1;
      this.label1.Text = "Выберите или введите имя сервера";
      // 
      // btnConnect
      // 
      this.btnConnect.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
      this.btnConnect.Enabled = false;
      this.btnConnect.Location = new System.Drawing.Point(8, 209);
      this.btnConnect.Name = "btnConnect";
      this.btnConnect.Size = new System.Drawing.Size(243, 23);
      this.btnConnect.TabIndex = 2;
      this.btnConnect.Text = "Подключиться";
      this.btnConnect.UseVisualStyleBackColor = true;
      this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
      // 
      // label4
      // 
      this.label4.AutoSize = true;
      this.label4.Location = new System.Drawing.Point(5, 236);
      this.label4.Name = "label4";
      this.label4.Size = new System.Drawing.Size(239, 13);
      this.label4.TabIndex = 9;
      this.label4.Text = "Выберите или введите имя базы данных (БД)";
      // 
      // rbWindows
      // 
      this.rbWindows.AutoSize = true;
      this.rbWindows.Checked = true;
      this.rbWindows.Location = new System.Drawing.Point(6, 26);
      this.rbWindows.Name = "rbWindows";
      this.rbWindows.Size = new System.Drawing.Size(194, 17);
      this.rbWindows.TabIndex = 1;
      this.rbWindows.TabStop = true;
      this.rbWindows.Text = "текущего пользователя Windows";
      this.rbWindows.UseVisualStyleBackColor = true;
      // 
      // rbMSSQL
      // 
      this.rbMSSQL.AutoSize = true;
      this.rbMSSQL.Location = new System.Drawing.Point(6, 62);
      this.rbMSSQL.Name = "rbMSSQL";
      this.rbMSSQL.Size = new System.Drawing.Size(173, 17);
      this.rbMSSQL.TabIndex = 2;
      this.rbMSSQL.Text = "пользователя MS SQL Server";
      this.rbMSSQL.UseVisualStyleBackColor = true;
      // 
      // groupBox1
      // 
      this.groupBox1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
      this.groupBox1.Controls.Add(this.lbWinUser);
      this.groupBox1.Controls.Add(this.tbPassword);
      this.groupBox1.Controls.Add(this.label6);
      this.groupBox1.Controls.Add(this.label5);
      this.groupBox1.Controls.Add(this.tbLogin);
      this.groupBox1.Controls.Add(this.rbMSSQL);
      this.groupBox1.Controls.Add(this.rbWindows);
      this.groupBox1.Location = new System.Drawing.Point(12, 52);
      this.groupBox1.Name = "groupBox1";
      this.groupBox1.Size = new System.Drawing.Size(239, 151);
      this.groupBox1.TabIndex = 1;
      this.groupBox1.TabStop = false;
      this.groupBox1.Text = "Подключаться от имени";
      // 
      // lbWinUser
      // 
      this.lbWinUser.AutoSize = true;
      this.lbWinUser.Location = new System.Drawing.Point(34, 46);
      this.lbWinUser.Name = "lbWinUser";
      this.lbWinUser.Size = new System.Drawing.Size(101, 13);
      this.lbWinUser.TabIndex = 21;
      this.lbWinUser.Text = "WindowsUserName";
      // 
      // tbPassword
      // 
      this.tbPassword.Location = new System.Drawing.Point(75, 115);
      this.tbPassword.Name = "tbPassword";
      this.tbPassword.Size = new System.Drawing.Size(125, 20);
      this.tbPassword.TabIndex = 4;
      this.tbPassword.UseSystemPasswordChar = true;
      // 
      // label6
      // 
      this.label6.AutoSize = true;
      this.label6.Location = new System.Drawing.Point(24, 119);
      this.label6.Name = "label6";
      this.label6.Size = new System.Drawing.Size(45, 13);
      this.label6.TabIndex = 13;
      this.label6.Text = "Пароль";
      // 
      // label5
      // 
      this.label5.AutoSize = true;
      this.label5.Location = new System.Drawing.Point(24, 88);
      this.label5.Name = "label5";
      this.label5.Size = new System.Drawing.Size(29, 13);
      this.label5.TabIndex = 13;
      this.label5.Text = "Имя";
      // 
      // tbLogin
      // 
      this.tbLogin.Location = new System.Drawing.Point(75, 85);
      this.tbLogin.Name = "tbLogin";
      this.tbLogin.Size = new System.Drawing.Size(125, 20);
      this.tbLogin.TabIndex = 3;
      // 
      // cboServers
      // 
      this.cboServers.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
      this.cboServers.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
      this.cboServers.FormattingEnabled = true;
      this.cboServers.Location = new System.Drawing.Point(10, 24);
      this.cboServers.Name = "cboServers";
      this.cboServers.Size = new System.Drawing.Size(241, 21);
      this.cboServers.TabIndex = 0;
      this.cboServers.TextChanged += new System.EventHandler(this.cboServers_TextChanged);
      // 
      // statusStrip1
      // 
      this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Status});
      this.statusStrip1.Location = new System.Drawing.Point(0, 279);
      this.statusStrip1.Name = "statusStrip1";
      this.statusStrip1.Size = new System.Drawing.Size(304, 22);
      this.statusStrip1.SizingGrip = false;
      this.statusStrip1.TabIndex = 15;
      // 
      // Status
      // 
      this.Status.Name = "Status";
      this.Status.Size = new System.Drawing.Size(0, 17);
      // 
      // cboDatabase
      // 
      this.cboDatabase.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
      this.cboDatabase.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
      this.cboDatabase.FormattingEnabled = true;
      this.cboDatabase.Location = new System.Drawing.Point(8, 252);
      this.cboDatabase.Name = "cboDatabase";
      this.cboDatabase.Size = new System.Drawing.Size(243, 21);
      this.cboDatabase.TabIndex = 16;
      this.cboDatabase.TextChanged += new System.EventHandler(this.cboDatabase_TextChanged);
      // 
      // ConnectForm
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(304, 301);
      this.Controls.Add(this.cboDatabase);
      this.Controls.Add(this.statusStrip1);
      this.Controls.Add(this.cboServers);
      this.Controls.Add(this.groupBox1);
      this.Controls.Add(this.label4);
      this.Controls.Add(this.btnConnect);
      this.Controls.Add(this.label1);
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
      this.MaximizeBox = false;
      this.Name = "ConnectForm";
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
      this.Text = "Подключение к MS SQL Server";
      this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
      this.Load += new System.EventHandler(this.Form1_Load);
      this.groupBox1.ResumeLayout(false);
      this.groupBox1.PerformLayout();
      this.statusStrip1.ResumeLayout(false);
      this.statusStrip1.PerformLayout();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.Button btnConnect;
    private System.Windows.Forms.Label label4;
    private System.Windows.Forms.RadioButton rbWindows;
    private System.Windows.Forms.RadioButton rbMSSQL;
    private System.Windows.Forms.GroupBox groupBox1;
    private System.Windows.Forms.TextBox tbPassword;
    private System.Windows.Forms.Label label6;
    private System.Windows.Forms.Label label5;
    private System.Windows.Forms.TextBox tbLogin;
    private System.Windows.Forms.ComboBox cboServers;
    private System.Windows.Forms.StatusStrip statusStrip1;
    private System.Windows.Forms.ToolStripStatusLabel Status;
    private System.Windows.Forms.ComboBox cboDatabase;
    private System.Windows.Forms.ToolTip toolTip1;
    private System.Windows.Forms.Label lbWinUser;
    //private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
  }
}

