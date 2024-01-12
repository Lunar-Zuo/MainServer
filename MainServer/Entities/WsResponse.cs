using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainServer.Entities
{
    public class WsResponse
    {
        [JsonProperty("errCode")]
        public int ErrCode { get; set; }
    }
}
