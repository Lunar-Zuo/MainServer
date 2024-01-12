using FreeSql.DataAnnotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainServer.Entities
{
    /// <summary>
    /// 搬运记录
    /// </summary>
    public class HandlingRecords
    {
        [Column(IsIdentity = true, IsPrimary = true)]
        public int ID { get; set; }
        /// <summary>
        /// 机台SN
        /// </summary>
        public string MacSN { get; set; }
        /// <summary>
        /// 台车编号
        /// </summary>
        public int TCode { get; set; }
        /// <summary>
        /// 台车储位位置信息
        /// </summary>
        public string StorageID { get; set; }
        /// <summary>
        /// 货架位置信息
        /// </summary>
        public string ShelfID { get; set; }
    }
}
