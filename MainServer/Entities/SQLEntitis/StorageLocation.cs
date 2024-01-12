using FreeSql.DataAnnotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainServer.Entities
{
    /// <summary>
    /// 储位信息表
    /// </summary>
    [Index("Name", "Name", true)]
    public class StorageLocation
    {
        [Column(IsIdentity = true, IsPrimary = true)]
        public int ID { get; set; }
        /// <summary>
        /// 所属 台车、货架编码
        /// </summary>
        public int TCode { get; set; }
        /// <summary>
        /// 点位ID
        /// </summary>
        public int PointID { get; set; }
        /// <summary>
        /// 储位编码
        /// </summary>
        public string StorageID { get; set; }
        /// <summary>
        /// WMS中对应储位
        /// </summary>
        public string WMSStorageID { get; set; }
        /// <summary>
        /// 机台SN
        /// </summary>
        public string MacSN { get; set; }


    }
}
