using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MainServer.Commons;
using MainServer.Entities;
using MainServer.Helper;
using MainServer.Utils;

namespace MainServer.Adapter
{
    public delegate void PlcAliveStatusChangedDelegate(int status);
    public delegate void PlcSecuritySignalStatusChangedDelegate(int status);
    public delegate void PlcAutoStatusChangedDelegate(int status);
    public delegate void PlcRunStatusChangedDelegate(int status);
    public delegate void PlcInspectUsedStatusChangedDelegate(int status);
    public delegate void InspectRequestDelegate(string panelId, int recipe);
    public delegate void GetInspectResultDelegate(string panelCode);
    public delegate void LoginReseutDelegate(string userId);
    public delegate void PlcRecipeChangedDelegate(int recipe);

    public delegate void PlcReadResultOverDelegate(int number);
    public delegate void ManualInspectResponseDelegate(string panelid, int code);
    public delegate void PlcAlarmStatusDelegate(int alarm);
    public delegate void ResetRequestDelegate();
    public delegate void CaptureOverDelegate();
    public delegate void RecipeSwitchRrequestDelegate(int recipe);
    public delegate void RealinspRequestDelegate(string panelId, int recipe);
    /// <summary>
    /// 三菱Plc交互模块
    /// </summary>
    public class PlcAdapter
    {
        public int ILogicalStationNumber { get; set; }

        public event PlcAliveStatusChangedDelegate PlcAliveStatusChangedHandler;
        public event PlcSecuritySignalStatusChangedDelegate PlcSecuritySignalStatusChangedHandler;
        public event PlcAutoStatusChangedDelegate PlcAutoStatusChangedHandler;
        public event PlcRunStatusChangedDelegate PlcRunStatusChangedHandler;
        public event PlcInspectUsedStatusChangedDelegate PlcInspectUsedStatusChangedHandler;
        public event PlcRecipeChangedDelegate PlcRecipeChangedHandler;  //获取PLC的Recipe，UI修改显示
        public event InspectRequestDelegate InspectRequestLHandler;
        public event InspectRequestDelegate InspectRequestSHandler;
        public event GetInspectResultDelegate GetInspectResultHandler;
        public event ResetRequestDelegate ResetRequestHandler;
        public event RecipeSwitchRrequestDelegate RecipeSwitchRequestHandler; //PLC发起Recipe切换请求

        public event PlcReadResultOverDelegate PlcReadResultOverHandler;//清除检测允许信号、获取结果
        public event PlcAlarmStatusDelegate PlcAlarmStatusHandler;//PLC报警&清除信号
        public event CaptureOverDelegate CaptureOverHandler;
        public event LoginReseutDelegate LoginReseutHandler;


        private ActUtlType64Lib.ActUtlType64Class lpcom_ReferencesUtlType;

        private bool bOnRunning = true;
        private bool Started = true;
        public static PlcSignalsEntity Signals = new PlcSignalsEntity();

        private int iHeartBeatCount = 0;
        private System.Threading.Timer heartbeatTimer;


        /// <summary>
        /// 模块初始化，连接PLC，创建内部工作环境
        /// </summary>
        public void Init()
        {
            Create();
            PCReset();
        }
        /// <summary>
        /// 模块销毁
        /// </summary>
        public void UnInit()
        {
            Destroy();
        }
        public void Create()
        {
            lpcom_ReferencesUtlType = new ActUtlType64Lib.ActUtlType64Class();
            lpcom_ReferencesUtlType.ActLogicalStationNumber = 1;//PLC 站
            int ret = lpcom_ReferencesUtlType.Open();
            if (ret != 0)
            {
                throw new Exception(String.Format("连接PLC失败 err=0x{0:x8} [HEX]", ret));
            }

            bOnRunning = true;
            Task.Run(() => OnPlcSignalScanTaskProGram());
            heartbeatTimer = new Timer(OnHeartbeatProc, "", 1000, 1000);
        }
        public void Destroy()
        {
            bOnRunning = false;

            try { heartbeatTimer.Dispose(); } catch (Exception) { }

            if (lpcom_ReferencesUtlType != null)
            {
                lpcom_ReferencesUtlType.Close();
                lpcom_ReferencesUtlType = null;
            }
        }

