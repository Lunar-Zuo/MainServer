using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using log4net;
using log4net.Config;

namespace MainServer.Helper
{
    public class LoggerHelper
    {
        public static void Init(string fileName) 
        {
            var logCfg = new FileInfo(AppDomain.CurrentDomain.BaseDirectory + fileName);
            XmlConfigurator.Configure(logCfg);
        }
        /// <summary>
        /// 消息
        /// </summary>
        /// <param name="msg"></param>
        public static void Info(string msg) 
        {
            StackTrace trace = new StackTrace();
            //获取是哪个类来调用的
            var type = trace.GetFrame(1).GetMethod().DeclaringType;
            //获取是类中的那个方法调用的
            string method = trace.GetFrame(1).GetMethod().Name;

            var logger = LogManager.GetLogger(type+"."+method);
            logger.Info(msg);
        }
        /// <summary>
        /// 警告
        /// </summary>
        /// <param name="msg"></param>
        public static void Warn(string msg) 
        {
            StackTrace trace = new StackTrace();
            //获取是哪个类来调用的
            var type = trace.GetFrame(1).GetMethod().DeclaringType;
            //获取是类中的那个方法调用的
            string method = trace.GetFrame(1).GetMethod().Name;

            var logger = LogManager.GetLogger(type + "." + method);
            logger.Warn(msg);
        }
        /// <summary>
        /// 异常
        /// </summary>
        /// <param name="msg"></param>
        public static void Error(string msg) 
        {
            StackTrace trace = new StackTrace();
            //获取是哪个类来调用的
            var type = trace.GetFrame(1).GetMethod().DeclaringType;
            //获取是类中的那个方法调用的
            string method = trace.GetFrame(1).GetMethod().Name;

            var logger = LogManager.GetLogger(type + "." + method);
            logger.Error(msg);
        }
        /// <summary>
        /// 错误
        /// </summary>
        /// <param name="msg"></param>
        public static void Fatal(string msg) 
        {
            StackTrace trace = new StackTrace();
            //获取是哪个类来调用的
            var type = trace.GetFrame(1).GetMethod().DeclaringType;
            //获取是类中的那个方法调用的
            string method = trace.GetFrame(1).GetMethod().Name;

            var logger = LogManager.GetLogger(type + "." + method);
            logger.Fatal(msg);

        }

    }
}
