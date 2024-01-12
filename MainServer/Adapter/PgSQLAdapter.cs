using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using MainServer.Entities;
using MainServer.Helper;

namespace MainServer.Adapter
{
    public class PgSQLAdapter
    {
        public static PgSQLAdapter Instance = new PgSQLAdapter();
        static string connectionString = "Host=127.0.0.1;Port=5432;Username=postgres;Password=postgres;Database=ForestSystem;Pooling=true;Minimum Pool Size=1";

        static IFreeSql fsql = new FreeSql.FreeSqlBuilder()
            .UseConnectionString(FreeSql.DataType.PostgreSQL, connectionString)
            .UseAutoSyncStructure(true) //自动同步实体结构到数据库
            .Build(); //请务必定义成 Singleton 单例模式
        /// <summary>
        /// 数据库初始化加载
        /// </summary>
        public void init()
        {
            try
            {

            }
            catch (Exception e)
            {

                throw;
            }
        }

        /// <summary>
        /// 增加数据
        /// </summary>
        /// <param name="obj">对象数据</param>
        /// <param name="i">表 区分</param>
        /// <returns></returns>
        public int PG_Insert(Object obj, int i)
        {
            try
            {
                switch (i)
                {
                    case 1://用户信息表
                        UserInfo userInfo = (UserInfo)obj;
                        userInfo.ID = (int)fsql.Insert<UserInfo>().AppendData(userInfo).ExecuteIdentity();
                        break;
                    case 2://存储区域表
                        StorageArea storageArea = (StorageArea)obj;
                        storageArea.ID = (int)fsql.Insert<StorageArea>().AppendData(storageArea).ExecuteIdentity();
                        break;
                    case 3://存储点位表
                        StoragePoint storagePoint = (StoragePoint)obj;
                        storagePoint.ID = (int)fsql.Insert<StoragePoint>().AppendData(storagePoint).ExecuteIdentity();
                        break;
                    case 4://台车货架表
                        Trolley trolley = (Trolley)obj;
                        trolley.ID = (int)fsql.Insert<Trolley>().AppendData(trolley).ExecuteIdentity();
                        break;
                    case 5://储位信息表
                        StorageLocation storageLocation = (StorageLocation)obj;
                        storageLocation.ID = (int)fsql.Insert<StorageLocation>().AppendData(storageLocation).ExecuteIdentity();
                        break;
                    case 6://搬运记录
                        HandlingRecords handlingRecords = (HandlingRecords)obj;
                        handlingRecords.ID = (int)fsql.Insert<HandlingRecords>().AppendData(handlingRecords).ExecuteIdentity();
                        break;

                    default: break;
                }
                return 0;
            }
            catch (Exception ex)
            {
                LoggerHelper.Error("PG_Insert失败：" + ex.Message);
                return 1;
            }
        }

