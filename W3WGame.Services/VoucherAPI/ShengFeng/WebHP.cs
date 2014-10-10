using System;
using System.Web;
using System.Text;
using System.Net;
using System.IO;

namespace W3WGame.Services.VoucherAPI.ShengFeng
{
    /// <summary>
    /// eft 帮助类
    /// </summary>
    public class WebHP
    {
        /// <summary>
        /// 获取客户端IP地址
        /// </summary>
        /// <returns></returns>
        public static string getClientIP()
        {
            string result = HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
            if (null == result || result == String.Empty)
            {
                result = HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"];
            }

            if (null == result || result == String.Empty)
            {
                result = HttpContext.Current.Request.UserHostAddress;
            }
            return result;

        }


        /// <summary>
        /// PostInfo 默认 utf-8 编码
        /// </summary>
        /// <param name="Url"></param>
        /// <param name="Pramers"></param>
        /// <returns>返回 ID+eftKey </returns>
        public static string PostInfo(string Url, string Pramers)
        {
            //Pramers = ConvertUtfUrlPram(Pramers);
            string postUrl = Url + "?" + Pramers;

            HttpWebRequest hwrq = (HttpWebRequest)WebRequest.Create(postUrl);
            //下面是相关数据头和数据发送方法
            hwrq.Accept = "application/x-shockwave-flash, image/gif, image/x-xbitmap, image/jpeg, image/pjpeg, application/vnd.ms-excel, application/vnd.ms-powerpoint, application/msword, */*";
            hwrq.Referer = postUrl;
            hwrq.ContentType = "application/x-www-form-urlencoded";
            hwrq.UserAgent = "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.1; SV1; .NET CLR 2.0.50727; MAXTHON 2.0)";
            hwrq.KeepAlive = true;
            hwrq.Method = "POST";

            //////////////////////////////////////////////////////////////////////////

            //使用MiniSniffer来抓包分析应该发送什么数据

            ASCIIEncoding ASC2E = new ASCIIEncoding();
            byte[] bytePost = ASC2E.GetBytes(Pramers);
            hwrq.ContentLength = bytePost.Length;

            //下面是发送数据的字节流
            Stream MyStream = hwrq.GetRequestStream();
            MyStream.Write(bytePost, 0, bytePost.Length);
            MyStream.Close();

            //创建HttpWebResponse实例
            HttpWebResponse hwrp = (HttpWebResponse)hwrq.GetResponse();
            StreamReader MyStreamR = new StreamReader(hwrp.GetResponseStream(), Encoding.GetEncoding("utf-8"));

            string result = MyStreamR.ReadToEnd();
            //////////////////////////////////////////////////////////////////////////
            // Response.Write(result + "<br><br>");
            return result;

        }

        /// <summary>
        /// 转换参数为gb2312 url格式
        /// </summary>
        /// <param name="Pramers"></param>
        /// <returns></returns>
        public static string ConvertGBUrlPram(string Pram)
        {
            Encoding myEncoding = Encoding.GetEncoding("gb2312");
            Pram = HttpUtility.UrlEncode(Pram, myEncoding);
            return Pram;
        }
        /// <summary>
        /// 转换参数为 url格式
        /// utf-8
        /// </summary>
        /// <param name="Pramers"></param>
        /// <returns></returns>
        public static string ConvertUtfUrlPram(string Pram)
        {
            Encoding myEncoding = Encoding.GetEncoding("utf-8");
            Pram = HttpUtility.UrlEncode(Pram, myEncoding);
            return Pram;
        }


    }
}
