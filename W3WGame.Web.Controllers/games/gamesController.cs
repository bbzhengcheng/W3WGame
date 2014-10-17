using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using System.Xml.Linq;
using W3WGame.Core.Entities;
using W3WGame.Core.Enums;
using W3WGame.Task;
using WangFramework.MvcPager;

namespace W3WGame.Web.Controllers.games
{
    public class gamesController : BaseController
    {
        private readonly ADConfigTask _adConfigTask = new ADConfigTask();
        private readonly MobilGameTask _mobilGameTask = new MobilGameTask();
        private readonly GameServersTask _gameServersTask = new GameServersTask();
        private readonly GameKaTask _gameKaTask = new GameKaTask();
        private readonly GameNewsTask _gameNewsTask = new GameNewsTask();
        private readonly FriendLinkTask _friendLinkTask = new FriendLinkTask();

        public ActionResult index(int gid)
        {
            ViewData["gameinfo"] = _mobilGameTask.GetById(gid);
            if (ViewData["gameinfo"] == null)
            {
                return RedirectToAction("index", "home");
            }
            //新闻列表
            var newlist = _gameNewsTask.GetGameNewsList(gid);
            ViewData["serverlist"] = _gameServersTask.GetAll(7, "GameID = " + id.ToString());
            ViewData["gamekalist"] = _gameKaTask.GetAll(7, "GameID = " + id.ToString());
            ViewData["friendlist"] = _friendLinkTask.GetAll();

            //广告图
            ViewData["GameLunBo"] = _adConfigTask.GetListBy((int)ADConfigPlaceEnum.GameLunBo);
            ViewData["GameBLook"] = _adConfigTask.GetListBy((int)ADConfigPlaceEnum.GameBLook);

            return View(newlist);
        }

        public ActionResult news(int gid, int? tid,int pageindex = 1,int pagesize = 20)
        {
            if(tid==null)
            {
                tid = 1;
            }
            ViewBag.Tid = tid;
            ViewData["gameinfo"] = _mobilGameTask.GetById(gid);
            if (ViewData["gameinfo"] == null)
            {
                return RedirectToAction("index", "home");
            }
            //新闻列表
            var pagedList = _gameNewsTask.GetPagedList(gid, tid, null, null, pageindex, pagesize);
            var model = new PagedList<GameNews>(pagedList.ToList(), pageindex, pagesize, pagedList.TotalItemCount);
      
          
            return View(model);
        }

        public ActionResult newinfo(int id)
        {
            var newsinfo = _gameNewsTask.GetById(id);

            return View(newsinfo);
        }
    }
}
