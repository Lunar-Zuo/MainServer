using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainServer.Entities
{
    public class CarCallingEntity
    {
        /// <summary>
        /// 区域代号
        /// </summary>
        [JsonProperty("storage")]
        public int Storage { get; set; }
        /// <summary>
        /// 具体点位
        /// </summary>
        [JsonProperty("point")]
        public int Point { get; set; }
    }
}
