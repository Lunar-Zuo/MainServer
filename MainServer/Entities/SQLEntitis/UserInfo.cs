using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FreeSql.DataAnnotations;

namespace MainServer.Entities
{
    /// <summary>
    /// 用户信息表
    /// </summary>
    [Index("Name", "Name", true)]
    public class UserInfo
    {
        [Column(IsIdentity=true,IsPrimary=true)]
        public int ID { get; set; }
        /// <summary>
        /// 用户名
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 账号
        /// </summary>
        public string Account { get; set; }
        /// <summary>
        /// 密码
        /// </summary>
        public string Password { get; set; }
        /// <summary>
        /// 角色 管理员/工程师/操作员
        /// </summary>
        public string Role { get; set; }
        /// <summary>
        /// 是否使用
        /// </summary>
        public bool Enable { get; set; }
    }
}
