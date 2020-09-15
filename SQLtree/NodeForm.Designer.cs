namespace SQLtree
{
  partial class NodeForm
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
      this.label1 = new System.Windows.Forms.Label();
      this.tbName = new System.Windows.Forms.TextBox();
      this.label2 = new System.Windows.Forms.Label();
      this.btnSave = new System.Windows.Forms.Button();
      this.button2 = new System.Windows.Forms.Button();
      this.tbPhone = new System.Windows.Forms.TextBox();
      this.SuspendLayout();
      // 
      // label1
      // 
      this.label1.Location = new System.Drawing.Point(12, 50);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(92, 33);
      this.label1.TabIndex = 0;
      this.label1.Text = "Подразделение, сотрудник";
      // 
      // tbName
      // 
      this.tbName.Location = new System.Drawing.Point(119, 56);
      this.tbName.MaxLength = 100;
      this.tbName.Name = "tbName";
      this.tbName.Size = new System.Drawing.Size(422, 20);
      this.tbName.TabIndex = 2;
      this.tbName.TextChanged += new System.EventHandler(this.tbName_TextChanged);
      // 
      // label2
      // 
      this.label2.Location = new System.Drawing.Point(12, 9);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(103, 33);
      this.label2.TabIndex = 2;
      this.label2.Text = "Внутренний номер (100...999)";
      // 
      // btnSave
      // 
      this.btnSave.DialogResult = System.Windows.Forms.DialogResult.OK;
      this.btnSave.Location = new System.Drawing.Point(385, 99);
      this.btnSave.Name = "btnSave";
      this.btnSave.Size = new System.Drawing.Size(75, 23);
      this.btnSave.TabIndex = 3;
      this.btnSave.Text = "Сохранить";
      this.btnSave.UseVisualStyleBackColor = true;
      // 
      // button2
      // 
      this.button2.DialogResult = System.Windows.Forms.DialogResult.Cancel;
      this.button2.Location = new System.Drawing.Point(466, 99);
      this.button2.Name = "button2";
      this.button2.Size = new System.Drawing.Size(75, 23);
      this.button2.TabIndex = 4;
      this.button2.Text = "Отмена";
      this.button2.UseVisualStyleBackColor = true;
      // 
      // tbPhone
      // 
      this.tbPhone.Location = new System.Drawing.Point(121, 15);
      this.tbPhone.MaxLength = 3;
      this.tbPhone.Name = "tbPhone";
      this.tbPhone.Size = new System.Drawing.Size(29, 20);
      this.tbPhone.TabIndex = 1;
      this.tbPhone.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
      // 
      // NodeForm
      // 
      this.AcceptButton = this.btnSave;
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.CancelButton = this.button2;
      this.ClientSize = new System.Drawing.Size(548, 130);
      this.Controls.Add(this.tbPhone);
      this.Controls.Add(this.button2);
      this.Controls.Add(this.btnSave);
      this.Controls.Add(this.label2);
      this.Controls.Add(this.tbName);
      this.Controls.Add(this.label1);
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
      this.MaximizeBox = false;
      this.Name = "NodeForm";
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
      this.Text = "Абонент АТС";
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.TextBox tbName;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.Button btnSave;
    private System.Windows.Forms.Button button2;
    private System.Windows.Forms.TextBox tbPhone;
  }
}