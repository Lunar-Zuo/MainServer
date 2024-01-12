using Fleck;
using MainServer.Entities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainServer.Helper
{
    public class WsServerHelper
    {
        IDictionary<int,IWebSocketConnection> dic_Sockets = new Dictionary<int,IWebSocketConnection>();

        public void SendMessageToClient(int id, string cmd, object data) 
        {
            IWebSocketConnection webSocketConnection = GetUserSocketInstance(id);
            if (webSocketConnection != null)
            {
                if (webSocketConnection.IsAvailable)
                {
                    Dictionary<string, object> body = new Dictionary<string, object>();
                    body.Add("progId", id);
                    body.Add("command", cmd);
                    body.Add("data", data);
                    string massage = JsonConvert.SerializeObject(body);
                    webSocketConnection.Send(massage);
                }
            }
        }
        /// <summary>
        /// 获取用户实例
        /// </summary>
        /// <param name="id">内部定义程序ID</param>
        public IWebSocketConnection GetUserSocketInstance(int id)
        {
            if (dic_Sockets.ContainsKey(id))
                return dic_Sockets[id];
            else
                return null;
        }
        public void StartServer(int port) 
        {
            //FleckLog.Level = LogLevel.Debug;
            var server = new WebSocketServer("ws://0.0.0.0:" + port);
            //出错后进行重启
            server.RestartAfterListenError = true;

            //开始监听
            server.Start(socket =>
            {
                //连接建立事件
                socket.OnOpen = () =>
                {
                    LoggerHelper.Info($"连接  接收到消息:{socket.ConnectionInfo.ClientIpAddress}:{socket.ConnectionInfo.ClientPort}");
                };

                //连接关闭事件
                socket.OnClose = () =>
                {
                    LoggerHelper.Info($"关闭 接收到消息:{socket.ConnectionInfo.ClientIpAddress}:{socket.ConnectionInfo.ClientPort}");
                };

                //接受客户端网页消息事件
                socket.OnMessage = message =>
                {
                    //LoggerHelper.Info($"接收到消息:{message}");
                    MessageEntity messages = JsonConvert.DeserializeObject<MessageEntity>(message);
                    if (messages.command == "register")
                    {
                        dic_Sockets.Add(messages.progId, socket);
                        OnClientConnected(messages.progId);//连接
                    }
                    else if (messages.command == "")
                    {
                        dic_Sockets.Remove(messages.progId);
                        OnClientDisconnected(messages.progId);//连接关闭
                    }
                    else
                    {
                        OnMessageRecv(messages.progId, messages.command, messages.data);
                    }
                };
            });
        }
        public void StopServer() { }
        protected virtual void OnClientConnected(int id) { }
        protected virtual void OnClientDisconnected(int id) { }
        protected virtual void OnMessageRecv(int id, string cmd, object data) { }
    }
}
