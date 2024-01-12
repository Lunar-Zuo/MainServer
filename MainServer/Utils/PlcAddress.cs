using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainServer.Utils
{
    public class PlcAddress
    {
        #region PLC->PC
        public const string AddPlcStart = "D8000";
        public const int AddrPLCAllCount = 116;

        /// <summary>
        /// PC 心跳信号： PC写1，PLC写0，4S状态未改变报警
        /// </summary>
        public const string AddrHeartBeat = "W0";
        public const int OffsetHeartBeat = 0;

        //设备安全信号（开关门信号），0：关门，1：开门
        public const string AddPlcSecuritySignal = "W1";
        public const int OffsetPLCSecuritySignal = 21;

        //PLC手动/自动状态，0：手动，1：自动
        public const string AddPlcMode = "W2";
        public const int OffsetPLCMode = 20;

        //PLC运行/停止信号，1：运行，0：停止
        public const string AddPlcRun = "W3";
        public const int OffsetPLCRun = 22;

        //PLC 当前配方号 
        public const string AddPlcRecipe = "W4";
        public const int OffsetPLCRecipe = 21;

        //状态启用检测
        public const string AddInspectUsed = "W5";
        public const int OffsetInspectUsed = 23;

        //长边检测请求
        public const string AddPlcInspectRequestL = "W8";
        public const int OffsetInspectRequestL = 10;
        //长边产品码
        public const string AddPlcPanelCodeL = "W40";
        public const int OffsetPanelCodeStartL = 0;
        public const int AddrPanelCodeCountL = 10;
        //长边Fpc码
        public const string AddPlcFpcCodeL = "W5E";
        public const int OffsetFpcCodeStartL = 0;
        public const int AddrFpcCodeCountL = 10;
        //长边启用检测
        public const string AddPlcInspectUsedL = "W0B";
        public const int OffsetPLCInspectUsedL = 23;
        //长边开始检测
        public const string AddPlcInspectStartL = "W0C";
        public const int OffsetPLCInspectStartL = 23;
        //长边有产品信号
        public const string AddPlcInspectL = "W0D";
        public const int OffsetPLCInspectL = 23;

        //短边检测请求
        public const string AddPlcInspectRequestS = "W0E";
        public const int OffsetInspectRequestS = 10;
        //短边产品码
        public const string AddPlcPanelCodeS = "W7C";
        public const int OffsetPanelCodeStartS = 0;
        public const int AddrPanelCodeCountS = 10;
        //短边Fpc码
        public const string AddPlcFpcCodeS = "W9A";
        public const int OffsetFpcCodeStartS = 0;
        public const int AddrFpcCodeCountS = 10;
        //短边启用检测
        public const string AddPlcInspectUsedS = "W11";
        public const int OffsetPLCInspectUsedS = 23;
        //短边开始检测
        public const string AddPlcInspectStartS = "W12";
        public const int OffsetPLCInspectStartS = 23;
        //短边有产品信号
        public const string AddPlcInspectS = "W13";
        public const int OffsetPLCInspectS = 23;

        //结果获取
        public const string AddPlcInspectResult = "W14";
        public const int OffsetInspectResult = 10;
        //结果获取产品码
        public const string AddPlcPanelCodeResult = "W0B8";
        public const int OffsetPanelCodeResultStart = 0;
        public const int AddrPanelCodeResultCount = 10;

        //PC复位请求
        public const string AddPlcResetRequestd = "W18";
        public const int OffsetResetRequest = 40;

        //PLC 配方切换请求
        public const string AddPlcRecipeSwitchRequest = "W1A";
        public const int OffsetRecipeSwitchRrequest = 30;

        //待变更的配方号编号
        public const string AddPlcRecipeToBeChanged = "W1B";
        public const int OffsetRecipeToBeChanged = 31;

        //刷卡登录请求
        public const string AddLoginRequest = "W1D";
        public const int OffsetLoginRequest = 30;

        //刷卡登录用户ID
        public const string AddLoginUserID = "W1E";
        public const int OffsetLoginUserIDStart = 0;
        public const int AddrLoginUserIDCount = 4;

        ////最后一个相机采集信号完成 ，拍照完成
        //public const string AddPlcCaptureOver = "D8011";
        //public const int OffsetCaptureOver = 11;
        ////相机检测流程中断，1：检测异常终止
        //public const string AddPlcInspectTerminate = "D8013";
        //public const int OffsetInspectTerminate = 13;
        //数据上传
        //public const string AddRealinspRequest = "D8040";
        //public const int OffsetRealinspRequest = 40;
        #endregion

        #region PC->PLC
        public const string AddrPCStart = "D8050";
        public const int AddrPCAllCount = 40;

        /// <summary>
        /// PC 当前配方号
        /// </summary>
        public const string AddrPCRecipe = "W1A6";
        public const int OffsetPCRecipe = 1;
        /// <summary>
        /// PC 报警 0：Normal, 大于0 异常发生中
        /// </summary>
        public const string AddrPCAlarm = "W1A7";
        public const int OffsetPCAlarm = 17;
        /// <summary>
        /// 长边检测开始
        /// </summary>
        public const string AddrInspectStartL = "W1AB";
        public const int OffsetInspectStartL = 11;
        /// <summary>
        /// 短边检测开始
        /// </summary>
        public const string AddrInspectStartS = "W1B1";
        public const int OffsetInspectStartS = 11;
        /// <summary>
        /// PC结果写入完成信号
        /// </summary>
        public const string AddrPCInspecteComplete = "W1B6";
        public const int OffsetPCInspecteComplete = 15;
        /// <summary>
        /// 检测结果,1:OK，2：NG
        /// </summary>
        public const string AddrInspectJudge = "W1B7";
        public const int OffsetInspectJudge = 13;
        /// <summary>
        /// PLC复位请求反馈，1：复位完成，2复位异常
        /// </summary>
        public const string AddrPLCReset = "W1B9";
        public const int OffsetPLCReset = 21;
        /// <summary>
        /// PC配方变更完成,1-成功，2-失败
        /// </summary>
        public const string AddrPCRecipeChangeCompleted = "W1BC";
        public const int OffsetPCRecipeChangeCompleted = 18;
        /// <summary>
        /// 刷卡登录结果
        /// </summary>
        public const string AddrLoginReset = "W1BD";
        public const int OffsetLoginReset = 0;

        
        /// <summary>
        /// PLC报警
        /// </summary>
        public const string AddrPlcAlarm = "D8012";
        public const int OffsetPlcAlarm = 12;
        /// <summary>
        /// 相机可以移动
        /// </summary>
        public const string AddrCameraMove = "D8062";
        public const int OffsetCameraMove = 12;
        /// <summary>
        /// Chipping Grade 1-8:A-H
        /// </summary>
        public const string AddrChippingGrade = "D8064";
        public const int OffsetChippingGrade = 14;
        /// <summary>
        /// PLC Alarm Reset
        /// </summary>
        public const string AddrPLCAlarmReset = "D8066";
        public const int OffsetPLCAlarmReset = 16;

        public const string AddrPcReadCodeSuccess = "D8072";
        public const int OffPcReadCodeSuccess = 22;
        public const string AddrPcReadCodeFail = "D8073";
        public const int OffPcReadCodeFail = 23;
        public const string AddrPcReadCodeDataStart = "D8080";
        public const int OffPcReadCodeDataStart = 30;
        public const int PcReadCodeDataCount = 10;

        #endregion

        public const int RecipeSwitchSuccess = 1;
        public const int RecipeSwitchFailed = 2;

        public const int ResetSuccess = 1;
        public const int ResetFailed = 2;

        public const int ReadCodeSuccess = 1;
        public const int ReadCodeFailed = 2;

        public const int PlcModeAuto = 1;
        public const int PlcModeManual = 0;
    }
}
