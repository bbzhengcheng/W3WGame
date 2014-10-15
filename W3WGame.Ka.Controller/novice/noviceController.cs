using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using System.Xml.Linq;
using W3WGame.Core.Dtos.Web;
using W3WGame.Core.Enums;
using W3WGame.Task;
using WangFramework.MvcPager;


namespace W3WGame.Ka.Controller.novice
{
    public class noviceController:BaseController
    {
        private readonly GameKaTask _gameKaTask = new GameKaTask();
        private readonly GameKaDetailTask _gameKaDetailTask = new GameKaDetailTask();
        public ActionResult index(string title,int pageindex=1,int pagesize=20)
        {
            var list = _gameKaTask.GetKaPagedList(title, (int)KaTypeEnum.NewCard, pageindex, pagesize);
            var model = new PagedList<NewsKaDto>(list.ToList(), pageindex,pagesize, list.TotalItemCount);
            ViewData["randlist"] = _gameKaTask.GetRanKa((int) KaTypeEnum.SpecialCard, 10);
            return View(model);
        }
    }
}
