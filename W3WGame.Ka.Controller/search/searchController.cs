
using System.Linq;
using System.Web.Mvc;
using System.Xml.Linq;
using SealyStore.Web.Controllers.Account.ViewModels;
using W3WGame.Core.Dtos.Web;
using W3WGame.Core.Entities;
using W3WGame.Core.Enums;
using W3WGame.Ka.Controller.personal.ViewModels;
using W3WGame.Services;
using W3WGame.Task;
using W3WGame.Web.Controllers;
using WangFramework.Common;
using WangFramework.MvcPager;
using WangFramework.Utility;


namespace W3WGame.Ka.Controller.search
{
    public class searchController:BaseController
    {
        private readonly GameKaTask _gameKaTask = new GameKaTask();

        public ActionResult index(string name,int pageindex=1,int pagesize=20)
        {  
            var list = _gameKaTask.GetSearchPagedList(name,  pageindex, pagesize);
            var model = new PagedList<SearchGameKaDto>(list.ToList(), pageindex,pagesize, list.TotalItemCount);
            
            return View(model);
            
        }
    }
}
