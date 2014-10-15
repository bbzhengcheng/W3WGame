using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using System.Xml.Linq;
using W3WGame.Core.Enums;
using W3WGame.Task;

namespace W3WGame.Web.Controllers.kf
{
    public class kfController:BaseController
    {
        public GameServersTask _GameServersTask = new GameServersTask();
        public FriendLinkTask _FriendLinkTask = new FriendLinkTask();

        public ActionResult index()
        {
            //今天开服
            ViewData["todayserverlist"] = _GameServersTask.GetServerList(
                                                                 Convert.ToDateTime(
                                                                     DateTime.Now.ToString("yyyy-MM-dd 00:00:00")),
                                                                 Convert.ToDateTime(
                                                                     DateTime.Now.ToString("yyyy-MM-dd 23:59:59")),true);
            ViewData["willserverlist"] = _GameServersTask.GetServerList(
                                                                 Convert.ToDateTime(
                                                                     DateTime.Now.ToString("yyyy-MM-dd 23:59:59")),
                                                                null,true);
            ViewData["friendList"] = _FriendLinkTask.GetAll();
            return View();
        }
    }
}