        /// <summary>
        /// 心跳
        /// </summary>
        /// <param name="state"></param>
        private void OnHeartbeatProc(object state)
        {
            try
            {
                if (!Started) return;

                int val = ReadValue(PlcAddress.AddrHeartBeat);
                if (val == 1)
                {
                    iHeartBeatCount = 0;

                    WriteValue(PlcAddress.AddrHeartBeat, 0);

                    PlcAlive = 1;
                }
                else
                {
                    iHeartBeatCount++;
                    if (iHeartBeatCount > 3)
                    {
                        // PLC异常，停止运行
                        PlcAlive = 0;
                    }
                }
            }
            catch (Exception ex)
            {
                LoggerHelper.Warn("心跳处理异常，" + ex.Message);
            }
        }
        /// <summary>
        /// 数据监控(读点位)
        /// </summary>
        private void OnPlcSignalScanTaskProGram()
        {
            //short[] buffer = new short[PlcAddress.AddrPLCAllCount];
            while (bOnRunning)
            {
                try
                {
                    PLCSecuritySignal = ReadValue(PlcAddress.AddPlcSecuritySignal);
                    PLCMode = ReadValue(PlcAddress.AddPlcMode);
                    PLCRun = ReadValue(PlcAddress.AddPlcRun);
                    PlcRecipe = ReadValue(PlcAddress.AddPlcRecipe);
                    InspectUsed = ReadValue(PlcAddress.AddInspectUsed);

                    //暂时保留
                    //PlcAlarm = ReadValue(PlcAddress.AddPlcAlarm);

                    //处理长边检测请求
                    int inspectReqL = ReadValue(PlcAddress.AddPlcInspectRequestL);
                    if (inspectReqL == 1 && InspectRequestL == 0)
                    {
                        short[] buffer = new short[PlcAddress.AddrPanelCodeCountL];
                        ReadArray(PlcAddress.AddPlcPanelCodeL, PlcAddress.AddrPanelCodeCountL, ref buffer);
                        //读取长边 PanelCode
                        PaneCodeL = Utils.Utils.ConvertShortsToString(buffer.Skip(PlcAddress.OffsetPanelCodeStartL).Take(PlcAddress.AddrPanelCodeCountL).ToArray());

                        short[] buffer1 = new short[PlcAddress.AddrFpcCodeCountL];
                        ReadArray(PlcAddress.AddPlcFpcCodeL, PlcAddress.AddrFpcCodeCountL, ref buffer1);
                        //读取长边 Fpc码
                        FPCCodeL = Utils.Utils.ConvertShortsToString(buffer1.Skip(PlcAddress.OffsetFpcCodeStartL).Take(PlcAddress.AddrFpcCodeCountL).ToArray());
                    }
                    PLCInspectUsedL = ReadValue(PlcAddress.AddPlcInspectUsedL);
                    InspectRequestL = inspectReqL;

                    //处理短边检测请求
                    int inspectReqS = ReadValue(PlcAddress.AddPlcInspectRequestS);
                    if (inspectReqS == 1 && InspectRequestS == 0)
                    {
                        short[] buffer = new short[PlcAddress.AddrPanelCodeCountS];
                        ReadArray(PlcAddress.AddPlcPanelCodeS, PlcAddress.AddrPanelCodeCountS, ref buffer);
                        //读取短边 PanelCode
                        PaneCodeS = Utils.Utils.ConvertShortsToString(buffer.Skip(PlcAddress.OffsetPanelCodeStartS).Take(PlcAddress.AddrPanelCodeCountS).ToArray());

                        short[] buffer1 = new short[PlcAddress.AddrFpcCodeCountS];
                        ReadArray(PlcAddress.AddPlcFpcCodeS, PlcAddress.AddrFpcCodeCountS, ref buffer1);
                        //读取短边 Fpc码
                        FPCCodeS = Utils.Utils.ConvertShortsToString(buffer1.Skip(PlcAddress.OffsetFpcCodeStartS).Take(PlcAddress.AddrFpcCodeCountS).ToArray());
                    }
                    PLCInspectUsedS = ReadValue(PlcAddress.AddPlcInspectUsedS);
                    InspectRequestS = inspectReqS;

                    //检测结果获取
                    int inspectRes = ReadValue(PlcAddress.AddPlcInspectResult);
                    if (inspectRes == 1)
                    {
                        short[] buffer = new short[PlcAddress.AddrPanelCodeResultCount];
                        ReadArray(PlcAddress.AddPlcPanelCodeResult, PlcAddress.AddrPanelCodeResultCount, ref buffer);
                        //读取PLC获取结果的PanelCode，从OffsetPanelIdResultStart开始，读取AddrPanelIdResultCountS位
                        InspectResultCode = Utils.Utils.ConvertShortsToString(buffer.Skip(PlcAddress.OffsetPanelCodeResultStart).Take(PlcAddress.AddrPanelCodeResultCount).ToArray());
                    }
                    InspectResult = inspectRes;
                    //复位
                    ResetRequest = ReadValue(PlcAddress.AddPlcResetRequestd);
                    //配方切换
                    int recpReq = ReadValue(PlcAddress.AddPlcRecipeSwitchRequest);
                    if (recpReq == 1 && RecipeSwitchRequest == 0)
                    {
                        RecipeToBeChanged = ReadValue(PlcAddress.AddPlcRecipeToBeChanged);
                    }
                    RecipeSwitchRequest = recpReq;
                    //刷卡登录
                    int login = ReadValue(PlcAddress.AddLoginRequest);
                    if (login == 1 && LoginRequest == 0)
                    {
                        LoginUserID = ReadArray(PlcAddress.AddLoginUserID, PlcAddress.AddrLoginUserIDCount);
                    }
                    LoginRequest = login;

                }
                catch (Exception ex)
                {
                    LoggerHelper.Warn(ex.Message);
                }

                //TimeUtils.Yield(20);
            }
        }

