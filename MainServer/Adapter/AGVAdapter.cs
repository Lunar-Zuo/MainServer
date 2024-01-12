using MainServer.Entities;
using MainServer.Helper;
using Newtonsoft.Json;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace MainServer.Adapter
{
    /// <summary>
    /// AGV交互模块
    /// </summary>
    public class AGVAdapter : HttpHelper
    {
        public static AGVAdapter Instance = new AGVAdapter();
        private static readonly string _genAgvSchedulingTaskURL = $"/rcms/services/rest/hikRpcService/genAgvSchedulingTask";
        private static readonly string _continueAGVTaskURL = $"/rcms/services/rest/hikRpcService/continueTask";
        private static readonly string _cancelAGVTaskURL = $"/rcms/services/rest/hikRpcService/cancelTask";

        public static ConcurrentDictionary<string, AGVResEntity> ReqCodeList = new ConcurrentDictionary<string, AGVResEntity>();

        public delegate void GenAgvSchedulingDelegate(string str);
        public event GenAgvSchedulingDelegate GenAgvSchedulingHandler;
        /// <summary>
        /// AGV初始化动作
        /// </summary>
        public void init(string url)
        {
            //同步地图数据或

        }
        /// <summary>
        /// 生成任务单
        /// </summary>
        /// <param name="request">请求参数</param>
        /// <returns></returns>
        public void GenAgvSchedulingTaskAsync(string url, AGVRequestEntity request)
        {
            try
            {
                string Url = url + _genAgvSchedulingTaskURL;
                //创建应答接收管理
                Dictionary<string, object> body = new Dictionary<string, object>();
                body["reqCode"] = request.reqCode;
                string data = JsonConvert.SerializeObject(body);

                var res = SendMessageToRCS2000(Url, data).Result;
                
                AGVResEntity resData = JsonConvert.DeserializeObject<AGVResEntity>(res);

                GenAgvSchedulingHandler?.Invoke(resData.ToString());
            }
            catch (Exception ex)
            {
                LoggerHelper.Error($"生成任务{request.reqCode}异常：" + ex.Message);
            }
        }
        /// <summary>
        /// 地图位置信息同步
        /// </summary>
        /// <param name="url"></param>
        /// <param name="request"></param>
        /// <returns></returns>
        public string syncMapData(string url, AGVMapEntity request)
        {
            try
            {
                Dictionary<string, object> body = new Dictionary<string, object>();
                body["reqCode"] = request.reqCode;
                string data = JsonConvert.SerializeObject(body);
                string responseStr = SendMessageToRCS2000(url, 3000, data);

                return responseStr;
            }
            catch
            {
                return null;
            }

        }

    }
}
