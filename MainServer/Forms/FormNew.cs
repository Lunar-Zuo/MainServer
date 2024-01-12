using MainServer.Adapter;
using MainServer.Entities;
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
    public partial class FormNew : Form
    {
        public FormNew()
        {
            InitializeComponent();
        }
        private void FormNew_Load(object sender, EventArgs e)
        {
            this.cmbUser.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbUser.Items.Clear();
            cmbUser.Items.Add("工程师");
            cmbUser.Items.Add("操作员");
            cmbUser.Text = "管理员";
            lblInfor.Text = "";
            this.txtPassWord.UseSystemPasswordChar = false;
            this.txtUserName.UseSystemPasswordChar = false;
        }
        private void btnOK_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this.cmbUser.Text))
            {
                lblInfor.Text = "请注意权限不能为空！！";
                lblInfor.ForeColor = Color.DarkRed;
                return;
            }
            if (string.IsNullOrEmpty(this.txtUserName.Text))
            {
                lblInfor.Text = "请注意用户名不能为空！！";
                lblInfor.ForeColor = Color.DarkRed;
                return;
            }
            if (string.IsNullOrEmpty(this.txtPassWord.Text))
            {
                lblInfor.Text = "请注意密码不能为空！！";
                lblInfor.ForeColor = Color.DarkRed;
                return;
            }
            try
            {
                PassWordAdapter.Instance.SavePara(this.txtUserName.Text, this.txtPassWord.Text, this.cmbUser.Text);
                lblInfor.Text = "添加用户成功！";
                lblInfor.ForeColor = Color.Green;
            }
            catch (Exception ex)
            {
                LoggerHelper.Error($"添加用户失败,{ex.Message.ToString()}");
            }

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
