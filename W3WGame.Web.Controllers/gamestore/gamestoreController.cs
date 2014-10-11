using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using System.Xml.Linq;
using W3WGame.Core.Dtos.Web;
using W3WGame.Core.Enums;
using W3WGame.Task;

namespace W3WGame.Web.Controllers.gamestore
{
    public class gamestoreController:BaseController
    {
        private readonly GameDownloadUrlsTask _gameDownloadUrlsTask = new GameDownloadUrlsTask();

        public ActionResult index()
        {
            var model = _gameDownloadUrlsTask.GetRandTop50();
            
            return View(model);
        }
    }
}
