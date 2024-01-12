using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using MainServer.Adapter;
using MainServer.Commons;
using MainServer.Entities;
using MainServer.Utils;
using System.Drawing;
using MainServer.Helper;
using MainServer.Forms;

namespace MainServer
{
    public partial class MainForm : Form
    {
        protected static ConfigAdapter config = new ConfigAdapter();
        protected static MessageAdapter msgAdapter = new MessageAdapter();
        protected static AGVAdapter AGV = new AGVAdapter();
        protected static ITAdapter IT = new ITAdapter();
        protected static PlcAdapter plc = new PlcAdapter();

        List<Form> SubForms = new List<Form>();
        public static UserInfo user = null;
        protected int PCRecipe = 0;
        protected bool bStarted = false;
        private Point offset;

        /// <summary>
        /// 检测产品的数据
        /// </summary>
        private Dictionary<string, PanelInspectEntity> AoiPanelList = new Dictionary<string, PanelInspectEntity>();
        public MainForm()
        {
            InitializeComponent();
            try
            {
                StartForm.showLoadMessage("正在加载程序，请稍等！");

                //设置线程池最小线程数为100
                ThreadPool.SetMinThreads(100, 100);

                Startup();

                Thread.Sleep(1000);
                StartForm.showLoadMessage("程序加载完毕！");
                StartForm.ClosePage();
            }
            catch (Exception ex)
            {
                StartForm.ClosePage();
                LoggerHelper.Error(string.Format("失败,{0}", ex.Message));
            }
        }
        protected void Startup()
        {
            try
            {
                //加载本地配置文件
                LoadConfig();

                //初始化本地日志
                InitLogger();

                //加载UI
                Init_SubForms();

                //加载参数 数据库
                LoadDeviceParams();

                //初始化主从通信
                InitMessageAdapter();

                //初始化AGV交互通信
                InitAGV();

                //初始化IT交互通信
                //AGVAdapter.Instance.init();

                //初始化PLC
                //InitPlc();

                bStarted = true;

                Thread.Sleep(100);
                LoggerHelper.Info(string.Format("服务器程序初始化完成！"));

            }
            catch (Exception ex)
            {
                LoggerHelper.Error(string.Format("服务器程序初始化失败,{0}", ex.Message));
            }
        }

        public int CopyFolder(string oldFolder, string newFolder)
        {
            try
            {
                if (!System.IO.Directory.Exists(newFolder))
                {
                    System.IO.Directory.CreateDirectory(newFolder);
                }
                string[] files = System.IO.Directory.GetFiles(oldFolder);
                foreach (string file in files)
                {
                    string name = System.IO.Path.GetFileName(file);
                    string dest = System.IO.Path.Combine(newFolder, name);
                    System.IO.File.Copy(file, dest);
                }
                string[] folders = System.IO.Directory.GetDirectories(oldFolder);
                foreach (string folder in folders)
                {
                    string name = System.IO.Path.GetFileName(folder);
                    string dest = System.IO.Path.Combine(newFolder, name);
                    CopyFolder(folder, dest);
                }
                return 0;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                return 1;
            }
        }
        #region 初始化 加载
        protected void InitLogger()
        {
            LoggerHelper.Init("\\log4net-main.xml");
        }
        /// <summary>
        /// 本地配置文件加载
        /// </summary>
        protected void LoadConfig()
        {
            config.LoadConfig();
        }
        /// <summary>
        /// 数据库参数初始化加载
        /// </summary>
        protected void LoadDeviceParams()
        {
            //PgSQLAdapter.Instance.init();
            PassWordAdapter.Instance.init();
        }

        #endregion

