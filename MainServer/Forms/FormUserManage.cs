using MainServer.Adapter;
using MainServer.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MainServer.Forms
{
    public partial class FormUserManage : Form
    {
        List<UserInfo> userInfos = null;
        public FormUserManage()
        {
            InitializeComponent();
        }

        private void FormUserManage_Load(object sender, EventArgs e)
        {
            userInfos = PgSQLAdapter.Instance.PG_UserSelect(new UserInfo { });
            foreach (UserInfo user in userInfos) 
            {
                this.UsersInfo.Items.Add(user.Name);
            }
        }

        private void bt_ChangePassword_Click(object sender, EventArgs e)
        {
            int N = this.UsersInfo.Items.Count;
            string[] items = new string[N];
            for (int i = 0; i < N; i++)
            {
                if (this.UsersInfo.GetItemChecked(i)) 
                {
                    string v = this.UsersInfo.GetItemText(this.UsersInfo.Items[i]);
                    //TODO：管理员修改密码

                } 
            }
        }
    }
}
