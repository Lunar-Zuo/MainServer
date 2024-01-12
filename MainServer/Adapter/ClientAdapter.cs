using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainServer.Adapter
{
    /// <summary>
    /// 从进程对象
    /// </summary>
    public class ClientAdapter
    {
        public delegate void ClientHbTimeoutDelegate(int id);
        public event ClientHbTimeoutDelegate ClientHbTimeoutHandler;

        public int ProgramId { get; set; }
        /// <summary>
        /// 超时时间
        /// </summary>
        public int Timeout { get; set; }
        private DateTime lastTick;
        private bool bTriggered = false;
        private object obj = new object();
        private System.Threading.Timer timer;

        public void Start(int id)
        {
            ProgramId = id;
            UpdateTick();
            timer = new System.Threading.Timer(OnHeartbeatMonitor, "", 1000, 2000);
        }

        public void Stop()
        {
            try
            {
                timer.Dispose();
            }
            catch (Exception) { }
        }

        public void UpdateTick()
        {
            lastTick = DateTime.Now;
            bTriggered = false;
        }

        private void OnHeartbeatMonitor(object state)
        {
            try
            {
                //if (TimeUtils.IsTimeout(lastTick, DateTime.Now, Timeout))
                //{
                //    if (!bTriggered)
                //    {
                //        bTriggered = true;
                //        ClientHbTimeoutHandler?.Invoke(ProgramId);
                //    }
                //}
            }
            catch (Exception) { }

        }
    }
}
