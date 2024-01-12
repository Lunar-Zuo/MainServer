namespace MainServer.Forms
{
    partial class FormLogin
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.lblInfor = new System.Windows.Forms.Label();
            this.chekboxShowPassWord = new System.Windows.Forms.CheckBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtPassWord = new System.Windows.Forms.TextBox();
            this.AddUser = new System.Windows.Forms.Label();
            this.cmbUser = new System.Windows.Forms.TextBox();
            this.PasswordChange = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblInfor
            // 
            this.lblInfor.AutoSize = true;
            this.lblInfor.Location = new System.Drawing.Point(108, 176);
            this.lblInfor.Name = "lblInfor";
            this.lblInfor.Size = new System.Drawing.Size(29, 12);
            this.lblInfor.TabIndex = 15;
            this.lblInfor.Text = "信息";
            // 
            // chekboxShowPassWord
            // 
            this.chekboxShowPassWord.AutoSize = true;
            this.chekboxShowPassWord.Font = new System.Drawing.Font("微软雅黑", 7.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.chekboxShowPassWord.Location = new System.Drawing.Point(143, 142);
            this.chekboxShowPassWord.Name = "chekboxShowPassWord";
            this.chekboxShowPassWord.Size = new System.Drawing.Size(67, 20);
            this.chekboxShowPassWord.TabIndex = 13;
            this.chekboxShowPassWord.Text = "显示密码";
            this.chekboxShowPassWord.UseVisualStyleBackColor = true;
            this.chekboxShowPassWord.CheckedChanged += new System.EventHandler(this.chekboxShowPassWord_CheckedChanged);
            // 
            // btnCancel
            // 
            this.btnCancel.FlatAppearance.BorderSize = 2;
            this.btnCancel.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Lime;
            this.btnCancel.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DarkSeaGreen;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Location = new System.Drawing.Point(269, 228);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(105, 43);
            this.btnCancel.TabIndex = 11;
            this.btnCancel.Text = "返回";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOK
            // 
            this.btnOK.FlatAppearance.BorderSize = 2;
            this.btnOK.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Lime;
            this.btnOK.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DarkSeaGreen;
            this.btnOK.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOK.Location = new System.Drawing.Point(141, 228);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(105, 43);
            this.btnOK.TabIndex = 12;
            this.btnOK.Text = "确定";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(68, 105);
            this.label2.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 12);
            this.label2.TabIndex = 9;
            this.label2.Text = "用户密码:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(74, 42);
            this.label1.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 12);
            this.label1.TabIndex = 10;
            this.label1.Text = "用户名:";
            // 
            // txtPassWord
            // 
            this.txtPassWord.ForeColor = System.Drawing.Color.DarkBlue;
            this.txtPassWord.Location = new System.Drawing.Point(142, 100);
            this.txtPassWord.Margin = new System.Windows.Forms.Padding(6);
            this.txtPassWord.Name = "txtPassWord";
            this.txtPassWord.Size = new System.Drawing.Size(182, 22);
            this.txtPassWord.TabIndex = 8;
            this.txtPassWord.UseSystemPasswordChar = true;
            // 
            // AddUser
            // 
            this.AddUser.AutoSize = true;
            this.AddUser.Font = new System.Drawing.Font("新細明體", 9.75F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.AddUser.Location = new System.Drawing.Point(341, 307);
            this.AddUser.Name = "AddUser";
            this.AddUser.Size = new System.Drawing.Size(33, 13);
            this.AddUser.TabIndex = 16;
            this.AddUser.Text = "注册";
            this.AddUser.Click += new System.EventHandler(this.AddUser_Click);
            // 
            // cmbUser
            // 
            this.cmbUser.ForeColor = System.Drawing.Color.DarkBlue;
            this.cmbUser.Location = new System.Drawing.Point(142, 39);
            this.cmbUser.Margin = new System.Windows.Forms.Padding(6);
            this.cmbUser.Name = "cmbUser";
            this.cmbUser.Size = new System.Drawing.Size(182, 22);
            this.cmbUser.TabIndex = 17;
            this.cmbUser.UseSystemPasswordChar = true;
            // 
            // PasswordChange
            // 
            this.PasswordChange.AutoSize = true;
            this.PasswordChange.Font = new System.Drawing.Font("新細明體", 9.75F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.PasswordChange.Location = new System.Drawing.Point(266, 307);
            this.PasswordChange.Name = "PasswordChange";
            this.PasswordChange.Size = new System.Drawing.Size(59, 13);
            this.PasswordChange.TabIndex = 18;
            this.PasswordChange.Text = "忘记密码";
            this.PasswordChange.Click += new System.EventHandler(this.PasswordChange_Click);
            // 
            // FormLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.ClientSize = new System.Drawing.Size(397, 329);
            this.Controls.Add(this.PasswordChange);
            this.Controls.Add(this.cmbUser);
            this.Controls.Add(this.AddUser);
            this.Controls.Add(this.lblInfor);
            this.Controls.Add(this.chekboxShowPassWord);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtPassWord);
            this.KeyPreview = true;
            this.MinimizeBox = false;
            this.Name = "FormLogin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Login";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.Form1_Load);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.FrmLogin_KeyPress);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblInfor;
        private System.Windows.Forms.CheckBox chekboxShowPassWord;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtPassWord;
        private System.Windows.Forms.Label AddUser;
        private System.Windows.Forms.TextBox cmbUser;
        private System.Windows.Forms.Label PasswordChange;
    }
}

