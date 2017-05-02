using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HtmlAgilityPack;
using System.Web.Script.Serialization;//关键dll

namespace MyBlogByMVC.Common
{
    public class Common
    {
        /// <summary>
        /// 字符串MD5加密
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string StrToMD5Str(string str)
        {
            string retValue = string.Empty;
            System.Security.Cryptography.MD5CryptoServiceProvider md5 = new System.Security.Cryptography.MD5CryptoServiceProvider();
            byte[] returnByte = md5.ComputeHash(System.Text.Encoding.Unicode.GetBytes(str));
            for (int i = 0; i < returnByte.Length; i++)
            {
                retValue += returnByte[i].ToString("X2");
            }
            return retValue.ToUpper();
        }

        /// <summary>
        /// 移除html中标签,保留文字
        /// </summary>
        /// <param name="content"></param>
        /// <returns></returns>
        public static string RemoveTag(string content)
        {
            HtmlDocument doc = new HtmlDocument();//初始化类
            doc.LoadHtml(content);//读取文本
            return doc.DocumentNode.InnerText.Replace("&nbsp;", "").Trim();//提取html中的文本,移除空格
        }
        /// <summary>
        /// 泛型方法 指定的模型转换成json格式的数据
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="t"></param>
        /// <returns></returns>
        public static string ModelToJson(object obj)
        {
            JavaScriptSerializer js = new JavaScriptSerializer();
            return js.Serialize(obj);
        }
    }
}