        #region UI
        /// <summary>
        /// 拖拽窗口：点击
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainForm_MenuDown(object sender, MouseEventArgs e)
        {
            if (MouseButtons.Left != e.Button) return;
            Point cur = this.PointToScreen(e.Location);
            offset = new Point(cur.X - this.Left, cur.Y - this.Top);
        }
        /// <summary>
        /// 拖拽窗口：移动
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainForm_MenuMove(object sender, MouseEventArgs e)
        {
            if (MouseButtons.Left != e.Button) return;
            Point cur = MousePosition;
            this.Location = new Point(cur.X - offset.X, cur.Y - offset.Y);
        }
        /// <summary>
        /// 初始化子页面
        /// </summary>
        private void Init_SubForms()
        {
            try
            {
                //将页面加载到控件中
                Add_SubForms(UIAdapter.Instance.formFrist);
                Add_SubForms(UIAdapter.Instance.formSet);
                Add_SubForms(UIAdapter.Instance.formJobConfig);
                Add_SubForms(UIAdapter.Instance.formUserManage);
            }
            catch (Exception ex)
            {
                LoggerHelper.Error(string.Format("UI初始化失败,{0}", ex.Message));
            }
        }
        private void Add_SubForms(Form f)
        {
            f.TopLevel = false;
            f.FormBorderStyle = FormBorderStyle.None;
            f.Dock = DockStyle.Fill;
            splitContainer2.Panel2.Controls.Add(f);
            SubForms.Add(f);
        }
        /// <summary>
        /// 根据Panel的大小重置内嵌Form的大小
        /// </summary>
        private void ResizeSubForms()
        {
            foreach (Form f in SubForms)
            {
                f.Size = new Size(splitContainer2.Panel2.Width, splitContainer2.Panel2.Height);
            }
        }

