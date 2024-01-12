using FreeSql.DataAnnotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainServer.Entities
{
    /// <summary>
    /// 存储点位表
    /// </summary>
    public class StoragePoint
    {
        [Column(IsIdentity = true, IsPrimary = true)]
        public int ID { get; set; }
        /// <summary>
        /// 区域ID
        /// </summary>
        public int RegionID { get; set; }
        /// <summary>
        /// 点位编码
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 电子地图坐标
        /// </summary>
        public string Coordinate { get; set; }
        /// <summary>
        /// 是否可用
        /// </summary>
        public bool Enable { get; set; }
    }
}
