using System.Text;
using System.Web.Mvc;
using W3WGame.Task;

namespace W3WGame.Services.ToolCode
{
    public static class WebHelper
    {
        //
        // GET: /WebHelper/
        private const string ImgDemoin = "http://localhost:2459";
        private readonly static MobilGameTask _mobilGameTask = new MobilGameTask();

        public static string GetImg(string imgpath)
        {
            return string.Format("{0}{1}", ImgDemoin, imgpath);
        }
        /// <summary>
        /// 显示多少个星
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        public static MvcHtmlString Start(int num)
        {
            StringBuilder sb = new StringBuilder("");
            for (int i = 0; i < num; i++)
            {
                sb.Append("<span class='good'></span>");
            }
            for (int i = 0; i < 5 - num; i++)
            {
                sb.Append("<span class='bad'></span>");
            }
           
            return new MvcHtmlString(sb.ToString());

        }

        public static string GetGameUrl(int gameid)
        {
            return string.Format("http://{0}.w3wgame.com", _mobilGameTask.GetById(gameid).Domain);
        }

        public static string GetGameNews(int id)
        {
            return string.Format("http://{0}.w3wgame.com/newinfo", id);
        }

    }
}