        #region 删除
        /// <summary>
        /// 用户表信息删除
        /// </summary>
        /// <param name="id"></param>
        /// <param name="t"></param>
        /// <returns></returns>
        public int PG_UserDelete(object id, int t = 0)
        {
            try
            {
                switch (t)
                {
                    case 1://用户信息表
                        fsql.Delete<UserInfo>().Where(a => a.ID == (int)id).ExecuteAffrows();
                        break;
                    case 2://存储区域表
                        fsql.Delete<StorageArea>().Where(a => a.Name == id.ToString()).ExecuteAffrows();
                        break;
                    case 3://存储点位表
                        fsql.Delete<StoragePoint>().Where(a => a.ID == (int)id).ExecuteAffrows();
                        break;
                    case 4://台车货架表
                        fsql.Delete<Trolley>().Where(a => a.ID == (int)id).ExecuteAffrows();
                        break;
                    case 5://储位信息表
                        fsql.Delete<StorageLocation>().Where(a => a.ID == (int)id).ExecuteAffrows();
                        break;
                    case 6://搬运记录
                        fsql.Delete<HandlingRecords>().Where(a => a.ID == (int)id).ExecuteAffrows();
                        break;

                    default: break;
                }
                return 0;
            }
            catch (Exception e)
            {
                LoggerHelper.Error($"PG_Delete：ID为{id}的数据删除失败：" + e.Message.ToString());
                return 1;
            }
        }
        /// <summary>
        /// 存储区域表信息删除
        /// </summary>
        /// <param name="id"></param>
        /// <param name="t"></param>
        /// <returns></returns>
        public int PG_StorageAreaDelete(object id, int t = 0)
        {
            try
            {
                switch (t)
                {
                    case 1://按ID删除
                        fsql.Delete<StorageArea>().Where(a => a.ID == (int)id).ExecuteAffrows();
                        break;
                    case 2:
                        fsql.Delete<StorageArea>().Where(a => a.Name == id.ToString()).ExecuteAffrows();
                        break;
                    case 3:
                        fsql.Delete<StorageArea>().Where(a => a.AreaInfo == id.ToString()).ExecuteAffrows();
                        break;
                    case 4:
                        fsql.Delete<StorageArea>().Where(a => a.Enable == (bool)id).ExecuteAffrows();
                        break;

                    default: break;
                }
                return 0;
            }
            catch (Exception e)
            {
                LoggerHelper.Error($"PG_Delete：数据{id}删除失败：" + e.Message.ToString());
                return 1;
            }
        }
        /// <summary>
        /// 存储点位表信息删除
        /// </summary>
        /// <param name="id"></param>
        /// <param name="t"></param>
        /// <returns></returns>
        public int PG_StoragePointDelete(object id, int t = 0)
        {
            try
            {
                switch (t)
                {
                    case 1://按ID删除
                        fsql.Delete<StoragePoint>().Where(a => a.ID == (int)id).ExecuteAffrows();
                        break;
                    case 2:
                        fsql.Delete<StoragePoint>().Where(a => a.RegionID == (int)id).ExecuteAffrows();
                        break;
                    case 3:
                        fsql.Delete<StoragePoint>().Where(a => a.Name == id.ToString()).ExecuteAffrows();
                        break;
                    case 4:
                        fsql.Delete<StoragePoint>().Where(a => a.Coordinate == id.ToString()).ExecuteAffrows();
                        break;
                    case 5:
                        fsql.Delete<StoragePoint>().Where(a => a.Enable == (bool)id).ExecuteAffrows();
                        break;

                    default: break;
                }
                return 0;
            }
            catch (Exception e)
            {
                LoggerHelper.Error($"PG_Delete：数据{id}删除失败：" + e.Message.ToString());
                return 1;
            }
        }
        /// <summary>
        /// 储位表信息删除
        /// </summary>
        /// <param name="id"></param>
        /// <param name="t"></param>
        /// <returns></returns>
        public int PG_StorageLocationDelete(object id, int t = 0)
        {
            try
            {
                switch (t)
                {
                    case 1://按ID删除
                        fsql.Delete<StorageLocation>().Where(a => a.ID == (int)id).ExecuteAffrows();
                        break;
                    case 2:
                        fsql.Delete<StorageLocation>().Where(a => a.TCode == (int)id).ExecuteAffrows();
                        break;
                    case 3:
                        fsql.Delete<StorageLocation>().Where(a => a.PointID == (int)id).ExecuteAffrows();
                        break;
                    case 4:
                        fsql.Delete<StorageLocation>().Where(a => a.StorageID == id.ToString()).ExecuteAffrows();
                        break;
                    case 5:
                        fsql.Delete<StorageLocation>().Where(a => a.WMSStorageID == id.ToString()).ExecuteAffrows();
                        break;
                    case 6:
                        fsql.Delete<StorageLocation>().Where(a => a.MacSN == id.ToString()).ExecuteAffrows();
                        break;

                    default: break;
                }
                return 0;
            }
            catch (Exception e)
            {
                LoggerHelper.Error($"PG_Delete：数据{id}删除失败：" + e.Message.ToString());
                return 1;
            }
        }
        #endregion

