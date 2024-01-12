using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MainServer.Adapter;
using MainServer.Entities;
using MainServer.Helper;

namespace MainServer.Forms
{

    public partial class FormLogin : Form
    {
        public FormLogin()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            this.cmbUser.UseSystemPasswordChar = false;
            this.lblInfor.Text = "";
        }

        private void chekboxShowPassWord_CheckedChanged(object sender, EventArgs e)
        {
            if (this.chekboxShowPassWord.Checked == true)
            {
                this.txtPassWord.UseSystemPasswordChar = false;
            }
            else
            {
                this.txtPassWord.UseSystemPasswordChar = true;
            }
        }

        private void PasswordChange_Click(object sender, EventArgs e)
        {
            FormEdit ue = new FormEdit();
            ue.ShowDialog();
            Close();
        }
        private void AddUser_Click(object sender, EventArgs e)
        {
            FormNew ue = new FormNew();
            ue.ShowDialog();
            Close();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            UserInfo userInfo = PassWordAdapter.Instance.LoadPara(this.cmbUser.Text);
            if (userInfo == null) 
            {
                lblInfor.Text = "未添加此用户，请核对用户名！";
                lblInfor.ForeColor = Color.DarkRed;
                return;
            } 
            if (userInfo.Password == PassWordAdapter.Instance.MD5Encrypt64(this.txtPassWord.Text))
            {
                PassWordAdapter.User = userInfo.Name;
                PassWordAdapter.User_Level = userInfo.Role;
                switch (userInfo.Role)//判断权限
                {
                    case "管理员":
                        lblInfor.Text = "登陆成功! 权限：管理员";
                        lblInfor.ForeColor = Color.Green;
                        break;

                    case "工程师":
                        lblInfor.Text = "登陆成功! 权限：工程师";
                        lblInfor.ForeColor = Color.Green;
                        break;

                    case "操作员":
                        lblInfor.Text = "登陆成功! 权限：操作员";
                        lblInfor.ForeColor = Color.Green;
                        break;

                    default:
                        break;
                }
                Close();
            }
            else //密码不一致
            {
                lblInfor.Text = "密码错误!";
                lblInfor.ForeColor = Color.DarkRed;
            }
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
        /// <summary>
        /// 立即测试击键的有效性或在字符输入时对其进行格式处理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmLogin_KeyPress(object sender, KeyPressEventArgs e)
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
