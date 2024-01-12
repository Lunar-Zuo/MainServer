using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainServer.Entities
{
    public class PlcSignalsEntity
    {
        [JsonProperty("realinspRequest")]
        public int RealinspRequest { get; set; }

        [JsonProperty("plcSecuritySignal")]
        public int PLCSecuritySignal { get; set; }
        [JsonProperty("plcAlive")]
        public int PlcAlive { get; set; }
        [JsonProperty("plcMode")]
        public int PLCMode { get; set; }
        [JsonProperty("plcRun")]
        public int PLCRun { get; set; }
        [JsonProperty("recipePlc")]
        public int RecipePlc { get; set; }
        [JsonProperty("recipePc")]
        public int RecipePc { get; set; }
        [JsonProperty("inspectUsed")]
        public int InspectUsed { get; set; }

        [JsonProperty("plcinspectUsedL")]
        public int PLCInspectUsedL { get; set; }
        [JsonProperty("plcinspectUsedS")]
        public int PLCInspectUsedS { get; set; }


        [JsonProperty("inspectRequestL")]
        public int InspectRequestL { get; set; }
        [JsonProperty("panelCodeL")]
        public string PaneCodeL { get; set; }
        [JsonProperty("fpcCodeL")]
        public string FPCCodeL { get; set; }
        [JsonProperty("haveProductL")]
        public int HaveProductL { get; set; }



        [JsonProperty("inspectRequestS")]
        public int InspectRequestS { get; set; }
        [JsonProperty("panelCodeS")]
        public string PaneCodeS { get; set; }
        [JsonProperty("fpcCodeS")]
        public string FPCCodeS { get; set; }
        [JsonProperty("haveProductS")]
        public int HaveProductS { get; set; }



        [JsonProperty("inspectResult")]
        public int InspectResult { get; set; }
        [JsonProperty("inspectResultCode")]
        public string InspectResultCode { get; set; }



        [JsonProperty("plcAlarm")]
        public int PlcAlarm { get; set; }


        [JsonProperty("panelId")]
        public string PanelId { get; set; }

        [JsonProperty("captureOver")]
        public int CaptureOver { get; set; }

        [JsonProperty("inspectStart")]
        public int InspectStart { get; set; }

        [JsonProperty("inspectTerminate")]
        public int InspectTerminate { get; set; }



        [JsonProperty("resetRequest")]
        public int ResetRequest { get; set; }

        [JsonProperty("recipeSwitchRequest")]
        public int RecipeSwitchRequest { get; set; }

        [JsonProperty("recipeToBeChanged")]
        public int RecipeToBeChanged { get; set; }

        [JsonProperty("loginRequest")]
        public int LoginRequest { get; set; }

        [JsonProperty("loginUserID")]
        public string LoginUserID { get; set; }




        [JsonProperty("autoStatus")]
        public int AutoStatus { get; set; }


        [JsonProperty("cameraMove")]
        public int CameraMove { get; set; }

        [JsonProperty("chippingGrade")]
        public int ChippingGrade { get; set; }

        [JsonProperty("pcResultWriteCompleted")]
        public int PCResultWriteCompleted { get; set; }

        [JsonProperty("plcAlarmReset")]
        public int PLCAlarmReset { get; set; }


        [JsonProperty("pcRecipeChangeCompleted")]
        public int PcRecipeChangeCompleted { get; set; }
        [JsonProperty("manualRecheckPanelID")]
        public string ManualRecheckPanelID { get; set; }

        [JsonProperty("manualRecheckRequest")]
        public int ManualRecheckRequest { get; set; }

        [JsonProperty("manualRecheckResult")]
        public int ManualRecheckResult { get; set; }

        [JsonProperty("manualRecheckFunctionResult")]
        public int ManualRecheckFunctionResult { get; set; }

        [JsonProperty("heartBeat")]
        public int HeartBeat { get; set; }

        [JsonProperty("vcr")]
        public string VCR { get; set; }

        [JsonProperty("plcReset")]
        public int PLCReset { get; set; }


    }
}
