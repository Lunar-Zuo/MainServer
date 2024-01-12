using MainServer.Adapter;
using MainServer.Entities;
using MainServer.Helper;
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
    public partial class FormSet : Form
    {
        private bool IsDelAreaCheck = false;
        private bool IsDisableAreaCheck = false;

        private bool IsDelPointCheck = false;
        private bool IsDisablePointCheck = false;
        public FormSet()
        {
            InitializeComponent();
        }
        private void FormSet_Load(object sender, EventArgs e)
        {
            StorageAreaListBox.BringToFront();
            StoragePointListBox.BringToFront();
            AreaRefresh();
            PointRefresh();
            UIAdapter.Instance.AddDataToUIComboBox(cb_StoragePoint, 1);
        }
        /// <summary>
        /// 刷新区域管理数据
        /// </summary>
        public void AreaRefresh()
        {
            StorageAreaListBox.Items.Clear();

            StorageAreaListBox.Visible = true;
            List<StorageArea> areas = PgSQLAdapter.Instance.PG_StorageAreaSelect(new StorageArea { });
            int i = 0;
            foreach (StorageArea item in areas)
            {
                UIAdapter.Instance.AddListToListBox(StorageAreaListBox, i+" - "+ item.Name, false);
                i++;
            }
            InputArea.Text = "请输入需新增区域：";
            InputArea.Enabled = false;
        }
        /// <summary>
        /// 刷新点位管理数据
        /// </summary>
        public void PointRefresh()
        {
            StoragePointListBox.Items.Clear();

            StoragePointListBox.Visible = true;
            List<StoragePoint> areas = PgSQLAdapter.Instance.PG_StoragePointSelect(new StoragePoint { });
            int i = 0;
            foreach (StoragePoint item in areas)
            {
                UIAdapter.Instance.AddListToListBox(StoragePointListBox, item.Name, false);
                i++;
            }
            InputPoint.Text = "请输入需新增点位：";
            InputPoint.Enabled = false;
        }
        #region 区域管理
        private void bt_AddArea_Click(object sender, EventArgs e)
        {
            try
            {
                StorageAreaListBox.Visible = false;
                InputArea.Enabled = true;

                //区域名不能为空 不能包含汉字
                if (string.IsNullOrEmpty(InputArea.Text) || MethodHelper.Instance.IsChineseByReg(InputArea.Text))
                {
                    return;
                }
                string str = System.Text.RegularExpressions.Regex.Replace(InputArea.Text, @"\s", "");//去除空格
                StorageArea Areas = new StorageArea() { Name = str, Enable = true };
                PgSQLAdapter.Instance.PG_Insert(Areas, 2);
                AreaRefresh();
            }
            catch (Exception ex)
            {
                LoggerHelper.Info($"增加区域时出现异常，{ex.Message}");
            }
        }
        private void bt_DelArea_Click(object sender, EventArgs e)
        {
            try
            {
                StorageAreaListBox.Visible = false;
                InputArea.Text = "确认删除区域！";
                InputArea.Enabled = false;
                List<int> TextItems = StorageAreaListBox.SelectedIndices.Cast<int>().ToList();

                //防呆确认
                if (!IsDelAreaCheck)
                {
                    IsDelAreaCheck = true;
                    return;
                }
                foreach (var item in TextItems)
                {
                    string[] s = StorageAreaListBox.Items[item].ToString().Split('-');//获取选中item的值
                    string str = System.Text.RegularExpressions.Regex.Replace(s[s.Length-1], @"\s", "");
                    PgSQLAdapter.Instance.PG_StorageAreaDelete(str, 2);
                }
                IsDelAreaCheck = false;
                AreaRefresh();
            }
            catch (Exception ex)
            {
                LoggerHelper.Info($"删除区域时出现异常，{ex.Message}");
            }
        }
        private void bt_DisableArea_Click(object sender, EventArgs e)
        {
            try
            {
                StorageAreaListBox.Visible = false;
                InputArea.Text = "确认禁用区域！";
                InputArea.Enabled = false;
                List<int> TextItems = StorageAreaListBox.SelectedIndices.Cast<int>().ToList();

                //防呆确认
                if (!IsDisableAreaCheck)
                {
                    IsDisableAreaCheck = true;
                    return;
                }
                foreach (var item in TextItems)
                {
                    string s = StorageAreaListBox.Items[item].ToString();//获取选中item的值
                    string str = System.Text.RegularExpressions.Regex.Replace(s, @"\s", "");
                }
                IsDisableAreaCheck = false;
                AreaRefresh();
            }
            catch (Exception ex)
            {
                LoggerHelper.Info($"禁用区域时出现异常，{ex.Message}");
            }
        }
        private void ExitArea_Click(object sender, EventArgs e)
        {
            AreaRefresh();
            IsDelAreaCheck = false;
            IsDisableAreaCheck = false;
        }
        private void InputArea_MouseDown(object sender, MouseEventArgs e)
        {
            InputArea.Text = "";
        }
        #endregion


        #region 点位管理
        private void lb_ExitPoint_Click(object sender, EventArgs e)
        {
            PointRefresh();
            IsDelPointCheck = false;
            IsDisablePointCheck = false;
        }
        private void bt_AddPoint_Click(object sender, EventArgs e)
        {
            try
            {
                StoragePointListBox.Visible = false;
                InputPoint.Enabled = true;

                //区域名不能为空 不能包含汉字
                if (string.IsNullOrEmpty(InputPoint.Text) || MethodHelper.Instance.IsChineseByReg(InputPoint.Text))
                {
                    return;
                }
                string str = System.Text.RegularExpressions.Regex.Replace(InputPoint.Text, @"\s", "");//去除空格
                StoragePoint Points = new StoragePoint() { Name = str, Enable = true };
                PgSQLAdapter.Instance.PG_Insert(Points, 3);
                PointRefresh();
            }
            catch (Exception ex)
            {
                LoggerHelper.Info($"增加点位时出现异常，{ex.Message}");
            }
        }

        private void bt_DisablePoint_Click(object sender, EventArgs e)
        {
            try
            {
                StoragePointListBox.Visible = false;
                InputPoint.Text = "确认禁用区域！";
                InputPoint.Enabled = false;
                List<int> TextItems = StoragePointListBox.SelectedIndices.Cast<int>().ToList();

                //防呆确认
                if (!IsDisablePointCheck)
                {
                    IsDisablePointCheck = true;
                    return;
                }
                foreach (var item in TextItems)
                {
                    string s = StoragePointListBox.Items[item].ToString();//获取选中item的值
                    string str = System.Text.RegularExpressions.Regex.Replace(s, @"\s", "");
                }
                IsDisablePointCheck = false;
                AreaRefresh();
            }
            catch (Exception ex)
            {
                LoggerHelper.Info($"禁用点位时出现异常，{ex.Message}");
            }
        }

        private void bt_DelPoint_Click(object sender, EventArgs e)
        {
            try
            {
                StoragePointListBox.Visible = false;
                InputPoint.Text = "确认删除区域！";
                InputPoint.Enabled = false;
                List<int> TextItems = StoragePointListBox.SelectedIndices.Cast<int>().ToList();

                //防呆确认
                if (!IsDelPointCheck)
                {
                    IsDelPointCheck = true;
                    return;
                }
                foreach (var item in TextItems)
                {
                    string s = StoragePointListBox.Items[item].ToString();//获取选中item的值
                    string str = System.Text.RegularExpressions.Regex.Replace(s, @"\s", "");
                    PgSQLAdapter.Instance.PG_StoragePointDelete(str, 3);
                }
                IsDelPointCheck = false;
                AreaRefresh();
            }
            catch (Exception ex)
            {
                LoggerHelper.Info($"删除点位时出现异常，{ex.Message}");
            }
        }
        #endregion
    }
}
