namespace MainServer.Forms
{
    partial class FormEdit
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
            this.lblInfor = new System.Windows.Forms.Label();
            this.chekboxShowPassWord = new System.Windows.Forms.CheckBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.lblConfirmPassWord = new System.Windows.Forms.Label();
            this.lblPassWord = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtConfirmPassWord = new System.Windows.Forms.TextBox();
            this.txtPassWord = new System.Windows.Forms.TextBox();
            this.cmbUser = new System.Windows.Forms.ComboBox();
            this.txtUser = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // lblInfor
            // 
            this.lblInfor.AutoSize = true;
            this.lblInfor.ForeColor = System.Drawing.Color.DarkGreen;
            this.lblInfor.Location = new System.Drawing.Point(90, 215);
            this.lblInfor.Name = "lblInfor";
            this.lblInfor.Size = new System.Drawing.Size(29, 12);
            this.lblInfor.TabIndex = 22;
            this.lblInfor.Text = "信息";
            // 
            // chekboxShowPassWord
            // 
            this.chekboxShowPassWord.AutoSize = true;
            this.chekboxShowPassWord.Font = new System.Drawing.Font("微软雅黑", 7.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.chekboxShowPassWord.Location = new System.Drawing.Point(120, 169);
            this.chekboxShowPassWord.Margin = new System.Windows.Forms.Padding(6, 7, 6, 7);
            this.chekboxShowPassWord.Name = "chekboxShowPassWord";
            this.chekboxShowPassWord.Size = new System.Drawing.Size(67, 20);
            this.chekboxShowPassWord.TabIndex = 21;
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
            this.btnCancel.Location = new System.Drawing.Point(207, 261);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(6, 7, 6, 7);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(116, 43);
            this.btnCancel.TabIndex = 19;
            this.btnCancel.Text = "返   回";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOK
            // 
            this.btnOK.FlatAppearance.BorderSize = 2;
            this.btnOK.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Lime;
            this.btnOK.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DarkSeaGreen;
            this.btnOK.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOK.Location = new System.Drawing.Point(41, 261);
            this.btnOK.Margin = new System.Windows.Forms.Padding(6, 7, 6, 7);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(116, 43);
            this.btnOK.TabIndex = 20;
            this.btnOK.Text = "确   定";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // lblConfirmPassWord
            // 
            this.lblConfirmPassWord.AutoSize = true;
            this.lblConfirmPassWord.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblConfirmPassWord.Location = new System.Drawing.Point(40, 136);
            this.lblConfirmPassWord.Margin = new System.Windows.Forms.Padding(11, 0, 11, 0);
            this.lblConfirmPassWord.Name = "lblConfirmPassWord";
            this.lblConfirmPassWord.Size = new System.Drawing.Size(77, 12);
            this.lblConfirmPassWord.TabIndex = 16;
            this.lblConfirmPassWord.Text = "确认新密码:";
            // 
            // lblPassWord
            // 
            this.lblPassWord.AutoSize = true;
            this.lblPassWord.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblPassWord.Location = new System.Drawing.Point(58, 82);
            this.lblPassWord.Margin = new System.Windows.Forms.Padding(11, 0, 11, 0);
            this.lblPassWord.Name = "lblPassWord";
            this.lblPassWord.Size = new System.Drawing.Size(51, 12);
            this.lblPassWord.TabIndex = 17;
            this.lblPassWord.Text = "新密码:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(58, 24);
            this.label1.Margin = new System.Windows.Forms.Padding(11, 0, 11, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 12);
            this.label1.TabIndex = 18;
            this.label1.Text = "用户名:";
            // 
            // txtConfirmPassWord
            // 
            this.txtConfirmPassWord.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtConfirmPassWord.Location = new System.Drawing.Point(119, 130);
            this.txtConfirmPassWord.Margin = new System.Windows.Forms.Padding(11, 13, 11, 13);
            this.txtConfirmPassWord.Name = "txtConfirmPassWord";
            this.txtConfirmPassWord.Size = new System.Drawing.Size(204, 22);
            this.txtConfirmPassWord.TabIndex = 14;
            this.txtConfirmPassWord.UseSystemPasswordChar = true;
            // 
            // txtPassWord
            // 
            this.txtPassWord.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtPassWord.Location = new System.Drawing.Point(119, 77);
            this.txtPassWord.Margin = new System.Windows.Forms.Padding(11, 13, 11, 13);
            this.txtPassWord.Name = "txtPassWord";
            this.txtPassWord.Size = new System.Drawing.Size(204, 22);
            this.txtPassWord.TabIndex = 15;
            this.txtPassWord.UseSystemPasswordChar = true;
            // 
            // cmbUser
            // 
            this.cmbUser.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbUser.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmbUser.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.cmbUser.FormattingEnabled = true;
            this.cmbUser.Location = new System.Drawing.Point(120, 21);
            this.cmbUser.Margin = new System.Windows.Forms.Padding(11, 13, 11, 13);
            this.cmbUser.Name = "cmbUser";
            this.cmbUser.Size = new System.Drawing.Size(204, 20);
            this.cmbUser.TabIndex = 24;
            // 
            // txtUser
            // 
            this.txtUser.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtUser.Location = new System.Drawing.Point(120, 21);
            this.txtUser.Margin = new System.Windows.Forms.Padding(11, 13, 11, 13);
            this.txtUser.Name = "txtUser";
            this.txtUser.Size = new System.Drawing.Size(204, 22);
            this.txtUser.TabIndex = 25;
            this.txtUser.UseSystemPasswordChar = true;
            // 
            // FormEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.ClientSize = new System.Drawing.Size(368, 329);
            this.Controls.Add(this.txtUser);
            this.Controls.Add(this.cmbUser);
            this.Controls.Add(this.lblInfor);
            this.Controls.Add(this.chekboxShowPassWord);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.lblConfirmPassWord);
            this.Controls.Add(this.lblPassWord);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtConfirmPassWord);
            this.Controls.Add(this.txtPassWord);
            this.KeyPreview = true;
            this.MinimizeBox = false;
            this.Name = "FormEdit";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "密码修改";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.FrmEdit_Load);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.FrmEdit_KeyPress);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblInfor;
        private System.Windows.Forms.CheckBox chekboxShowPassWord;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Label lblConfirmPassWord;
        private System.Windows.Forms.Label lblPassWord;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtConfirmPassWord;
        private System.Windows.Forms.TextBox txtPassWord;
        private System.Windows.Forms.ComboBox cmbUser;
        private System.Windows.Forms.TextBox txtUser;
    }
}