        #region PC -> PLC
        /// <summary>
        /// 设置PC当前使用的配方号
        /// </summary>
        /// <param name="recipe">配方号</param>
        public void SetPcRecipe(int recipe)
        {
            WriteValue(PlcAddress.AddrPCRecipe, recipe);
        }
        /// <summary>
        /// 报警信号 写入或清除
        /// </summary>
        public void PcAlarmWrite(int value)
        {
            WriteValue(PlcAddress.AddrPCAlarm, 1);
            WriteValue(PlcAddress.AddrPCAlarm, value);
        }

        /// <summary>
        /// 通知PLC检测就绪 (长边检测允许信号)
        /// </summary>
        public void InspectReadyL()
        {
            WriteValue(PlcAddress.AddrInspectStartL, 1);
        }
        /// <summary>
        /// 通知PLC检测就绪 (短边检测允许信号)
        /// </summary>
        public void InspectReadyS()
        {
            WriteValue(PlcAddress.AddrInspectStartS, 1);
        }
        /// <summary>
        /// 清除长边检测允许信号
        /// </summary>
        public void ClearInspectReadyL()
        {
            WriteValue(PlcAddress.AddrInspectStartL, 0);
        }
        /// <summary>
        /// 清除短边检测允许信号
        /// </summary>
        public void ClearInspectReadyS()
        {
            WriteValue(PlcAddress.AddrInspectStartS, 0);
        }
        /// <summary>
        /// 通知PLC检测完成
        /// </summary>
        /// <param name="judge">检测结果,1-OK，2-NG</param>
        /// <param name="grade">判级结果</param>
        public void InspectComplete(int judge, int grade)
        {
            WriteValue(PlcAddress.AddrInspectJudge, judge);
            //WriteValue(PlcAddress.AddrChippingGrade, grade);
            //Thread.Sleep(100);
            WriteValue(PlcAddress.AddrPCInspecteComplete, 1);
        }
        /// <summary>
        /// 清除读取结果完成信号
        /// </summary>
        public void InspectCompleteRes()
        {
            WriteValue(PlcAddress.AddrPCInspecteComplete, 0);
        }
        /// <summary>
        /// PC复位反馈
        /// </summary>
        /// <param name="res">PC复位结果，1-成功，2-失败</param>
        public void ResetResponse(int res)
        {
            WriteValue(PlcAddress.AddrPLCReset, res);
        }
        /// <summary>
        /// PC复位响应清除
        /// </summary>
        /// <param name="res">PC复位结果，1-成功，2-失败</param>
        public void ResetResponseClear()
        {
            WriteValue(PlcAddress.AddrPLCReset, 0);
        }
        /// <summary>
        /// 配方切换结果
        /// </summary>
        /// <param name="result">1,成功，2失败</param>
        public void PcRecipeChangeCompletedSet(int result)
        {
            WriteValue(PlcAddress.AddrPCRecipeChangeCompleted, result);
        }
        /// <summary>
        /// 刷卡登录结果
        /// </summary>
        /// <param name="result">1,成功，2失败</param>
        public void PcLoginReset(int result)
        {
            WriteValue(PlcAddress.AddrLoginReset, result);
        }
        /// <summary>
        /// 清除刷卡登录信号
        /// </summary>
        /// <param name="result">1,写入，0,清除</param>
        public void LoginResetClear(int result)
        {
            WriteValue(PlcAddress.AddLoginRequest, result);
        }

