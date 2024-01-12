using Newtonsoft.Json;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MainServer.Commons;
using MainServer.Entities;
using MainServer.Helper;

namespace MainServer.Adapter
{
    /// <summary>
    /// 主从通信模块
    /// </summary>
    public class MessageAdapter : WsServerHelper
    {
        public delegate void ProgramAliveStatusDelegate(int programId, int status, int munber);//munber:1代表程序异常，2代表硬件异常
        public delegate void UpdateParamsDelegate(UpdataParamsEntity updataParams);
        public delegate void CarCallingDelegate(CarCallingEntity carCalling);

        public event ProgramAliveStatusDelegate ProgramAliveStatusHandler;
        public event UpdateParamsDelegate UpdateParamsHandler;
        public event CarCallingDelegate CarCallingHandler;

        private ConcurrentDictionary<int, ClientAdapter> ClientList = new ConcurrentDictionary<int, ClientAdapter>();
        private ConcurrentDictionary<int, int> CameraStatus = new ConcurrentDictionary<int, int>();
        private ConcurrentDictionary<string, string> ResList = new ConcurrentDictionary<string, string>();

        public void Init(int port)
        {
            StartServer(port);
        }

        public void UnInit()
        {
            StopServer();
        }
        /// <summary>
        /// 长边检测开始（检测程序1#）
        /// </summary>
        /// <param name="serialNumber"></param>
        /// <param name="panelId"></param>
        /// <param name="recipe"></param>
        /// <param name="relaPath"></param>
        public void InspectStartL(string serialNumber, string panelId, int recipe, string relaPath)
        {
            //发送信息
            Dictionary<string, object> body = new Dictionary<string, object>();
            body["serialNumber"] = serialNumber;
            body["panelId"] = panelId;
            body["recipe"] = recipe;
            body["path"] = relaPath;
            string data = JsonConvert.SerializeObject(body);
            //if (ClientList.ContainsKey(ProgramConstant.PID_Inerface_2)) SendMessageToClient(ProgramConstant.PID_Inerface_2, WsCmdName.WsCmdInspectStart, data);

        }
        /// <summary>
        /// 服务终止
        /// </summary>
        /// <param name="serialNumber"></param>
        public void InspectTerminate(string serialNumber)
        {
            Dictionary<string, object> body = new Dictionary<string, object>();
            body["serialNumber"] = serialNumber;
            string data = JsonConvert.SerializeObject(body);
            //if (ClientList.ContainsKey(ProgramConstant.PID_Inerface_1)) SendMessageToClient(ProgramConstant.PID_Inerface_1, WsCmdName.WsCmdInspectTerminate, data);
            //if (ClientList.ContainsKey(ProgramConstant.PID_Inerface_2)) SendMessageToClient(ProgramConstant.PID_Inerface_2, WsCmdName.WsCmdInspectTerminate, data);
        }

        /// <summary>
        /// 数据更新应答
        /// </summary>
        public void UpdateParamsRes(int errcode)
        {
            //信息
            Dictionary<string, object> body = new Dictionary<string, object>();
            body.Add("errCode", errcode);
            string data = JsonConvert.SerializeObject(body);
            //发送
            //if (ClientList.ContainsKey(ProgramConstant.PID_Inerface_1)) SendMessageToClient(ProgramConstant.PID_Inerface_1, WsCmdName.WsCmdUpdateParamsRes, data);
            //if (ClientList.ContainsKey(ProgramConstant.PID_Inerface_2)) SendMessageToClient(ProgramConstant.PID_Inerface_2, WsCmdName.WsCmdUpdateParamsRes, data);
        }

        /// <summary>
        /// Client连接成功
        /// </summary>
        /// <param name="id"></param>
        protected override void OnClientConnected(int id)
        {
            try
            {
                ClientAdapter client = new ClientAdapter();
                client.Timeout = 20 * 1000;//20S超时
                client.ClientHbTimeoutHandler += OnClientTimeout;
                client.Start(id);
                ClientList.TryAdd(id, client);
                ProgramAliveStatusHandler?.Invoke(id, 1, 1);
            }
            catch (Exception ex)
            {
                LoggerHelper.Warn(string.Format("从进程连接成功处理异常，{0}", ex.Message));
            }
        }

