using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainServer.Entities
{
    public class InspectResEntity
    {
        [JsonProperty("serialNumber")]
        public string SerialNumber { get; set; }

        [JsonProperty("channel")]
        public int Channel { get; set; }

        [JsonProperty("panelCode")]
        public string PanelCode { get; set; }

        [JsonProperty("errCode")]
        public int ErrCode { get; set; }
    }
}
