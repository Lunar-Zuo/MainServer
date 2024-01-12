using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MainServer.Forms
{
    public partial class StartForm : Form
    {
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;
        //调用windows API
        [DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();

        private delegate void KillMeEventHandler();

        private delegate void ShowMessageEventHandler(int i, string s);
        private delegate void ShowMessageEventHandler1( string s);


        //public static string imageName = "";

        public static bool LoadResult = true;

        public static string LoadMessage = "所有程序加载成功！";
        static StartForm Sp = new StartForm();
        public StartForm()
        {
            InitializeComponent();
            
            string versions = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString();

            string updateTime = System.IO.File.GetLastWriteTime(this.GetType().Assembly.Location).ToString();

            lbUpdateInfo.Text = string.Format("更新时间：{0}，版本号：{1}", updateTime, versions);

        }
        
        public static  void  ShowPage()
        {
            
            string imageName = AppDomain.CurrentDomain.BaseDirectory;
            
            string[] imageNames = imageName.Split('\\');
            imageName = null;
            for (int i = 0; i < imageNames.Length-4; i++)
            {
                imageName =imageName+ imageNames[i] + "\\";
            }
            imageName = imageName + "StartPage"+"\\" + "StartPage" + "\\" + "bin" + "\\" + "Debug"+"\\" + "DNb.PNG"; ;
            // MessageBox.Show(imageName);
                if (System.IO.File.Exists(imageName))
                {
                //System.Windows.Forms.PictureBox pb = SplashForm.Controls["pictureBox1"] as System.Windows.Forms.PictureBox;
                Sp.gifBox1.Image = System.Drawing.Image.FromFile(imageName);
                }

            // Progrees = SplashForm.Controls["progressBar1"] as System.Windows.Forms.ProgressBar;
            Sp. progressBar1.Value += 10;
           
            Sp.ShowDialog();
        }

        public  static void ClosePage()
        {
            if (Sp.InvokeRequired)
            {
                Sp.Invoke(new KillMeEventHandler(ClosePage), new object[] { });
                return;
            }
            Sp.progressBar1.Value = 100;
            if (Sp.Created)
            {
                Sp.Dispose();
            }
        }
        public static void showLoadMessage( string s)
        {

            if (Sp.InvokeRequired)
            {
                Sp.Invoke(new ShowMessageEventHandler1(showLoadMessage), new object[] {  s });
                return;
            }
            if (Sp.Created)
            {
                
                Sp.lbStartInfo.Text = s;
            }
        }
        public static  void showLoadMessage(int i, string s)
        {
            if (Sp.InvokeRequired)
            {
                Sp.Invoke(new ShowMessageEventHandler(showLoadMessage), new object[] { i, s });
                return;
            }

            if (Sp.Created)
            {
                if (Sp.progressBar1.Value + i > 100)
                    Sp.progressBar1.Value = 100;
                else
                    Sp. progressBar1.Value = Sp.progressBar1.Value+ i;
                Sp.lbStartInfo.Text = s;
            }
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }
    }
}
