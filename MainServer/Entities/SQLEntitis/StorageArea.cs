using FreeSql.DataAnnotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainServer.Entities
{
    /// <summary>
    /// 存储区域表
    /// </summary>
    [Index("Name", "Name", true)]
    public class StorageArea
    {
        [Column(IsIdentity = true, IsPrimary = true)]
        public int ID { get; set; }
        /// <summary>
        /// 区域名
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 区域备注
        /// </summary>
        public string AreaInfo { get; set; }
        /// <summary>
        /// 是否使用
        /// </summary>
        public bool Enable { get; set; }
    }
}
