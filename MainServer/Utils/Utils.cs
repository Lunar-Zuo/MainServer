using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MainServer.Commons;
using MainServer.Entities;

namespace MainServer.Utils
{
    public class Utils
    {
        public static int TickDuration(DateTime dateBegin, DateTime dateEnd)
        {
            TimeSpan t1 = new TimeSpan(dateBegin.Ticks);
            TimeSpan t2 = new TimeSpan(dateEnd.Ticks);
            TimeSpan t3 = t1.Subtract(t2).Duration();
            return (int)t3.TotalMilliseconds;
        }

        #region 解析网络包，获取数据内容
        //public static T ParseResponse<T>(string data)
        //{
        //    Console.WriteLine(data);
        //    ResponseEntity resp = JsonConvert.DeserializeObject<ResponseEntity>(data);
        //    if (resp.Code != 0) throw new Exception(resp.Message);
        //    return JsonConvert.DeserializeObject<T>(resp.Data.ToString());
        //}

        public static T JsonDecode<T>(string data)
        {
            return JsonConvert.DeserializeObject<T>(data);
        }
        #endregion


        public static void ConvertIntToShorts(int original, ref short low, ref short high)
        {
            high = (short)(original >> 16);
            low = (short)(original & 0xffff);
        }

        public static void ConvertShortsToInt(ref int value, short low, short high)
        {
            value = (high << 16) | (low & 0xffff);
        }

        public static int UnixTimeNow()
        {
            var timeSpan = (DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0));
            return (int)timeSpan.TotalSeconds;
        }

        public static string ConvertShortsToString(short[] data)
        {
            byte[] buf = new byte[data.Length * 2];
            int i = 0;
            foreach (var val in data)
            {
                int t = val;
                buf[i] = Convert.ToByte(t & 0xff);
                buf[i + 1] = Convert.ToByte(t >> 8);
                i += 2;
            }
            string str = Encoding.Default.GetString(buf);
            str = str.Replace("\0", "");
            return str.Replace(" ", "");
        }
        public static short[] ConvertStringToShorts(string data,int length)
        {
            //if (data.Length > (length*2))
                //throw new RException(AlarmCode.AlarmCodeLengthOverflow, "数据超出最长限制");

            short[] res = new short[length];
            byte[] buffer = Encoding.Default.GetBytes(data);

            short val = 0;
            bool first = true;
            int cnt = 0;
            for (int i = 0; i < buffer.Length; i++)
            {
                if (first)
                {
                    val = buffer[i];
                    first = false;
                }
                else
                {
                    short t = (short)(buffer[i] << 8);
                    val = (short)(val | t);
                    res[cnt] = val;
                    cnt++;
                    first = true;
                }
            }

            if (!first)
            {
                res[cnt] = val;
            }

            return res;
        }

    }
}
