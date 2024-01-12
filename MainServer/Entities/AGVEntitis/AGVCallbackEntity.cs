using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainServer.Entities
{
    //[Serializable]
    public class AGVCallbackEntity
    {
        /// <summary>
        /// 请求编号
        /// </summary>
        [JsonProperty("reqCode")]
        public string reqCode { get; set; }
        /// <summary>
        /// 请求时间戳
        /// </summary>
        [JsonProperty("reqTime")]
        public string reqTime { get; set; }
        /// <summary>
        /// 地码X坐标
        /// </summary>
        [JsonProperty("cooX")]
        public string cooX { get; set; }
        /// <summary>
        /// 地码Y坐标
        /// </summary>
        [JsonProperty("cooY")]
        public string cooY { get; set; }
        /// <summary>
        /// 当前位置编号
        /// </summary>
        [JsonProperty("currentPositionCode")]
        public string currentPositionCode { get; set; }
        /// <summary>
        /// 自定义字段
        /// </summary>
        [JsonProperty("data")]
        public string data { get; set; }
        /// <summary>
        /// 地图编号
        /// </summary>
        [JsonProperty("mapCode")]
        public string mapCode { get; set; }
        /// <summary>
        /// 方法名：任务类型做方法名，start：任务开始，outbin：走出储位，end：任务结束，cancel：任务单结束，
        /// </summary>
        [JsonProperty("method")]
        public string method { get; set; }
        /// <summary>
        /// 货架编号：背货架时有值
        /// </summary>
        [JsonProperty("podCode")]
        public string podCode { get; set; }
        /// <summary>
        /// 180.0.90.-90分别对应左.右.上.下。任务完成时有值
        /// </summary>
        [JsonProperty("podDir")]
        public string podDir { get; set; }
        /// <summary>
        /// AGV编号
        /// </summary>
        [JsonProperty("robotCode")]
        public string robotCode { get; set; }
        /// <summary>
        /// 当前任务单号
        /// </summary>
        [JsonProperty("taskCode")]
        public string taskCode { get; set; }
        /// <summary>
        /// 工作位，与AGV配置的位置名称一致，任务完成时有值
        /// </summary>
        [JsonProperty("wbCode")]
        public string wbCode { get; set; }

    }
}
