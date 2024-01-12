using MainServer.Entities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MainServer.Helper
{
    /// <summary>
    /// 
    /// </summary>
    public class HttpHelper
    {
        #region Client
        /// <summary>
        /// 通过web api获取数据的方法
        /// </summary>
        /// <param name="url">api的url</param>
        /// <param name="method">请求类型,默认是get</param>
        /// <param name="postData">post请求所携带的数据</param>
        /// <returns></returns>
        public static string RequestData(string url, string method = "Get", string postData = null)
        {
            try
            {
                method = method.ToUpper();
                //设置安全通信协议   服务器有些强制使用tls1.2的安全通信协议,所以至少包含SecurityProtocolType.Tls12   如果沒有SecurityProtocolType.Tls12设置会报错:HttpWebRequest底层连接已关闭:传送时发生意外错误  
                ServicePointManager.SecurityProtocol =
                    SecurityProtocolType.Ssl3 | SecurityProtocolType.Tls |
                    SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;

                //创建请求实例
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);

                //设置请求类型
                request.Method = method;
                //设置请求消息主体的编码方法
                request.ContentType = "application/json";

                //POST方式處理
                if (method == "POST")
                {
                    //用UTF8字符集对post请求携带的数据进行编码,可防止中文乱码
                    byte[] byteArray = Encoding.UTF8.GetBytes(postData);
                    //指定客户端post请求携带的数据的长度
                    request.ContentLength = byteArray.Length;

                    //创建一个tream,用于写入post请求所携带的数据(该数据写入了请求体)
                    Stream stream = request.GetRequestStream();
                    stream.Write(byteArray, 0, byteArray.Length);
                    stream.Close();
                }

                //获取请求的响应实例
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                //获取读取流实体,用来以UTF8字符集读取响应流中的数据
                StreamReader myStreamReader = new StreamReader(response.GetResponseStream(), Encoding.UTF8);
                //进行数据读取
                string retString = myStreamReader.ReadToEnd();
                myStreamReader.Close();
                return retString;
            }
            catch (Exception ex)
            {
                return "{\"code\":\"0\",\"message\":\"" + ex.Message + "\"}";
            }
        }

        public static async Task<string> APIPost(string url, string data)
        {
            string result = string.Empty;
            //设置HttpClientHandler的AutomaticDecompression
            var handler = new HttpClientHandler() { AutomaticDecompression = DecompressionMethods.GZip };
            //创建HttpClient（注意传入HttpClientHandler）
            using (var http = new HttpClient(handler))
            {
                //使用FormUrlEncodedContent做HttpContent
                var content = new FormUrlEncodedContent(new Dictionary<string, string>()
                {
                    //传递单个值
                    {"", data}//键名必须为空
                    //传递对象
                    //{"name","hello"},
                    //{"age","16"}
                 });

                //await异步等待回应
                var response = await http.PostAsync(url, content);
                //确保HTTP成功状态值
                response.EnsureSuccessStatusCode();
                //await异步读取最后的JSON（注意此时gzip已经被自动解压缩了，因为上面的AutomaticDecompression = DecompressionMethods.GZip）
                result = await response.Content.ReadAsStringAsync();
            }
            return result;
        }
        public static async void APIGet(string url)
        {
            //创建HttpClient（注意传入HttpClientHandler）
            var handler = new HttpClientHandler() { AutomaticDecompression = DecompressionMethods.GZip };

            using (var http = new HttpClient(handler))
            {
                //await异步等待回应
                var response = await http.GetAsync(url);
                //确保HTTP成功状态值
                response.EnsureSuccessStatusCode();

                //await异步读取最后的JSON（注意此时gzip已经被自动解压缩了，因为上面的AutomaticDecompression = DecompressionMethods.GZip）
                Console.WriteLine(await response.Content.ReadAsStringAsync());
            }
        }
        public static int HttpGet(string url, out string reslut)
        {
            reslut = "";
            try
            {
                HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create(url);
                webRequest.Proxy = null;
                webRequest.Method = "GET";
                HttpWebResponse webResponse = (HttpWebResponse)webRequest.GetResponse();
                using (Stream responseStream = webResponse.GetResponseStream())
                {
                    using (StreamReader sReader = new StreamReader(responseStream))
                    {
                        reslut = sReader.ReadToEnd();
                    }
                }
            }
            catch (Exception ex)
            {
                reslut = ex.Message;
                return -1;
            }
            return 0;
        }
        public static int HttpPost(string url, string sendData, out string reslut)
        {
            reslut = "";
            try
            {
                byte[] data = System.Text.Encoding.UTF8.GetBytes(sendData);
                HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create(url);
                webRequest.Proxy = null;
                webRequest.Method = "POST";
                webRequest.ContentType = "application/json";
                webRequest.ContentLength = data.Length;

                #region 获得请求流
                //Stream newStream = webRequest.GetRequestStream();
                //newStream.Write(data, 0, data.Length);
                //newStream.Close();
                //newStream.Dispose();
                #endregion


                #region 将创建Stream流对象的过程写在Using当中，会自动的帮助我们释放占用的资源
                using (Stream wStream = webRequest.GetRequestStream())
                {
                    wStream.Write(data, 0, data.Length);
                }
                #endregion
                //获取响应
                HttpWebResponse webResponse = (HttpWebResponse)webRequest.GetResponse();
                using (Stream responseStream = webResponse.GetResponseStream())
                {
                    using (StreamReader sReader = new StreamReader(responseStream))
                    {
                        reslut = sReader.ReadToEnd();
                    }
                }
            }
            catch (Exception ex)
            {
                reslut = ex.Message;
                return -1;
            }
            return 0;
        }

        public async Task<string> SendMessageToRCS2000(string URL, object Obj)
        {
            var json = JsonConvert.SerializeObject(Obj);
            var data = new StringContent(json, Encoding.UTF8, "application/json");
            using (var client = new HttpClient())
            {
                try
                {
                    var response = await client.PostAsync(URL, data);
                    var result = await response.Content.ReadAsStringAsync();
                    return result;
                }
                catch (Exception ex)
                {
                    LoggerHelper.Error(string.Format("HTTP访问错误，或许url错误！", ex.Message));
                }
                return $"{{\"code\":\"1\",\"message\":\"HTTP访问错误，url（{URL}）或许错误！\"}}";

            }
        }
        /// <summary>
        /// AGV命令发送 POST
        /// </summary>
        /// <param name="url">地址</param>
        /// <param name="time">返回超时 时间</param>
        /// <param name="body">发送数据</param>
        /// <returns></returns>
        public string SendMessageToRCS2000(string url, int time, string body)
        {
            try
            {
                byte[] data = System.Text.Encoding.UTF8.GetBytes(body);
                HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create(url);
                webRequest.Proxy = null;
                webRequest.Method = "POST";
                webRequest.Accept = "text/html,application/xhtml+xml,*/*";
                webRequest.ContentType = "application/json";
                webRequest.ContentLength = data.Length;
                webRequest.Timeout = time;

                //将创建Stream流对象的过程写在Using当中，会自动的帮助我们释放占用的资源
                using (Stream wStream = webRequest.GetRequestStream())
                {
                    wStream.Write(data, 0, data.Length);
                }
                //获取响应
                HttpWebResponse webResponse = (HttpWebResponse)webRequest.GetResponse();
                using (Stream responseStream = webResponse.GetResponseStream())
                {
                    using (StreamReader sReader = new StreamReader(responseStream))
                    {
                        return sReader.ReadToEnd();
                    }
                }
            }
            catch (Exception ex)
            {
                LoggerHelper.Error("SendMessageToRCS2000 异常" + ex.Message);
                return "";
            }
        }
        #endregion 

        #region Server
        private System.Net.HttpListener _listener = null;
        public bool startSta = false;
        public void Start(string ip, int port)
        {
            Stop();
            List<string> httpPrefixes = new List<string>();
            httpPrefixes.Add("http://" + ip + ":" + port + "/" + "agvCallbalk");
            new Thread(new ThreadStart(delegate
            {
                _listener = new HttpListener();
                while (true)
                {
                    try
                    {
                        _listener.AuthenticationSchemes = AuthenticationSchemes.Anonymous;
                        //_listener.Prefixes.Add(httpPrefixes0);
                        if (httpPrefixes != null)
                        {
                            foreach (string url in httpPrefixes)
                            {
                                _listener.Prefixes.Add(url);
                            }
                        }
                        _listener.Start();
                    }
                    catch 
                    {
                        startSta = false;
                        break;
                    }
                    int minThreadNum;
                    int portThreadNum;
                    int maxThreadNum;
                    ThreadPool.GetMaxThreads(out maxThreadNum, out portThreadNum);
                    ThreadPool.GetMinThreads(out minThreadNum, out portThreadNum);
                    try
                    {
                        while (true)
                        {
                            startSta = true;
                            //等待请求连接
                            //没有请求则GetContext 处于阻塞状态
                            HttpListenerContext ctx = _listener.GetContext();
                            ThreadPool.QueueUserWorkItem(new WaitCallback(TaskProc), ctx);
                        }
                    }
                    catch 
                    {
                        startSta = false;
                    }
                }

            }));

        }
        /// <summary>
        /// 停止
        /// </summary>
        public void Stop()
        {
            if (_listener != null)
            {
                _listener.Stop();
                _listener.Close();
                _listener = null;
            }
        }
        /// <summary>
        /// 任务进
        /// </summary>
        /// <param name="obj"></param>
        public void TaskProc(object obj) 
        {
            HttpListenerContext ctx = (HttpListenerContext)obj;
            try 
            {
                var url = ctx.Request.Url.AbsoluteUri;
                Stream stream = ctx.Request.InputStream;
                System.IO.StreamReader reader = new System.IO.StreamReader(stream, Encoding.UTF8);
                if (url.Contains("agvCallbalk")) 
                {
                    //客户端发送过来的数据
                    string body = reader.ReadToEnd();
                    //数据处理
                    var upRecord = Newtonsoft.Json.JsonConvert.DeserializeObject<string>(body);
                    if (upRecord != null) 
                    {
                    
                    }
                }
                stream.Close();
                ctx.Response.Close();
                ctx = null;
                
            }
            catch(Exception ex) 
            {
                LoggerHelper.Error("接收数据任务 异常：" + ex.Message);
            }
        }
        #endregion
    }
}