        /// <summary>
        /// PC清除PLC信号
        /// </summary>
        public void PCReset()
        {
            ClearInspectReadyL();
            ClearInspectReadyS();
            ClearInspectComplete();
        }
        /// <summary>
        /// 清除PLC检测完成信号
        /// </summary>
        public void ClearInspectComplete()
        {
            WriteValue(PlcAddress.AddrInspectJudge, 0);
            WriteValue(PlcAddress.AddrChippingGrade, 0);
            WriteValue(PlcAddress.AddrPCInspecteComplete, 0);
        }

        /// <summary>
        /// 清除PC配方变更完成信号
        /// </summary>
        public void PcRecipeChangeCompletedClear()
        {
            WriteValue(PlcAddress.AddrPCRecipeChangeCompleted, 0);
        }
        /// <summary>
        /// PLC报警复位
        /// </summary>
        public void PlcAlarmReset()
        {
            WriteValue(PlcAddress.AddrPLCAlarmReset, 1);
            //TimeUtils.Yield(100);
            WriteValue(PlcAddress.AddrPLCAlarmReset, 0);
        }

        #endregion

        #region Read & Write PLC
        /// <summary>
        /// 读取一个点位数据
        /// </summary>
        /// <param name="address"></param>
        /// <returns></returns>
        private int ReadValue(string address)
        {
            try
            {
                int arrDeviceValue;             // Data for 'DeviceData'
                int iReturnCode;                // Return code

                //
                // Processing of GetDevice method
                //
                iReturnCode = lpcom_ReferencesUtlType.GetDevice(address, out arrDeviceValue);
                if (iReturnCode != 0)
                {
                    throw new Exception(string.Format("读取{0}错误, err=0x{1:x8} [HEX]", address, iReturnCode));
                }

                return arrDeviceValue;
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("读取{0}错误, {1}", address, ex.Message));
            }
        }

