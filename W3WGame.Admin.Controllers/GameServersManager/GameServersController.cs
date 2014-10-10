
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
using W3WGame.Admin.Controllers.GameServersManager.ViewModels;

namespace W3WGame.Admin.Controllers.GameServersManager
{

    public class GameServersManagerController : BaseController
    {
        private readonly GameServersTask _gameserversTask = new GameServersTask();
        private readonly MobilGameTask _mobilGameTask = new MobilGameTask();
        public ActionResult List(int? gameid,int? serverid,int pageIndex=1, int pageSize=20)
        {
            var pagedList = _gameserversTask.GetPagedList(gameid,serverid,pageIndex, pageSize);



            var model = new PagedList<GameServers>(pagedList.ToList(), pageIndex, pageSize, pagedList.TotalItemCount);
            var gamelist = _mobilGameTask.GetAll(null, "").ToSelectList(c => c.ID.ToString(), c => c.GameName);
            gamelist.Insert(0, new SelectListItem
            {
                Selected = true,
                Text = "请选择",
                Value = string.Empty
            });
            ViewData["gamelist"] = gamelist;

            return View(model);
        }


        public ActionResult Save(int? id)
        {

            var gamelist = _mobilGameTask.GetAll(null, "").ToSelectList(c => c.ID.ToString(), c => c.GameName);
            gamelist.Insert(0, new SelectListItem
            {
                Selected = true,
                Text = "请选择",
                Value = string.Empty
            });
            ViewData["gamelist"] = gamelist;
            var model = new SaveGameServers();

            if (id != null)
            {
                var item = _gameserversTask.GetById((int)id);
                if (item == null)
                    return AlertMsg("参数错误", HttpContext.Request.UrlReferrer.PathAndQuery);

                model = EntityMapper.Map<GameServers, SaveGameServers>(item);
            }
            return View(model);
        }

        [HttpPost]
        public ActionResult Save(SaveGameServers savemodel)
        {

            var gamelist = _mobilGameTask.GetAll(null, "").ToSelectList(c => c.ID.ToString(), c => c.GameName);
            gamelist.Insert(0, new SelectListItem
            {
                Selected = true,
                Text = "请选择",
                Value = string.Empty
            });
            ViewData["gamelist"] = gamelist;
            if (ModelState.IsValid)
            {
                if (savemodel.ID == null)
                {
                    var model = new GameServers
                                    {
                                        GameID = savemodel.GameID,
                                        ServerName = savemodel.ServerName,
                                        ServerID = savemodel.ServerID,
                                        OpenTime = savemodel.OpenTime,
                                        CreateDate = DateTime.Now,
                                        ServerStat = _mobilGameTask.GetById(savemodel.GameID).YunYingState,
                                    };
                    _gameserversTask.Add(model);
                }
                else
                {
                    var model = _gameserversTask.GetById((int)savemodel.ID);

                    if (model == null)
                        return AlertMsg("参数错误", HttpContext.Request.UrlReferrer.PathAndQuery);

                    model.GameID = savemodel.GameID;
                    model.ServerName = savemodel.ServerName;
                    model.ServerID = savemodel.ServerID;
                    model.OpenTime = savemodel.OpenTime;

                    _gameserversTask.Update(model);
                }
                return AlertMsg("保存成功", HttpContext.Request.UrlReferrer.PathAndQuery);
            }
            return View(savemodel);
        }


        #region 删除用户信息 Delete

        [HttpPost]
        public void Delete(int id)
        {
            _gameserversTask.Delete(id);
        }

        public ActionResult GetServerList(int gameid)
        {
            
            var list = _gameserversTask.GetAll(gameid).Select(c => new SelectListItem
                                                                       {
                                                                           Text = c.ServerName,
                                                                           Value = c.ServerID.ToString(),
                                                                       }).ToList();
            list.Insert(0, new SelectListItem
                              {

                                  Text = "请选择",
                                  Value = string.Empty
                              });
            return Json(list, JsonRequestBehavior.AllowGet);
        }

        #endregion
    }
}