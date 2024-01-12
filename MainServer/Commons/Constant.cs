using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainServer.Commons
{
    public class Constant
    {
        #region 程序类型
        public const string ProgramTypeAuto = "auto";
        public const string ProgramTypeManual = "manual";
        #endregion
        #region url接口
        public static readonly string BaseUrl = "http://localhost:8099/f1";
        public static readonly string UrlGetModuleParams = BaseUrl + "/app/setup/module_info";
        public static readonly string UrlGetJudgeParams = BaseUrl + "/app/setup/module_info";
        public static readonly string UrlPanelIn = BaseUrl + "/app/setup/module_info";
        public static readonly string UrlPanelOut = BaseUrl + "/app/setup/module_info";
        public static readonly string UrlPanelVcrCode = BaseUrl + "/app/setup/module_info";
        public static readonly string UrlManualJudge = BaseUrl + "/app/setup/module_info";
        public static readonly string UrlAlgorithmVersion = BaseUrl + "/app/setup/module_info";

        #endregion

        public readonly static int PanelInspectComplete = 1;
        public readonly static int PanelInspectTimeout = 2;

        public readonly static int PanelResultNoPanel = 0;
        public readonly static int PanelResultNotInspect = 1;
        public readonly static int PanelResultDone = 2;
        public readonly static int PanelManual = 3;

        public readonly static int InspectNoPanel = 0;
        public readonly static int InspectHavePanel = 1;

    }
}
