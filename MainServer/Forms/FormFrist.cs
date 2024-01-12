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
    /// <summary>
    /// 首页
    /// </summary>
    public partial class FormFrist : Form
    {
        public FormFrist()
        {
            InitializeComponent();
        }
        private void FormFrist_Load(object sender, EventArgs e)
        {
            UIAdapter.Instance.AddDataToUIComboBox(uiComboBox1,1);
            UIAdapter.Instance.AddDataToUIComboBox(uiComboBox2, 1);
        }

        private void bt_CarCalling_Click(object sender, EventArgs e)
        {
            string str = uiComboBox1.Text.ToString();
            if (str == "区域")
            {
                return;
            }
            //TODO:手动叫车


        }
    } 
}
