using FreeSql.DataAnnotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainServer.Entities
{
    /// <summary>
    /// 台车货架表
    /// </summary>
    [Index("TCode", "TCode", true)]
    public class Trolley
    {
        [Column(IsIdentity = true, IsPrimary = true)]
        public int ID { get; set; }
        /// <summary>
        /// 台车、货架编码
        /// </summary>
        public int TCode { get; set; }
        /// <summary>
        /// 台车所属区域
        /// </summary>
        public int RegionID { get; set; }
    }
}
