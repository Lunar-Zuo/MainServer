using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainServer.Entities
{
    public class PanelInspectEntity
    {
        private object _lock = new object();

        public string SerialNumber { get; set; }
        /// <summary>
        /// 存图路径
        /// </summary>
        public string RelativePath { get; set; }

        public string PanelCode { get; set; }

        public int Recipe { get; set; }

        public int iJudge = 0;
        public int Judge
        {
            get { return iJudge; }
            set { lock (_lock) { if (value > iJudge) iJudge = value; } }
        }
        public int Grade { get; set; }
        /// <summary>
        /// 统计缺陷类型
        /// </summary>
        public string DefectIds { get; set; }
    }
}