        /// <summary>
        /// 写
        /// </summary>
        /// <param name="address"></param>
        /// <param name="value"></param>
        private void WriteValue(string address, int value)
        {
            int iReturnCode;                // Return code
            iReturnCode = lpcom_ReferencesUtlType.SetDevice(address, value);
            if (iReturnCode != 0)
            {
                throw new Exception(string.Format("写入{0}错误, err=0x{1:x8} [HEX]", address, iReturnCode));
            }

        }


        /// <summary>
        /// 读连续地址
        /// </summary>
        /// <param name="addr">首地址</param>
        /// <param name="count">数量</param>
        /// <param name="arrDeviceValue">读取内容</param>
        private void ReadArray(string addr, int count, ref short[] arrDeviceValue)
        {
            int iReturnCode;                // Return code
            iReturnCode = lpcom_ReferencesUtlType.ReadDeviceBlock2(addr,
                                                count,
                                                out arrDeviceValue[0]);
            if (iReturnCode != 0)
            {
                throw new Exception(string.Format("读取{0} {1}错误, err=0x{2:x8} [HEX]", addr, count, iReturnCode));
            }
        }
        /// <summary>
        /// 读连续地址
        /// </summary>
        /// <param name="addr">首地址</param>
        /// <param name="count">数量</param>
        /// <returns></returns>
        private string ReadArray(string addr, int count)
        {
            short[] arrDeviceValue = new short[count];
            int iReturnCode;                // Return code
            iReturnCode = lpcom_ReferencesUtlType.ReadDeviceBlock2(addr,
                                                count,
                                                out arrDeviceValue[0]);
            if (iReturnCode != 0)
            {
                throw new Exception(string.Format("读取{0} {1}错误, err=0x{2:x8} [HEX]", addr, count, iReturnCode));
            }
            //byte[] dstDeviceValue = new byte[count * 2];
            //Buffer.BlockCopy(arrDeviceValue, 0, dstDeviceValue, 0, count * 2);
            //return Encoding.Default.GetString(dstDeviceValue);
            string cardId = "";
            for (int i = count - 1; i >= 0; i--)
            {
                int dest = 0;
                short sourceA = arrDeviceValue[i];//高位
                short sourceB = arrDeviceValue[i - 1];//低位
                if (sourceB < 0)
                {
                    dest = sourceB & 0x0000ffff;
                }
                else
                {
                    dest = sourceB;
                }
                if (sourceA < 0)
                {
                    dest = Convert.ToInt32((sourceA & 0x0000ffff).ToString() + dest.ToString());
                }
                else
                {
                    dest = Convert.ToInt32(sourceA.ToString() + dest.ToString());
                }
                cardId += dest.ToString();
                i--;
            }
            return Convert.ToInt32(cardId).ToString();

        }

        /// <summary>
        /// 写连续地址
        /// </summary>
        /// <param name="addr">首地址</param>
        /// <param name="count">数量</param>
        /// <param name="arrDeviceValue">数组</param>
        private void WriteArray(string addr, int count, short[] arrDeviceValue)
        {
            int iReturnCode;                // Return code
            iReturnCode = lpcom_ReferencesUtlType.WriteDeviceBlock2(addr,
                                                count,
                                                ref arrDeviceValue[0]);

            if (iReturnCode != 0)
            {
                throw new Exception(string.Format("写入{0} {1}错误, err=0x{2:x8} [HEX]", addr, count, iReturnCode));
            }
        }
        #endregion

