using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainServer.Entities
{
    /// <summary>
    /// AGV接口返回信息
    /// </summary>
    //[Serializable]
    public class AGVResEntity
    {
        /// <summary>
        /// 返回码
        /// </summary>
        [JsonProperty("code")]
        public string Code { get; set; }
        /// <summary>
        /// 消息
        /// </summary>
        [JsonProperty("message")]
        public string message { get; set; }
        /// <summary>
        /// 请求编号
        /// </summary>
        [JsonProperty("code")]
        public string reqCode { get; set; }
        /// <summary>
        /// 返回数据
        /// </summary>
        [JsonProperty("code")]
        public object data { get; set; }

    }
}
