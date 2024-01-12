using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainServer.Entities
{
    public class UpdataParamsEntity
    {
        /// <summary>
        /// 任务类型 1-用户管理，2-区域管理，3-点位管理
        /// </summary>
        [JsonProperty("type")]
        public int Type { get; set; }
        /// <summary>
        /// 具体任务 1-新增，2-删除，3-禁用
        /// </summary>
        [JsonProperty("mission")]
        public int Mission { get; set; }
        /// <summary>
        /// 用户名/区域名/点位名
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }
        /// <summary>
        /// 操作人员（判断权限）
        /// </summary>
        [JsonProperty("user")]
        public string User { get; set; }
        /// <summary>
        /// 密码
        /// </summary>
        [JsonProperty("password")]
        public string Password { get; set; }

    }
}
