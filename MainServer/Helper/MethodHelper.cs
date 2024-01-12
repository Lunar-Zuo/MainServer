using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainServer.Helper
{
    public class MethodHelper
    {
        public static MethodHelper Instance = new MethodHelper();
        //汉字的UNICODE编码范围是4e00-9fbb
        /// <summary>
        /// 判断是否有汉字，有true，无false
        /// </summary>
        /// <param name="chinese"></param>
        /// <returns></returns>
        public bool IsChineseByReg(string chinese) 
        {
            return System.Text.RegularExpressions.Regex.IsMatch(chinese, @"[\u4e00-\u9fbb]");
        }

    }
}