        #region PLC -> PC 对外变量接口
        /*-----------------------状态相关------------------------*/
        /// <summary>
        /// PLC在线状态 1-在线，2-离线（心跳判断）
        /// </summary>
        public int PlcAlive
        {
            get { return Signals.PlcAlive; }
            set
            {
                if (Signals.PlcAlive == value) return;
                Signals.PlcAlive = value;
                PlcAliveStatusChangedHandler?.Invoke(value);
            }
        }
        /// <summary>
        /// 设备安全信号（开关门信号）0：关门，1：开门
        /// </summary>
        public int PLCSecuritySignal
        {
            get { return Signals.PLCSecuritySignal; }
            set
            {
                if (Signals.PLCSecuritySignal == value) return;
                Signals.PLCSecuritySignal = value;
                PlcSecuritySignalStatusChangedHandler?.Invoke(value);
            }
        }
        /// <summary>
        /// PLC手动/自动状态，0：手动，1：自动
        /// </summary>
        public int PLCMode
        {
            get { return Signals.PLCMode; }
            set
            {
                if (Signals.PLCMode == value) return;
                Signals.PLCMode = value;
                PlcAutoStatusChangedHandler?.Invoke(value);
            }
        }
        /// <summary>
        /// PLC运行/停止信号，1：运行，0：停止
        /// </summary>
        public int PLCRun
        {
            get { return Signals.PLCRun; }
            set
            {
                if (Signals.PLCRun == value) return;
                Signals.PLCRun = value;
                PlcRunStatusChangedHandler?.Invoke(value);
            }
        }
        /// <summary>
        /// 启用检测状态
        /// </summary>
        public int InspectUsed
        {
            get { return Signals.InspectUsed; }
            set
            {
                if (Signals.InspectUsed == value) return;
                Signals.InspectUsed = value;
                PlcInspectUsedStatusChangedHandler?.Invoke(value);
            }
        }
        /// <summary>
        /// PC当前使用的配方号
        /// </summary>
        public int PcRecipe
        {
            get { return Signals.RecipePc; }
            set
            {
                if (Signals.RecipePc == value) return;
                Signals.RecipePc = value;
            }
        }
        /// <summary>
        /// PLC 当前配方号
        /// </summary>
        public int PlcRecipe
        {
            get { return Signals.RecipePlc; }
            set
            {
                if (Signals.RecipePlc == value) return;
                Signals.RecipePlc = value;
                //PlcRecipeChangedHandler?.Invoke(value);
            }
        }

        /*-----------------------长边检测------------------------*/
        /// <summary>
        /// 长边检测请求
        /// </summary>
        public int InspectRequestL
        {
            get { return Signals.InspectRequestL; }
            set
            {
                if (Signals.InspectRequestL == value) return;
                Signals.InspectRequestL = value;
                if (PLCMode == 1)
                {
                    if (value != 0)
                    {
                        //LoggerHelper.Info("读PLC码结果,Code=" + PanelId);
                        //处理PLC的检测请求信号
                        InspectRequestLHandler?.Invoke(PaneCodeL, Signals.RecipePlc);
                    }
                    else
                    {
                        //PLC检测到“检测允许”信号，控制Stage移动，同时清除“检测请求”信号；PC检测到“检测请求”信号被清除，则清除“检测允许”信号。
                        //ClearInspectReadyL();
                        PlcReadResultOverHandler?.Invoke(1);
                    }
                }
            }
        }

        /// <summary>
        /// 长边启用检测
        /// </summary>
        public int PLCInspectUsedL
        {
            get { return Signals.PLCInspectUsedL; }
            set
            {
                if (Signals.PLCInspectUsedL == value) return;
                Signals.PLCInspectUsedL = value;
            }
        }

        /// <summary>
        /// 长边产品码
        /// </summary>
        public string PaneCodeL
        {
            get { return Signals.PaneCodeL; }
            set
            {
                if (Signals.PaneCodeL == value) return;
                Signals.PaneCodeL = value;
            }
        }
        /// <summary>
        /// 长边FPC码
        /// </summary>
        public string FPCCodeL
        {
            get { return Signals.FPCCodeL; }
            set
            {
                if (Signals.FPCCodeL == value) return;
                Signals.FPCCodeL = value;
            }
        }
        /// <summary>
        /// 有产品信号
        /// </summary>
        public int HaveProductL
        {
            get { return Signals.HaveProductL; }
            set
            {
                if (Signals.HaveProductL == value) return;
                Signals.HaveProductL = value;
            }
        }

