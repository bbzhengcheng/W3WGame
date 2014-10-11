using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using System.Xml.Linq;
using W3WGame.Core.Dtos.Web;
using W3WGame.Core.Enums;
using W3WGame.Task;

namespace W3WGame.Web.Controllers.download
{
    public class downloadController:BaseController
    {
        private readonly MobilGameTask _mobilGameTask = new MobilGameTask();
        private readonly GameDownloadUrlsTask _gameDownloadUrlsTask = new GameDownloadUrlsTask();

        public ActionResult index(int gameid,int sysid)
        {
            var model = _gameDownloadUrlsTask.GetById(gameid, sysid);
            if(model ==null || string.IsNullOrEmpty(model.DownloadUrl))
            {
                return new EmptyResult();
            }
            return Redirect(model.DownloadUrl);
        }


    }
}
