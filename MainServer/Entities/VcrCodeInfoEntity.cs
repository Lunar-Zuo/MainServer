using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UIMain.Entities
{
    public class VcrCodeInfoEntity
    {
        [JsonProperty("serialNumber")]
        public string SerialNumber { get; set; }

        [JsonProperty("channel")]
        public int Channel { get; set; }

        [JsonProperty("vcrCode")]
        public string VcrCode { get; set; }

        [JsonProperty("errCode")]
        public int ErrCode { get; set; }
    }
}