        /*-----------------------短边检测------------------------*/
        /// <summary>
        /// 短边检测请求
        /// </summary>
        public int InspectRequestS
        {
            get { return Signals.InspectRequestS; }
            set
            {
                if (Signals.InspectRequestS == value) return;
                Signals.InspectRequestS = value;
                if (PLCMode == 1)
                {
                    if (value != 0)
                    {
                        //LoggerHelper.Info("读PLC码结果,Code=" + PanelId);
                        //处理PLC的检测请求信号
                        InspectRequestSHandler?.Invoke(PaneCodeS, Signals.RecipePlc);
                    }
                    else
                    {
                        //ClearInspectReadyS();
                        PlcReadResultOverHandler?.Invoke(2);
                    }
                }
            }
        }
        /// <summary>
        /// 短边启用检测
        /// </summary>
        public int PLCInspectUsedS
        {
            get { return Signals.PLCInspectUsedS; }
            set
            {
                if (Signals.PLCInspectUsedS == value) return;
                Signals.PLCInspectUsedS = value;
            }
        }

        /// <summary>
        /// 短边产品码
        /// </summary>
        public string PaneCodeS
        {
            get { return Signals.PaneCodeS; }
            set
            {
                if (Signals.PaneCodeS == value) return;
                Signals.PaneCodeS = value;
            }
        }
        /// <summary>
        /// 短边FPC码
        /// </summary>
        public string FPCCodeS
        {
            get { return Signals.FPCCodeS; }
            set
            {
                if (Signals.FPCCodeS == value) return;
                Signals.FPCCodeS = value;
            }
        }
        /// <summary>
        /// 有产品信号
        /// </summary>
        public int HaveProductS
        {
            get { return Signals.HaveProductS; }
            set
            {
                if (Signals.HaveProductS == value) return;
                Signals.HaveProductS = value;
            }
        }

        /*-----------------------检测结果获取------------------------*/
        /// <summary>
        /// 检测结果请求信号
        /// </summary>
        public int InspectResult
        {
            get { return Signals.InspectResult; }
            set
            {
                if (Signals.InspectResult == value) return;
                Signals.InspectResult = value;
                if (value == 1)
                {
                    GetInspectResultHandler?.Invoke(InspectResultCode);
                }
                else
                {
                    //PC检测到“测结果请求”信号被清除，清除“完成”信号
                    //InspectCompleteRes();
                    PlcReadResultOverHandler?.Invoke(3);
                }
            }
        }
        /// <summary>
        /// 产品码
        /// </summary>
        public string InspectResultCode
        {
            get { return Signals.InspectResultCode; }
            set
            {
                if (Signals.InspectResultCode == value) return;
                Signals.InspectResultCode = value;
            }
        }
        /*-----------------------复位------------------------*/
        /// <summary>
        /// 复位请求
        /// </summary>
        public int ResetRequest
        {
            get { return Signals.ResetRequest; }
            set
            {
                if (Signals.ResetRequest == value) return;
                Signals.ResetRequest = value;
                if (PLCMode == 0)
                {
                    if (value == 1)
                    {
                        ResetRequestHandler?.Invoke();
                    }
                    else
                    {
                        //ResetResponseClear();
                        PlcReadResultOverHandler?.Invoke(4);
                    }
                }
                else
                {
                    LoggerHelper.Error("在自动模式下收到复位信号");
                }
            }
        }

