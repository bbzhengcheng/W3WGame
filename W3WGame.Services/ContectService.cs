using System.Web;

namespace W3WGame.Services
{
    public class ContectService
    {
        public static string CreateAliHtml(string id)
        {
            const string str = "<a target=\"_blank\" href=\"http://amos.im.alisoft.com/msg.aw?v=2&uid={0}&site=cntaobao&s=1&charset=utf-8\" >"
                               +
                               "<img border=\"0\" src=\"http://amos.im.alisoft.com/online.aw?v=2&uid={0}&site=cntaobao&s=1&charset=utf-8\" alt=\"点击这里给我发消息\" /></a>";
            return string.Format(str, HttpUtility.UrlEncode(id));
        }

        public static string CreateQQHtml(string id)
        {
            const string str =
                "<a target=\"_blank\" href=\"http://wpa.qq.com/msgrd?v=3&uin={0}&site=qq&menu=yes\">" +
                "<img border=\"0\" src=\"http://wpa.qq.com/pa?p=2:{0}:41\" alt=\"点击这里给我发消息\" title=\"点击这里给我发消息\"></a>";
            return string.Format(str, id);
        }

    }
}