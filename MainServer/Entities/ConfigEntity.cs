using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace MainServer.Entities
{
    /// <summary>
    /// 本地配置参数
    /// </summary>
    [XmlRoot("configure")]
    public class ConfigEntity
    {
        /// <summary>
        /// 程序ID
        /// </summary>
        [XmlElement(ElementName = "procId")]
        public int ProcessId { get; set; }
        /// <summary>
        /// AGV服务地址
        /// </summary>
        [XmlElement(ElementName = "AGVUrl")]
        public string AGVUrl { get; set; }

        /// <summary>
        /// 后台base地址
        /// </summary>
        [XmlElement(ElementName = "WFSUrl")]
        public string WFSUrl { get; set; }

        /// <summary>
        /// Websocket服务监听地址
        /// </summary>
        [XmlElement(ElementName = "wsPort")]
        public int WsPort { get; set; }

        /// <summary>
        /// 服务程序等待检测返回数据超时时间, 秒
        /// </summary>
        [XmlElement(ElementName = "inspectTimeout")]
        public int InspectTimeout { get; set; }

    }
}