        #region 修改
        /// <summary>
        /// 用户表修改
        /// </summary>
        /// <param name="obj">需要写入的新数据</param>
        /// <param name="t"></param>
        /// <returns></returns>
        public int PG_UserUpdate(Object obj,int t = 0)
        {
            try
            {
                switch (t) 
                {
                    case 1:
                        fsql.Update<UserInfo>().Where(a => a.ID == (int)obj).ExecuteAffrows();
                        break;
                    case 2:
                        fsql.Update<UserInfo>().Where(a => a.Name ==obj.ToString()).ExecuteAffrows();
                        break;
                    case 3:
                        fsql.Update<UserInfo>().Where(a => a.Account == obj.ToString()).ExecuteAffrows();
                        break;
                    case 4:
                        fsql.Update<UserInfo>().Where(a => a.Password == obj.ToString()).ExecuteAffrows();
                        break;
                    case 5:
                        fsql.Update<UserInfo>().Where(a => a.Role == obj.ToString()).ExecuteAffrows();
                        break;
                    case 6:
                        fsql.Update<UserInfo>().Where(a => a.Enable == (bool)obj).ExecuteAffrows();
                        break;
                    default:break;
                }
                return 0;
            }
            catch (Exception e)
            {
                LoggerHelper.Error($"PG_UserUpdate：数据库修改失败，{obj}数据：" + e.Message.ToString());
                return 1;
            }
        }
        /// <summary>
        /// 存储区域表修改
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="t"></param>
        /// <returns></returns>
        public int PG_StorageAreaUpdate(Object obj, int t = 0)
        {
            try
            {
                switch (t)
                {
                    case 1:
                        fsql.Update<StorageArea>().Where(a => a.ID == (int)obj).ExecuteAffrows();
                        break;
                    case 2:
                        fsql.Update<StorageArea>().Where(a => a.Name == obj.ToString()).ExecuteAffrows();
                        break;
                    case 3:
                        fsql.Update<StorageArea>().Where(a => a.AreaInfo == obj.ToString()).ExecuteAffrows();
                        break;
                    case 4:
                        fsql.Update<StorageArea>().Where(a => a.Enable == (bool)obj).ExecuteAffrows();
                        break;
                    default: break;
                }
                return 0;
            }
            catch (Exception e)
            {
                LoggerHelper.Error($"PG_StorageAreaUpdate：数据库修改失败，{obj}数据：" + e.Message.ToString());
                return 1;
            }
        }
        /// <summary>
        /// 存储点位表修改
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="t"></param>
        /// <returns></returns>
        public int PG_StoragePointUpdate(Object obj, int t = 0)
        {
            try
            {
                switch (t)
                {
                    case 1:
                        fsql.Update<StoragePoint>().Where(a => a.ID == (int)obj).ExecuteAffrows();
                        break;
                    case 2:
                        fsql.Update<StoragePoint>().Where(a => a.RegionID == (int)obj).ExecuteAffrows();
                        break;
                    case 3:
                        fsql.Update<StoragePoint>().Where(a => a.Name == obj.ToString()).ExecuteAffrows();
                        break;
                    case 4:
                        fsql.Update<StoragePoint>().Where(a => a.Coordinate == obj.ToString()).ExecuteAffrows();
                        break;
                    case 5:
                        fsql.Update<StoragePoint>().Where(a => a.Enable == (bool)obj).ExecuteAffrows();
                        break;
                    default: break;
                }
                return 0;
            }
            catch (Exception e)
            {
                LoggerHelper.Error($"PG_UserUpdate：数据库修改失败，{obj}数据：" + e.Message.ToString());
                return 1;
            }
        }
        /// <summary>
        /// 储位表修改
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="t"></param>
        /// <returns></returns>
        public int PG_StorageLocationUpdate(Object obj, int t = 0)
        {
            try
            {
                switch (t)
                {
                    case 1:
                        fsql.Update<StorageLocation>().Where(a => a.ID == (int)obj).ExecuteAffrows();
                        break;
                    case 2:
                        fsql.Update<StorageLocation>().Where(a => a.TCode == (int)obj).ExecuteAffrows();
                        break;
                    case 3:
                        fsql.Update<StorageLocation>().Where(a => a.PointID == (int)obj).ExecuteAffrows();
                        break;
                    case 4:
                        fsql.Update<StorageLocation>().Where(a => a.StorageID == obj.ToString()).ExecuteAffrows();
                        break;
                    case 5:
                        fsql.Update<StorageLocation>().Where(a => a.WMSStorageID == obj.ToString()).ExecuteAffrows();
                        break;
                    case 6:
                        fsql.Update<StorageLocation>().Where(a => a.MacSN == obj.ToString()).ExecuteAffrows();
                        break;
                    default: break;
                }
                return 0;
            }
            catch (Exception e)
            {
                LoggerHelper.Error($"PG_UserUpdate：数据库修改失败，{obj}数据：" + e.Message.ToString());
                return 1;
            }
        }
        #endregion

