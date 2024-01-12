namespace MainServer.Forms
{
    partial class FormUserManage
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormUserManage));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.bt_ChangePassword = new Sunny.UI.UIButton();
            this.uiCheckBoxGroup1 = new Sunny.UI.UICheckBoxGroup();
            this.UsersInfo = new System.Windows.Forms.CheckedListBox();
            this.tableLayoutPanel1.SuspendLayout();
            this.uiCheckBoxGroup1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.bt_ChangePassword, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.uiCheckBoxGroup1, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 76.44444F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 23.55556F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(800, 450);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // bt_ChangePassword
            // 
            this.bt_ChangePassword.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.bt_ChangePassword.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bt_ChangePassword.Font = new System.Drawing.Font("新細明體", 12F);
            this.bt_ChangePassword.Location = new System.Drawing.Point(670, 385);
            this.bt_ChangePassword.Margin = new System.Windows.Forms.Padding(3, 3, 30, 30);
            this.bt_ChangePassword.MinimumSize = new System.Drawing.Size(1, 1);
            this.bt_ChangePassword.Name = "bt_ChangePassword";
            this.bt_ChangePassword.Size = new System.Drawing.Size(100, 35);
            this.bt_ChangePassword.TabIndex = 1;
            this.bt_ChangePassword.Text = "修改密码";
            this.bt_ChangePassword.TipsFont = new System.Drawing.Font("新細明體", 9F);
            this.bt_ChangePassword.Click += new System.EventHandler(this.bt_ChangePassword_Click);
            // 
            // uiCheckBoxGroup1
            // 
            this.uiCheckBoxGroup1.Controls.Add(this.UsersInfo);
            this.uiCheckBoxGroup1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uiCheckBoxGroup1.Font = new System.Drawing.Font("新細明體", 12F);
            this.uiCheckBoxGroup1.HoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(236)))), ((int)(((byte)(255)))));
            this.uiCheckBoxGroup1.Location = new System.Drawing.Point(4, 5);
            this.uiCheckBoxGroup1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.uiCheckBoxGroup1.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiCheckBoxGroup1.Name = "uiCheckBoxGroup1";
            this.uiCheckBoxGroup1.Padding = new System.Windows.Forms.Padding(10, 32, 10, 10);
            this.uiCheckBoxGroup1.SelectedIndexes = ((System.Collections.Generic.List<int>)(resources.GetObject("uiCheckBoxGroup1.SelectedIndexes")));
            this.uiCheckBoxGroup1.Size = new System.Drawing.Size(792, 333);
            this.uiCheckBoxGroup1.TabIndex = 2;
            this.uiCheckBoxGroup1.Text = "uiCheckBoxGroup1";
            this.uiCheckBoxGroup1.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // UsersInfo
            // 
            this.UsersInfo.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.UsersInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.UsersInfo.FormattingEnabled = true;
            this.UsersInfo.Location = new System.Drawing.Point(10, 32);
            this.UsersInfo.Name = "UsersInfo";
            this.UsersInfo.Size = new System.Drawing.Size(772, 291);
            this.UsersInfo.TabIndex = 0;
            // 
            // FormUserManage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.tableLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormUserManage";
            this.Text = "FormJobConfig";
            this.Load += new System.EventHandler(this.FormUserManage_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.uiCheckBoxGroup1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private Sunny.UI.UIButton bt_ChangePassword;
        private Sunny.UI.UICheckBoxGroup uiCheckBoxGroup1;
        private System.Windows.Forms.CheckedListBox UsersInfo;
    }
}