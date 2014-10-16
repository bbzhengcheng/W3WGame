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

namespace W3WGame.Ka.Controller.inbox
{
    public class inboxController : UserBaseController
   {
       private readonly AcceptKaDetailTask _acceptKaDetailTask = new AcceptKaDetailTask();

       public ActionResult kabox(int pageindex=1,int pagesize =10)
       {

           var list = _acceptKaDetailTask.GetPagedList(LogOnUserName,null,null,null,(int)AcceptKaTypeEnum.Normal, pageindex, pagesize);
           var model = new PagedList<AcceptKaDetailDto>(list.ToList(), pageindex, pagesize, list.TotalItemCount);
          
           return View(model);
          
       }

       public ActionResult bookingbox(int pageindex = 1, int pagesize = 10)
       {
           var list = _acceptKaDetailTask.GetPagedList(LogOnUserName, null, null, null, (int)AcceptKaTypeEnum.YuDing, pageindex, pagesize);
           var model = new PagedList<AcceptKaDetailDto>(list.ToList(), pageindex, pagesize, list.TotalItemCount);

           return View(model);
       }

       public ActionResult myfollow()
       {
           return View();
       }
    }
}
