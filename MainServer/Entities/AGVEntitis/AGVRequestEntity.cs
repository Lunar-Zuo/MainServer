using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainServer.Entities
{
    /// <summary>
    /// 生产任务单
    /// </summary>
    [Serializable]
    public class AGVRequestEntity
    {
        /// <summary>
        /// 请求编号
        /// </summary>
        public string reqCode { get; set; }
        /// <summary>
        /// 任务单号
        /// </summary>
        public string taskCode { get; set; }
        /// <summary>
        /// 任务类型
        /// </summary>
        public string taskTyp { get; set; }
        /// <summary>
        /// 点位集合
        /// </summary>
        public List<PositionCodePath> positionCodePath { get; set; }
        /// <summary>
        /// 生产任务类型 叉车必传1，不传或者传空值代表常规搬运 叉车专用
        /// </summary>
        public string sceneTyp { get; set; }
        /// <summary>
        /// 容器类型 叉车专用
        /// </summary>
        public string ctnrTyp { get; set; }
        /// <summary>
        /// 容器编号 叉车专用
        /// </summary>
        public string ctnrCode { get; set; }
    }
    public class PositionCodePath 
    {
        /// <summary>
        /// 位置编号 单个编号不超过64位 必填 实际传仓位码 仅适用于打包站
        /// </summary>
        public string positionCodePath { get; set; }
        /// <summary>
        /// 位置类型 00：位置编号 01：物料批次号 02：策略编号 此处默认05
        /// </summary>
        public string type { get; set; }
    }
}
