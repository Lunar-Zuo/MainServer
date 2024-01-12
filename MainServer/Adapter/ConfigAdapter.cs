using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using MainServer.Entities;

namespace MainServer.Adapter
{
    /// <summary>
    /// 配置文件加载模块
    /// </summary>
    public class ConfigAdapter
    {

        private const string filename = "./configure-main.xml";

        public ConfigEntity Config { get; set; }

        public void LoadConfig()
        {
            try
            {
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(ConfigEntity));
                using (var fs = File.OpenRead(filename))
                {
                    Config = (ConfigEntity)xmlSerializer.Deserialize(fs);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("加载参数异常,{0}", ex.Message));
            }

        }
    }
}
