using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainServer.Entities
{
    public class MessageEntity
    {
        /// <summary>
        /// 程序ID
        /// </summary>
        [JsonProperty("progId")]
        public int progId { get; set; }
        /// <summary>
        /// 命令字符
        /// </summary>
        [JsonProperty("command")]
        public string command { get; set; }
        /// <summary>
        /// 数据
        /// </summary>
        [JsonProperty("data")]
        public object data { get; set; }
    }
}