        private void splitContainer2_Panel2_SizeChanged(object sender, EventArgs e)
        {
            ResizeSubForms();
        }
        private void PBExit_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("您是否选择退出！", "退出确认", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                Application.Exit();
            }
        }
        private void PBExit_MouseEnter(object sender, EventArgs e)
        {
            PBExit.BackColor = Color.Red;
        }
        private void PBExit_MouseLeave(object sender, EventArgs e)
        {
            PBExit.BackColor = Color.Transparent;
        }
        private void PBMin_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
        private void PBMin_MouseEnter(object sender, EventArgs e)
        {
            PBMin.BackColor = Color.Red;
        }
        private void PBMin_MouseLeave(object sender, EventArgs e)
        {
            PBMin.BackColor = Color.Transparent;
        }
        private void PBMax_Click(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Maximized)
            {
                this.WindowState = FormWindowState.Normal;
                this.PBMax.BackgroundImage = new Bitmap(@"../../../Image/max.png");
                //TODO:不用源码开启时，需要将路径改为 Application.StartupPath
            }
            else
            {
                this.WindowState = FormWindowState.Maximized;
                this.PBMax.BackgroundImage = new Bitmap(@"../../../Image/min.png");
            }
        }
        private void PBMax_MouseEnter(object sender, EventArgs e)
        {
            PBMax.BackColor = Color.Red;
        }
        private void PBMax_MouseLeave(object sender, EventArgs e)
        {
            PBMax.BackColor = Color.Transparent;
        }

        private void bt_Home_Click(object sender, EventArgs e)
        {
            UIAdapter.Instance.formFrist = new FormFrist();
            Add_SubForms(UIAdapter.Instance.formFrist);
            UIAdapter.Instance.formFrist.Show();
            //关闭释放资源
            UIAdapter.Instance.formJobConfig.Close();
            UIAdapter.Instance.formSet.Close();
            UIAdapter.Instance.formUserManage.Close();
        }
        private void bt_Set_Click(object sender, EventArgs e)
        {
            UIAdapter.Instance.formSet = new FormSet();
            Add_SubForms(UIAdapter.Instance.formSet);
            UIAdapter.Instance.formSet.Show();
            UIAdapter.Instance.formFrist.Close();
            UIAdapter.Instance.formJobConfig.Close();
            UIAdapter.Instance.formUserManage.Close();
        }
        private void bt_Configuration_Click(object sender, EventArgs e)
        {
            UIAdapter.Instance.formJobConfig = new FormJobConfig();
            Add_SubForms(UIAdapter.Instance.formJobConfig);
            UIAdapter.Instance.formJobConfig.Show();
            UIAdapter.Instance.formFrist.Close();
            UIAdapter.Instance.formSet.Close();
            UIAdapter.Instance.formUserManage.Close();
        }
        private void bt_UserManage_Click(object sender, EventArgs e)
        {
            UIAdapter.Instance.formUserManage = new FormUserManage();
            Add_SubForms(UIAdapter.Instance.formUserManage);
            UIAdapter.Instance.formUserManage.Show();
            UIAdapter.Instance.formFrist.Close();
            UIAdapter.Instance.formJobConfig.Close();
            UIAdapter.Instance.formSet.Close();
        }
        private void bt_Login_Click(object sender, EventArgs e)
        {
            if (bt_Login.Text == "登录")
            {
                FormLogin formLogin = new FormLogin();
                formLogin.ShowDialog();
                switch (PassWordAdapter.User_Level)
                {
                    case "操作员":
                        {
                            bt_Set.Visible = false;
                            gifBox1.Visible = false;
                            bt_Configuration.Visible = false;
                            bt_UserManage.Visible = false;
                            bt_Login.Text = "取消登录";
                        }
                        break;
                    case "工程师":
                        {
                            gifBox1.Visible = false;
                            bt_Set.Visible = true;
                            bt_Configuration.Visible = true;
                            bt_UserManage.Visible = false;
                            bt_Login.Text = "取消登录";
                        }
                        break;
                    case "管理员":
                        {
                            gifBox1.Visible = false;
                            bt_Set.Visible = true;
                            bt_Configuration.Visible = true;
                            bt_UserManage.Visible = true;
                            bt_Login.Text = "取消登录";
                        }
                        break;
                    default:break;
                }
                if(!string.IsNullOrEmpty(PassWordAdapter.User_Level))
                UIAdapter.Instance.formFrist.Show();
            }
            else//取消登录操作 
            {
                bt_Login.Text = "登录";
                PassWordAdapter.User = "";
                PassWordAdapter.User_Level = "";
                gifBox1.Visible = true;
                UIAdapter.Instance.formFrist.Hide();
                UIAdapter.Instance.formJobConfig.Hide();
                UIAdapter.Instance.formSet.Hide();
                UIAdapter.Instance.formUserManage.Hide();
            }
        }

        #endregion

        #region 主从通信
        protected void InitMessageAdapter()
        {
            msgAdapter.ProgramAliveStatusHandler += OnProgramAliveStatusChange;
            msgAdapter.UpdateParamsHandler += OnUpdateParams;
            msgAdapter.CarCallingHandler += OnCarCalling;
            msgAdapter.Init(config.Config.WsPort);
        }

        /// <summary>
        /// 程序状态改变
        /// </summary>
        /// <param name="id"></param>
        /// <param name="status"></param>
        /// <param name="munber">1-程序状态，2-相机状态</param>
        private void OnProgramAliveStatusChange(int id, int status, int munber)
        {
            try
            {
                //UI显示状态

            }
            catch (Exception ex)
            {
                string message = munber > 1 ? "相机" : "程序";
                LoggerHelper.Error($"处理{message}连接状态改变异常，" + ex.Message);
            }
        }

        /// <summary>
        /// 响应前端程序更新操作
        /// </summary>
        /// <param name="errCode"></param>
        private void OnUpdateParams(UpdataParamsEntity updataParams)
        {
            try
            {

                //TODO:　
            }
            catch (Exception ex)
            {
                LoggerHelper.Error("处理检测配置更新异常，" + ex.Message);
            }
        }
        /// <summary>
        /// 处理手动叫车
        /// </summary>
        /// <param name="errCode"></param>
        private void OnCarCalling(CarCallingEntity carCalling)
        {
            try
            {

                //TODO:　
            }
            catch (Exception ex)
            {
                LoggerHelper.Error("处理手动叫车异常，" + ex.Message);
            }
        }

        #endregion

        #region IT交互
        /// <summary>
        /// Stroe in - SN信息对比
        /// </summary>
        private void OnStroeIn()
        {
        }
        #endregion

        #region AGV交互
        private void InitAGV()
        {
            //AGV.GenAgvSchedulingHandler += OnGenAgvScheduling;
            //AGV.init(config.Config.AGVUrl);
        }
        /// <summary>
        /// 生成AGV任务单号返回
        /// </summary>
        /// <param name="id"></param>
        /// <param name="status"></param>
        /// <param name="munber">1-程序状态，2-相机状态</param>
        private void OnGenAgvScheduling(string res)
        {
            try
            {
                //TODO：数据处理
                AGVResEntity resData = JsonConvert.DeserializeObject<AGVResEntity>(res);


            }
            catch (Exception ex)
            {
                LoggerHelper.Error($"处理生成AGV任务单号返回信息异常，" + ex.Message);
            }
        }
        #endregion

        #region PLC
        protected void InitPlc()
        {
            plc.ILogicalStationNumber = 1/*CommitAdapter.Instance.GetPlcLogicStationNumber()*/;

            plc.PlcAliveStatusChangedHandler += OnPlcAliveChanged;
            plc.PlcSecuritySignalStatusChangedHandler += OnPlcSecuritySignalStatusChanged;
            plc.PlcAutoStatusChangedHandler += OnPlcAutoStatusChanged;
            plc.PlcRunStatusChangedHandler += OnPlcRunStatusChanged;
            plc.PlcInspectUsedStatusChangedHandler += OnPlcInspectUsedStatusChanged;
            plc.ResetRequestHandler += OnPlcResetRequest;
            plc.LoginReseutHandler += OnLoginRequest;

            plc.PlcAlarmStatusHandler += OnPlcAlarmStatus;
            plc.PlcReadResultOverHandler += OnPlcReadResultOver;

            plc.Init();
        }

        /// <summary>
        /// PLC连接状态变化
        /// </summary>
        /// <param name="status"></param>
        private void OnPlcAliveChanged(int status)
        {
            PlcAliveChangedAsync(status);
        }
        private async void PlcAliveChangedAsync(int status)
        {
            await Task.Run(() =>
            {
                try
                {
                    string message = (status == 1 ? "上线" : "离线");

                    LoggerHelper.Info("PLC：" + message);
                }
                catch (Exception ex)
                {
                    LoggerHelper.Warn(string.Format("处理PLC心跳检测结果异常, {0}", ex.Message));
                }
            });
        }

        /// <summary>
        /// 设备安全信号（开关门信号）0：开门，不安全，1：关门，安全
        /// </summary>
        /// <param name="status"></param>
        private void OnPlcSecuritySignalStatusChanged(int status)
        {
            string message;
            if (status == 0)
            {
                message = "安全门打开！";
            }
            else
            {
                message = "安全门关闭！";
            }
            LoggerHelper.Info("PLC：" + message);
        }

        /// <summary>
        /// PLC自动状态切换
        /// </summary>
        /// <param name="status"></param>
        private void OnPlcAutoStatusChanged(int status)
        {
            PlcAutoStatusChangedAsync(status);
        }
        private async void PlcAutoStatusChangedAsync(int status)
        {
            await Task.Run(() =>
            {
                try
                {
                    string message = "切换设备状态, status=" + status;

                    LoggerHelper.Info("PLC：" + message);
                }
                catch (Exception ex)
                {
                    LoggerHelper.Warn(string.Format("处理PLC心跳检测结果异常, {0}", ex.Message));
                }
            });
        }

        /// <summary>
        /// PLC运行状态
        /// </summary>
        /// <param name="status"></param>
        private void OnPlcRunStatusChanged(int status)
        {
            PlcRunStatusChangedAsync(status);
        }
        private async void PlcRunStatusChangedAsync(int status)
        {
            await Task.Run(() =>
            {
                try
                {
                    string message;
                    if (status == 1)
                    {
                        message = "设备运行状态,界面锁定！ status=" + status;
                    }
                    else
                    {
                        message = "设备停止状态,界面解锁！ status=" + status;
                    }
                }
                catch (Exception ex)
                {
                    LoggerHelper.Warn(string.Format("处理PLC心跳检测结果异常, {0}", ex.Message));
                }
            });
        }
        /// <summary>
        /// 检测启用，PLC开启检测功能
        /// </summary>
        /// <param name="status"></param>
        private void OnPlcInspectUsedStatusChanged(int status)
        {
            PlcInspectUsedStatusChangedAsync(status);
        }
        private async void PlcInspectUsedStatusChangedAsync(int status)
        {
            await Task.Run(() =>
            {
                try
                {
                    string message = "切换设备启用检测状态, status=" + status;

                    LoggerHelper.Info("PLC" + message);
                }
                catch (Exception ex)
                {
                    LoggerHelper.Warn(string.Format("处理PLC心跳检测结果异常, {0}", ex.Message));
                }
            });
        }

        /// <summary>
        /// PLC复位PC信号
        /// </summary>
        private void OnPlcResetRequest()
        {
            PlcResetRequestAsync();
        }
        private async void PlcResetRequestAsync()
        {
            await Task.Run(() =>
            {
                try
                {
                    //PC软件对检测相关的所有逻辑进行复位处理。
                    plc.PCReset();

                    plc.ResetResponse(PlcAddress.ResetSuccess);
                }
                catch (Exception ex)
                {
                    //只进行信号复位，如有异常，则为PLC操作异常，无需设置复位失败
                    LoggerHelper.Warn(string.Format("处理PLC复位请求异常, {0}", ex.Message));
                }
            });
        }

        /// <summary>
        /// 刷卡登录
        /// </summary>
        /// <param name="recipe"></param>
        private void OnLoginRequest(string userId)
        {
            LoginRequest(userId);
        }
        private async void LoginRequest(string userId)
        {
            await Task.Run(() =>
            {
                try
                {
                    LoggerHelper.Info(string.Format("{0} 刷卡登录！", userId));
                    plc.PcLoginReset(1);
                }
                catch (Exception ex)
                {
                    LoggerHelper.Info(string.Format("{0} 刷卡登录失败！+{1}", userId, ex));
                    plc.PcLoginReset(2);
                }
                Thread.Sleep(500);
                plc.LoginResetClear(0);

            });
        }
        /// <summary>
        /// PLC报警信息显示
        /// </summary>
        /// <param name="code"></param>
        private void OnPlcAlarmStatus(int code)
        {
            PlcAlarmStatusAsync(code);
        }
        private async void PlcAlarmStatusAsync(int code)
        {
            await Task.Run(() =>
            {
                try
                {
                    if (code == 1)
                    {
                        string message = "PLC报警 " + code;

                        //TODO: 查询并显示PLC报警信息
                        LoggerHelper.Info("PLC" + message);
                    }
                    else
                    {
                        //清除PLC报警信号
                        plc.PcAlarmWrite(0);
                    }
                }
                catch (Exception ex)
                {
                    LoggerHelper.Warn(string.Format("处理PLC报警值结果异常, {0}", ex.Message));
                }
            });
        }

        /// <summary>
        /// PLC读取结果完成，清信号
        /// </summary>
        private void OnPlcReadResultOver(int number)
        {
            PlcPlcReadResultOverAsync(number);
        }

        private async void PlcPlcReadResultOverAsync(int number)
        {
            await Task.Run(() =>
            {
                try
                {
                    switch (number)
                    {
                        case 1://复位信号
                            plc.ResetResponseClear();
                            break;
                        default:
                            plc.ClearInspectComplete();
                            break;
                    }
                }
                catch (Exception ex)
                {
                    LoggerHelper.Warn(string.Format("处理PLC读取结果完成异常, {0}", ex.Message));
                }
            });
        }











        #endregion
    }
}

