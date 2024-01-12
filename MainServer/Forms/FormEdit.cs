using MainServer.Helper;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MainServer.Forms
{
    public partial class FormEdit : Form
    {
        public FormEdit()
        {
            InitializeComponent();
            cmbUser.Visible = false;
            txtUser.Visible = true;
            this.txtUser.UseSystemPasswordChar = false;
        }
        public FormEdit(string admin)
        {
            InitializeComponent();
            cmbUser.Visible = true;
            txtUser.Visible = false;
            this.txtUser.UseSystemPasswordChar = false;
        }
        private void FrmEdit_Load(object sender, EventArgs e)
        {
            cmbUser.Items.Clear();
            cmbUser.Items.Add("工程师");
            cmbUser.Items.Add("管理员");
            cmbUser.Text = "管理员";
            lblInfor.Text = "";
            lblPassWord.Text = "旧密码";
            lblConfirmPassWord.Visible = false;
            txtConfirmPassWord.Visible = false;
            txtPassWord.Text = "";
            txtConfirmPassWord.Text = "";
        }
        private void chekboxShowPassWord_CheckedChanged(object sender, EventArgs e)
        {
            if (this.chekboxShowPassWord.Checked == true)
            {
                this.txtPassWord.UseSystemPasswordChar = false;
                this.txtConfirmPassWord.UseSystemPasswordChar = false;
            }
            else
            {
                this.txtPassWord.UseSystemPasswordChar = true;
                this.txtConfirmPassWord.UseSystemPasswordChar = true;
            }
        }
        private void btnOK_Click(object sender, EventArgs e)
        {
            switch (cmbUser.Text)
            {
                case "管理员":
                    if (true)
                    {
                        lblInfor.Text = "请输入新密码...";
                        lblInfor.ForeColor = Color.Green;
                        lblPassWord.Text = "新密码";
                        txtPassWord.Text = "";
                        lblConfirmPassWord.Visible = true;
                        txtConfirmPassWord.Visible = true;
                    }
                    else
                    {
                    }
                    break;
                case "工程师":

                    if (true)
                    {
                        lblInfor.Text = "请输入新密码...";
                        cmbUser.Enabled = false;
                        lblInfor.ForeColor = Color.Green;
                        lblPassWord.Text = "新密码";
                        txtPassWord.Text = "";
                        lblConfirmPassWord.Visible = true;
                        txtConfirmPassWord.Visible = true;
                    }
                    else
                    {
                        lblInfor.Text = "[工程师]密码错误！";
                        lblInfor.ForeColor = Color.DarkRed;
                    }
                    break;
                default:
                    break;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmEdit_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((Keys)e.KeyChar == Keys.Enter)
            {
                btnOK_Click(null, null);
            }
            if ((Keys)e.KeyChar == Keys.Escape)
            {
                btnCancel_Click(null, null);
            }
        }
    }
}
