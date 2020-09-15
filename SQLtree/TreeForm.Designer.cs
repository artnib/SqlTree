namespace SQLtree
{
  partial class TreeForm
  {
    /// <summary>
    /// Требуется переменная конструктора.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    /// Освободить все используемые ресурсы.
    /// </summary>
    /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
    protected override void Dispose(bool disposing)
    {
      if (disposing && (components != null))
      {
        components.Dispose();
      }
      base.Dispose(disposing);
    }

    #region Код, автоматически созданный конструктором форм Windows

    /// <summary>
    /// Обязательный метод для поддержки конструктора - не изменяйте
    /// содержимое данного метода при помощи редактора кода.
    /// </summary>
    private void InitializeComponent()
    {
      this.tv = new System.Windows.Forms.TreeView();
      this.menuStrip1 = new System.Windows.Forms.MenuStrip();
      this.mnuAdd = new System.Windows.Forms.ToolStripMenuItem();
      this.mnuAddRoot = new System.Windows.Forms.ToolStripMenuItem();
      this.mnuAddChild = new System.Windows.Forms.ToolStripMenuItem();
      this.mnuEdit = new System.Windows.Forms.ToolStripMenuItem();
      this.mnuDel = new System.Windows.Forms.ToolStripMenuItem();
      this.menuStrip1.SuspendLayout();
      this.SuspendLayout();
      // 
      // tv
      // 
      this.tv.Dock = System.Windows.Forms.DockStyle.Fill;
      this.tv.FullRowSelect = true;
      this.tv.HideSelection = false;
      this.tv.Location = new System.Drawing.Point(0, 24);
      this.tv.Name = "tv";
      this.tv.Size = new System.Drawing.Size(624, 420);
      this.tv.TabIndex = 0;
      // 
      // menuStrip1
      // 
      this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuAdd,
            this.mnuEdit,
            this.mnuDel});
      this.menuStrip1.Location = new System.Drawing.Point(0, 0);
      this.menuStrip1.Name = "menuStrip1";
      this.menuStrip1.Size = new System.Drawing.Size(624, 24);
      this.menuStrip1.TabIndex = 1;
      this.menuStrip1.Text = "menuStrip1";
      this.menuStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.menuStrip1_ItemClicked);
      // 
      // mnuAdd
      // 
      this.mnuAdd.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuAddRoot,
            this.mnuAddChild});
      this.mnuAdd.Name = "mnuAdd";
      this.mnuAdd.Size = new System.Drawing.Size(71, 20);
      this.mnuAdd.Text = "Добавить";
      this.mnuAdd.Click += new System.EventHandler(this.mnuAdd_Click);
      // 
      // mnuAddRoot
      // 
      this.mnuAddRoot.Name = "mnuAddRoot";
      this.mnuAddRoot.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Insert)));
      this.mnuAddRoot.Size = new System.Drawing.Size(217, 22);
      this.mnuAddRoot.Text = "Верхний уровень";
      this.mnuAddRoot.Click += new System.EventHandler(this.mnuAddRoot_Click);
      // 
      // mnuAddChild
      // 
      this.mnuAddChild.Name = "mnuAddChild";
      this.mnuAddChild.ShortcutKeys = System.Windows.Forms.Keys.Insert;
      this.mnuAddChild.Size = new System.Drawing.Size(217, 22);
      this.mnuAddChild.Text = "Дочерний узел";
      this.mnuAddChild.Click += new System.EventHandler(this.mnuAddChild_Click);
      // 
      // mnuEdit
      // 
      this.mnuEdit.Name = "mnuEdit";
      this.mnuEdit.ShortcutKeys = System.Windows.Forms.Keys.F2;
      this.mnuEdit.Size = new System.Drawing.Size(73, 20);
      this.mnuEdit.Text = "Изменить";
      this.mnuEdit.Click += new System.EventHandler(this.mnuEdit_Click);
      // 
      // mnuDel
      // 
      this.mnuDel.Name = "mnuDel";
      this.mnuDel.ShortcutKeys = System.Windows.Forms.Keys.Delete;
      this.mnuDel.Size = new System.Drawing.Size(63, 20);
      this.mnuDel.Text = "Удалить";
      this.mnuDel.Click += new System.EventHandler(this.mnuDel_Click);
      // 
      // TreeForm
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(624, 444);
      this.Controls.Add(this.tv);
      this.Controls.Add(this.menuStrip1);
      this.MainMenuStrip = this.menuStrip1;
      this.Name = "TreeForm";
      this.Text = "Телефонный справочник";
      this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.TreeForm_FormClosed);
      this.Load += new System.EventHandler(this.Form1_Load);
      this.menuStrip1.ResumeLayout(false);
      this.menuStrip1.PerformLayout();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.MenuStrip menuStrip1;
    private System.Windows.Forms.ToolStripMenuItem mnuAdd;
    private System.Windows.Forms.TreeView tv;
    private System.Windows.Forms.ToolStripMenuItem mnuAddRoot;
    private System.Windows.Forms.ToolStripMenuItem mnuAddChild;
    private System.Windows.Forms.ToolStripMenuItem mnuEdit;
    private System.Windows.Forms.ToolStripMenuItem mnuDel;
  }
}

