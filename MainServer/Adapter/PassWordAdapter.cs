using MainServer.Entities;
using MainServer.Helper;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace MainServer.Adapter
{
    [Serializable]
    public class PassWordAdapter
    {
        public static PassWordAdapter Instance = new PassWordAdapter();
        /// <summary>
        /// 当前登录账号权限
        /// </summary>
        public static string User_Level = "";
        /// <summary>
        /// 当前登录账号
        /// </summary>
        public static string User = "";

        public PassWordAdapter()
        {

        }
        public void init()
        {
            try
            {
                //验证admin管理员账号
                List<UserInfo> users = PgSQLAdapter.Instance.PG_UserSelect(new UserInfo { Name = "admin", Role = "管理员" });
                if (users == null) 
                {
                    //默认管理员admin admin
                    UserInfo userInfo = new UserInfo { Name = "admin", Account = "admin", Password = MD5Encrypt64("admin"), Role = "管理员", Enable = true };
                    PgSQLAdapter.Instance.PG_Insert(userInfo, 1);
                }
            }
            catch (Exception ex)
            {
                LoggerHelper.Info($"验证admin管理员账号出现错误！{ex.Message}");
            }
        }
        /// <summary>
        /// 保存用户账户数据
        /// </summary>
        public void SavePara(string name, string passWord, string role)
        {
            try
            {
                string pw = MD5Encrypt64(passWord);
                UserInfo userInfo = new UserInfo() { Name = name, Password = pw, Role = role, Enable = true };
                PgSQLAdapter.Instance.PG_Insert(userInfo, 1);
            }
            catch (Exception ex)
            {
                LoggerHelper.Error($"保存用户账户数据出现错误！{ex.Message}");
            }
        }
        /// <summary>
        /// 加载数据库存储的密码
        /// </summary>
        public UserInfo LoadPara(string uesrName)
        {
            try
            {
                List<UserInfo> userInfos = PgSQLAdapter.Instance.PG_UserSelect(new UserInfo { Name = uesrName });
                return userInfos[0];
            }
            catch (Exception ex)
            {
                LoggerHelper.Error($"加载数据库存储的密码出现错误！{ex.Message}");
                return null;
            }
        }
        /// <summary>
        /// 修改密码
        /// </summary>
        public void ChangePara(string password)
        {
            try
            {

                //TODO:验证权限or密码
                string _password = MD5Encrypt64(password);
                int res = PgSQLAdapter.Instance.PG_UserUpdate(new UserInfo { Password = _password },4);
            }
            catch (Exception ex)
            {
                LoggerHelper.Error($"修改密码出现错误！{ex.Message}");
            }
        }
        /// <summary>
        /// MD5加密
        /// </summary>
        /// <param name="password"></param>
        /// <returns></returns>
        public string MD5Encrypt64(string password)
        {
            try
            {
                if (!string.IsNullOrEmpty(password))
                {
                    string cl = password;
                    //string pwd = "";
                    System.Security.Cryptography.MD5 md5 = System.Security.Cryptography.MD5.Create(); //实例化一个md5对像
                    // 加密后是一个字节类型的数组，这里要注意编码UTF8/Unicode等的选择　
                    byte[] s = md5.ComputeHash(Encoding.UTF8.GetBytes(cl));
                    return Convert.ToBase64String(s);
                }
                return "";
            }
            catch (Exception ex)
            {
                LoggerHelper.Error($"MD5加密出现错误！{ex.Message}");
                return "";
            }
        }

    }
}
