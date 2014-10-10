
using System;
using System.Linq;
using System.Web.Mvc;
using W3WGame.Core.Enums;
using W3WGame.Task;
using WangFramework.Mappers;
using WangFramework.Utility;
using WangFramework.MvcPager;
using WangFramework.Extensions;
using W3WGame.Core.Dtos;
using W3WGame.Core.Entities;

namespace W3WGame.Web.Controllers.mainLayout
{
   public class mainLayoutController:BaseController
   {
       private readonly ADConfigTask _adConfigTask = new ADConfigTask();
       private readonly MobilGameTask _mobilGameTask = new MobilGameTask();

       public ActionResult HomeLunBo()
       {
           var model = _adConfigTask.GetListBy((int) ADConfigPlaceEnum.HomeLunBo);
           return View(model);
       }

       public ActionResult HomeGamesDanner()
       {
           //热门
           ViewData["hostGameList"] = _mobilGameTask.GetAll(11, "IsHot = 1"); //考虑用缓存
           //必玩
           ViewData["biwanGameList"] = _mobilGameTask.GetAll(10, "IsBiWan = 1");
           //最新
           ViewData["newestGameList"] = _mobilGameTask.GetAll(10, "IsNew = 1");

           return View();
       }
       public ActionResult xiaobian()
       {
           return View();
       }
    }
}