        /*-----------------------配方切换------------------------*/
        /// <summary>
        /// PLC 配方切换请求
        /// </summary>
        public int RecipeSwitchRequest
        {
            get { return Signals.RecipeSwitchRequest; }
            set
            {
                if (Signals.RecipeSwitchRequest == value) return;
                Signals.RecipeSwitchRequest = value;
                if (value == 1)
                {
                    RecipeSwitchRequestHandler?.Invoke(RecipeToBeChanged);
                }
                else
                {
                    PcRecipeChangeCompletedClear();
                }
            }
        }
        /// <summary>
        /// 待变更的配方号编号
        /// </summary>
        public int RecipeToBeChanged
        {
            get { return Signals.RecipeToBeChanged; }
            set
            {
                if (Signals.RecipeToBeChanged == value) return;
                Signals.RecipeToBeChanged = value;
            }
        }
        /// <summary>
        /// 刷卡登录请求
        /// </summary>
        public int LoginRequest
        {
            get { return Signals.LoginRequest; }
            set
            {
                if (Signals.LoginRequest == value) return;
                Signals.LoginRequest = value;
                LoginReseutHandler.Invoke(LoginUserID);
            }
        }
        /// <summary>
        /// 刷卡登录用户ID
        /// </summary>
        public string LoginUserID
        {
            get { return Signals.LoginUserID; }
            set
            {
                if (Signals.LoginUserID == value) return;
                Signals.LoginUserID = value;
            }
        }


        #region 暂时
        /// <summary>
        /// PLC报警，大于0 设备处于异常状态
        /// </summary>
        public int PlcAlarm
        {
            get { return Signals.PlcAlarm; }
            set
            {
                if (Signals.PlcAlarm == value) return;
                Signals.PlcAlarm = value;
                PlcAlarmStatusHandler?.Invoke(value);
            }
        }

        /// <summary>
        /// PLC Alarm Reset
        /// </summary>
        public int PLCAlarmReset
        {
            get { return Signals.PLCAlarmReset; }
            set
            {
                if (Signals.PLCAlarmReset == value) return;
                Signals.PLCAlarmReset = value;
            }
        }

        /// <summary>
        /// 数据上传
        /// </summary>
        public int RealinspRequest
        {
            get { return Signals.CaptureOver; }
            set
            {
                if (Signals.CaptureOver == value) return;
                Signals.CaptureOver = value;
                if (value == 1)
                {
                    CaptureOverHandler?.Invoke();
                }
            }
        }
        /// <summary>
        /// 人工复检玻璃ID(扫码枪读码)
        /// </summary>
        public string ManualRecheckPanelID
        {
            get { return Signals.ManualRecheckPanelID; }
            set
            {
                if (Signals.ManualRecheckPanelID == value) return;
                Signals.ManualRecheckPanelID = value;
            }
        }
        /// <summary>
        /// 人工复判请求
        /// </summary>
        public int ManualRecheckRequest
        {
            get { return Signals.ManualRecheckRequest; }
            set
            {
                if (Signals.ManualRecheckRequest == value) return;
                Signals.ManualRecheckRequest = value;
            }
        }
        /// <summary>
        /// 人工复检结果 1:OK,2:NG
        /// </summary>
        public int ManualRecheckResult
        {
            get { return Signals.ManualRecheckResult; }
            set
            {
                if (Signals.ManualRecheckResult == value) return;
                Signals.ManualRecheckResult = value;
            }
        }
        /// <summary>
        /// 人工复检功能结果 Chipping Grade
        /// </summary>
        public int ManualRecheckFunctionResult
        {
            get { return Signals.ManualRecheckFunctionResult; }
            set
            {
                if (Signals.ManualRecheckFunctionResult == value) return;
                Signals.ManualRecheckFunctionResult = value;
            }
        }
        /// <summary>
        /// PC 心跳信号： PC写1，PLC写0，4S状态未改变报警
        /// </summary>
        public int HeartBeat
        {
            get { return Signals.HeartBeat; }
            set
            {
                if (Signals.HeartBeat == value) return;
                Signals.HeartBeat = value;
            }
        }
        /// <summary>
        /// PLC复位请求反馈，1：复位完成，2复位异常
        /// </summary>
        public int PLCReset
        {
            get { return Signals.PLCReset; }
            set
            {
                if (Signals.PLCReset == value) return;
                Signals.PLCReset = value;
            }
        }
        #endregion
        #endregion
    }
}
