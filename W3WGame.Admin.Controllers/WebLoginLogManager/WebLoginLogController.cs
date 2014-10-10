
using System;
using System.Linq;
using System.Web.Mvc;
using W3WGame.Task;
using WangFramework.Mappers;
using WangFramework.Utility;
using WangFramework.MvcPager;
using WangFramework.Extensions;
using W3WGame.Core.Dtos;
using W3WGame.Core.Entities;
using W3WGame.Admin.Controllers.WebLoginLogManager.ViewModels;

namespace W3WGame.Admin.Controllers.WebLoginLogManager
{
	
	public  class WebLoginLogManagerController:BaseController
	{
	     private readonly WebLoginLogTask _webloginlogTask = new WebLoginLogTask();
	 
	     public ActionResult List(int pageIndex=1, int pageSize=20)
        {
            var pagedList = _webloginlogTask.GetPagedList(pageIndex, pageSize);



            var model = new PagedList<WebLoginLog>(pagedList.ToList(), pageIndex, pageSize, pagedList.TotalItemCount);

            return View(model);
        }
        
        
     
	}
}