        #region 查询
        /// <summary>
        /// 多条件查询（用户表）
        /// </summary>
        /// <param name="u">查询条件</param>
        /// <returns></returns>
        public List<UserInfo> PG_UserSelect(UserInfo u)
        {
            List<UserInfo> user = new List<UserInfo>();

            string sql = @"select * from ""UserInfo"" ";
            //查询条件
            if (!string.IsNullOrEmpty(u.Name))
            {
                if (!sql.Contains("where")) { sql += "where"; } else { sql += "and"; }
                sql += @" ""Name"" = " + "'" + u.Name + "'";
            }
            if (!string.IsNullOrEmpty(u.Account))
            {
                if (!sql.Contains("where")) { sql += "where"; } else { sql += "and"; }
                sql += @" ""Account"" = " + "'" + u.Account + "'";
            }
            if (!string.IsNullOrEmpty(u.Role))
            {
                if (!sql.Contains("where")) { sql += "where"; } else { sql += "and"; }
                sql += @" ""Role"" = " + "'" + u.Role + "'";
            }
            user = fsql.Select<UserInfo>()
                .WithSql(sql)
                .ToList();

            return user;
        }
        /// <summary>
        /// 多条件查询（存储区域表）
        /// </summary>
        /// <param name="u">查询条件</param>
        /// <returns></returns>
        public List<StorageArea> PG_StorageAreaSelect(StorageArea u)
        {
            List<StorageArea> user = new List<StorageArea>();

            string sql = @"select * from ""StorageArea"" ";
            //查询条件
            if (!string.IsNullOrEmpty(u.Name))
            {
                sql += @"where ""Name"" = " + "'" + u.Name + "'";
            }

            user = fsql.Select<StorageArea>()
                .WithSql(sql)
                .ToList();

            return user;
        }
        /// <summary>
        /// 多条件查询（存储点位表）
        /// </summary>
        /// <param name="u">查询条件</param>
        /// <returns></returns>
        public List<StoragePoint> PG_StoragePointSelect(StoragePoint u)
        {
            List<StoragePoint> user = new List<StoragePoint>();

            string sql = @"select * from ""StoragePoint"" ";
            //查询条件
            if (u.RegionID >= 0)
            {
                if (!sql.Contains("where")) { sql += "where"; } else { sql += "and"; }
                sql += @" ""RegionID"" = " + "'" + u.RegionID + "'";
            }
            if (!string.IsNullOrEmpty(u.Name))
            {
                if (!sql.Contains("where")) { sql += "where"; } else { sql += "and"; }
                sql += @" ""Name"" = " + "'" + u.Name + "'";
            }
            if (!string.IsNullOrEmpty(u.Coordinate))
            {
                if (!sql.Contains("where")) { sql += "where"; } else { sql += "and"; }
                sql += @" ""Coordinate"" = " + "'" + u.Coordinate + "'";
            }

            user = fsql.Select<StoragePoint>()
                .WithSql(sql)
                .ToList();

            return user;
        }
        /// <summary>
        /// 多条件查询（台车货架表）
        /// </summary>
        /// <param name="u">查询条件</param>
        /// <returns></returns>
        public List<Trolley> PG_TrolleySelect(Trolley u)
        {
            List<Trolley> user = new List<Trolley>();

            string sql = @"select * from ""Trolley"" ";
            //查询条件
            if (u.RegionID >= 0)
            {
                if (!sql.Contains("where")) { sql += "where"; } else { sql += "and"; }
                sql += @" ""RegionID"" = " + "'" + u.RegionID + "'";
            }
            if (u.TCode>=0)
            {
                if (!sql.Contains("where")) { sql += "where"; } else { sql += "and"; }
                sql += @" ""TCode"" = " + "'" + u.TCode + "'";
            }
            user = fsql.Select<Trolley>()
                .WithSql(sql)
                .ToList();

            return user;
        }
        /// <summary>
        /// 多条件查询（存储点位表）
        /// </summary>
        /// <param name="u">查询条件</param>
        /// <returns></returns>
        public List<StorageLocation> PG_StorageLocationSelect(StorageLocation u)
        {
            List<StorageLocation> user = new List<StorageLocation>();

            string sql = @"select * from ""StorageLocation"" ";
            //查询条件
            if (u.TCode >= 0)
            {
                if (!sql.Contains("where")) { sql += "where"; } else { sql += "and"; }
                sql += @" ""TCode"" = " + "'" + u.TCode + "'";
            }
            if (u.PointID >= 0)
            {
                if (!sql.Contains("where")) { sql += "where"; } else { sql += "and"; }
                sql += @" ""PointID"" = " + "'" + u.PointID + "'";
            }
            if (!string.IsNullOrEmpty(u.StorageID))
            {
                if (!sql.Contains("where")) { sql += "where"; } else { sql += "and"; }
                sql += @" ""Name"" = " + "'" + u.StorageID + "'";
            }
            if (!string.IsNullOrEmpty(u.WMSStorageID))
            {
                if (!sql.Contains("where")) { sql += "where"; } else { sql += "and"; }
                sql += @" ""Coordinate"" = " + "'" + u.WMSStorageID + "'";
            }
            if (!string.IsNullOrEmpty(u.MacSN))
            {
                if (!sql.Contains("where")) { sql += "where"; } else { sql += "and"; }
                sql += @" ""MacSN"" = " + "'" + u.MacSN + "'";
            }

            user = fsql.Select<StorageLocation>()
                .WithSql(sql)
                .ToList();

            return user;
        }
        /// <summary>
        /// 多条件查询（搬运记录表）
        /// </summary>
        /// <param name="u">查询条件</param>
        /// <returns></returns>
        public List<HandlingRecords> PG_HandlingRecordsSelect(HandlingRecords u)
        {
            List<HandlingRecords> user = new List<HandlingRecords>();

            string sql = @"select * from ""HandlingRecords"" ";
            //查询条件
            if (u.TCode >= 0)
            {
                if (!sql.Contains("where")) { sql += "where"; } else { sql += "and"; }
                sql += @" ""TCode"" = " + "'" + u.TCode + "'";
            }
            if (!string.IsNullOrEmpty(u.MacSN))
            {
                if (!sql.Contains("where")) { sql += "where"; } else { sql += "and"; }
                sql += @" ""MacSN"" = " + "'" + u.MacSN + "'";
            }
            if (!string.IsNullOrEmpty(u.StorageID))
            {
                if (!sql.Contains("where")) { sql += "where"; } else { sql += "and"; }
                sql += @" ""StorageID"" = " + "'" + u.StorageID + "'";
            }
            if (!string.IsNullOrEmpty(u.ShelfID))
            {
                if (!sql.Contains("where")) { sql += "where"; } else { sql += "and"; }
                sql += @" ""ShelfID"" = " + "'" + u.ShelfID + "'";
            }
            user = fsql.Select<HandlingRecords>()
                .WithSql(sql)
                .ToList();

            return user;
        }


        #endregion
    }
}
