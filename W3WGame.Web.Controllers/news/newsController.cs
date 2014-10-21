using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using System.Xml.Linq;
using W3WGame.Core.Dtos.Web;
using W3WGame.Core.Entities;
using W3WGame.Core.Enums;
using W3WGame.Task;
using WangFramework.MvcPager;

namespace W3WGame.Web.Controllers.news
{
    public class newsController:BaseController
    {
        private readonly ADConfigTask _adConfigTask = new ADConfigTask();
        private readonly MobilGameTask _mobilGameTask = new MobilGameTask();

        private readonly GameServersTask _gameServersTask = new GameServersTask();
        private readonly GameKaTask _gameKaTask = new GameKaTask();
        private readonly GameNewsTask _gameNewsTask = new GameNewsTask();

        public ActionResult index(int? tid,int pageindex=1,int pagesize=10)
        {
            ViewData["adinfo"] = _adConfigTask.GetListBy((int) ADConfigPlaceEnum.PlatformNewsRight).FirstOrDefault();
            ViewData["adinfoactive"] = _adConfigTask.GetListBy((int)ADConfigPlaceEnum.PlatformNewsRightActive).FirstOrDefault();
            ViewData["gameinfolist"] = _mobilGameTask.GetAll(10,"");
            ViewData["newlist"] = _gameNewsTask.GetAll(15,  " NewsType = 2");
       
            var pagedList = _gameNewsTask.GetPagedList(null, tid, null, null, pageindex, pagesize);

            var model = new PagedList<GameNews>(pagedList.ToList(), pageindex, pagesize, pagedList.TotalItemCount);
            return View(model);
        }
    }
}
