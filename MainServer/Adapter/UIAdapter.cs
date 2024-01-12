using MainServer.Entities;
using MainServer.Forms;
using Sunny.UI;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MainServer.Adapter
{
    public class UIAdapter
    {
        public static UIAdapter Instance = new UIAdapter();
        public FormJobConfig formJobConfig = new FormJobConfig();
        public FormSet formSet = new FormSet();
        public FormFrist formFrist = new FormFrist();
        public FormUserManage formUserManage = new FormUserManage();

        /// <summary>
        /// 在ListBox控件中追加数据√
        /// </summary>
        /// <param name="rtbox"></param>
        /// <param name="text"></param>
        /// <param name="addTime"></param>
        public void AddListToListBox(UIListBox rtbox, string text, bool addTime)
        {
            if (addTime)
            {
                text = string.Format("[{0}]:{1}", DateTime.Now.ToString("HH:mm:ss"), text);
            }
            rtbox.Items.Add(text);
            if (rtbox.Items.Count > 100)
            {
                int count = rtbox.Items.Count - 100;
                List<object> temp = new List<object>();
                for (int i = 0; i < count; i++)
                {
                    temp.Add(rtbox.Items[i]);
                }
                foreach (object obj in temp)
                {
                    rtbox.Items.Remove(obj);
                }
            }
            rtbox.SelectedIndex = rtbox.Items.Count - 1;
        }
        /// <summary>
        /// 在UIComboBox控件中追加数据√
        /// </summary>
        /// <param name="uICombo"></param>
        /// <param name="t"></param>
        public void AddDataToUIComboBox(UIComboBox uICombo, int t = 0)
        {
            uICombo.DropDownStyle = Sunny.UI.UIDropDownStyle.DropDownList;//禁止手动输入
            switch (t)
            {
                case 0:;break;
                case 1://数据库中获取区域信息，加载到上面
                    List<StorageArea> storageAreas = PgSQLAdapter.Instance.PG_StorageAreaSelect(new StorageArea { });
                    foreach (StorageArea storage in storageAreas)
                    {
                        uICombo.Items.Add(storage.Name);
                    }
                    break;
                case 2://数据库中获取点位信息，加载到上面
                    List<StoragePoint> storagePoint = PgSQLAdapter.Instance.PG_StoragePointSelect(new StoragePoint { });
                    foreach (StoragePoint storage in storagePoint)
                    {
                        uICombo.Items.Add(storage.Name);
                    }
                    break;
            }

        }
    }
}
