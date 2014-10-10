using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace W3WGame.Web.Controllers.ToolCode
{
    public static class WebHelper
    {
        //
        // GET: /WebHelper/
        private const string ImgDemoin = "http://localhost:2459";
        public static string GetImg(string imgpath)
        {
            return string.Format("{0}{1}", ImgDemoin, imgpath);
        }

    }
}