        /// <summary>
        /// Client连接断开
        /// </summary>
        /// <param name="id"></param>
        protected override void OnClientDisconnected(int id)
        {
            ProgramAliveStatusHandler?.Invoke(id, 0, 1);
            if (id == ProgramConstant.PID_Inerface_2)//长边检测端
            {
                for (int i = 1; i <= 6; i++)
                {
                    CameraStatus.TryUpdate(i, 0, 1);
                    ProgramAliveStatusHandler.Invoke(i, 0, 2);
                }
            }
            else
            {
                for (int i = 7; i <= 10; i++)
                {
                    CameraStatus.TryUpdate(i, 0, 1);
                    ProgramAliveStatusHandler.Invoke(i, 0, 2);
                }
            }


            ClientAdapter client;
            if (ClientList.TryRemove(id, out client))
            {
                client.Stop();
            }
        }

        protected override void OnMessageRecv(int id, string cmd, object data)
        {
            switch (cmd)
            {
                case "carCalling":
                    OnCarCalling(id, data);
                    break;
                default:
                    break;
            }
        }

        #region 心跳处理
        private async void OnHeartbeatAsync(int procId, object data)
        {
            await Task.Run(() =>
            {
                try
                {
                    ClientAdapter client;
                    if (ClientList.TryGetValue(procId, out client))
                    {
                        //子进程心跳时间更新
                        client.UpdateTick();
                    }

                    switch (procId)
                    {
                        case ProgramConstant.PID_Inerface_1:
                        case ProgramConstant.PID_Inerface_2:
                            OnInspectDeviceStatus(data);
                            break;
                    }
                }
                catch (Exception ex)
                {
                    LoggerHelper.Error(string.Format("心跳处理异常，procId={0}, {1}", procId, ex.Message));
                }
            });
        }
        private void OnInspectDeviceStatus(object data)
        {
            //DeviceStatusEntity entity = JsonConvert.DeserializeObject<DeviceStatusEntity>(data.ToString());
            //if (entity.Name != null)
            //{
            //        ProgramAliveStatusHandler.Invoke(1, 1, 2);
                
            //}
        }
        #endregion

        #region 数据更新
        private async void OnUpdateParams(int procId, object data)
        {
            await Task.Run(() =>
            {
                try
                {
                    UpdataParamsEntity entity = JsonConvert.DeserializeObject<UpdataParamsEntity>(data.ToString());
                    UpdateParamsHandler?.Invoke(entity);
                }
                catch (Exception ex)
                {
                    LoggerHelper.Error(string.Format("数据更新应答处理异常，procId={0}, {1}", procId, ex.Message));
                }
            });
        }
        #endregion

        #region 手动叫车
        private async void OnCarCalling(int procId, object data)
        {
            await Task.Run(() =>
            {
                try
                {
                    CarCallingEntity entity = JsonConvert.DeserializeObject<CarCallingEntity>(data.ToString());
                    CarCallingHandler?.Invoke(entity);
                    
                }
                catch (Exception ex)
                {
                    LoggerHelper.Error(string.Format("数据更新应答处理异常，procId={0}, {1}", procId, ex.Message));
                }
            });
        }
        #endregion

        /// <summary>
        /// 客户端心跳超时回调
        /// </summary>
        /// <param name="id"></param>
        private void OnClientTimeout(int id)
        {
            //进程心跳超时
            ProgramAliveStatusHandler?.Invoke(id, 0, 1);
            if (id == ProgramConstant.PID_Inerface_2)//长边检测端
            {
                for (int i = 1; i <= 6; i++)
                {
                    CameraStatus.TryUpdate(i, 0, 1);
                    ProgramAliveStatusHandler.Invoke(i, 0, 2);
                }
            }
            else
            {
                for (int i = 7; i <= 10; i++)
                {
                    CameraStatus.TryUpdate(i, 0, 1);
                    ProgramAliveStatusHandler.Invoke(i, 0, 2);
                }
            }

        }

    }
}
