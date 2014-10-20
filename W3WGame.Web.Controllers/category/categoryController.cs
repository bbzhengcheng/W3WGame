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
using WangFramework.Extensions;
using WangFramework.MvcPager;


namespace W3WGame.Web.Controllers.category
{
    public class categoryController:BaseController
    {
        private readonly MobilGameTask _mobilGameTask = new MobilGameTask();
        public ActionResult index(int? gamesys, bool? hasGift,
             bool? isHot, bool? isNew, bool? IsBiWan, bool? isThisAweekHot, bool? isTuiJian, int? gameType, int? gameTeZhen, int? yunyingState, bool? isQianLiBao, bool? isGameType,
             int pageIndex=1, int pageSize=25)
        {
            ViewData["gamesyslist"] = GameSysEnum.Andior.ToSelectList();
            ViewData["gametypelist"] = GameTypeEnum.CeLve.ToSelectList();
            ViewData["gameTeZhenlist"] = GameTeZhenEnum.JiShi.ToSelectList();
            ViewData["yunyingStatelist"] = YunYingStateEnum.FengCe.ToSelectList();
            //Session["gamesys"] = gamesys;
            //Session["gameType"] = gameType;
            //Session["gameTeZhen"] = gameTeZhen;
            //Session["yunyingState"] = yunyingState;

            var list = _mobilGameTask.GetPagedList(gamesys, hasGift,
                                                   isHot, isNew, IsBiWan, isThisAweekHot, isTuiJian, gameType,
                                                   gameTeZhen, yunyingState, isQianLiBao, isGameType,
                                                   pageIndex, pageSize);
            var model = new PagedList<MobilGame>(list.ToList(), pageIndex, pageSize, list.TotalItemCount);
            return View(model);
        }

    }
}
