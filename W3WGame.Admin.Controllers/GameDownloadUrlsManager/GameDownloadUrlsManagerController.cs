
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
using W3WGame.Admin.Controllers.GameDownloadUrlsManager.ViewModels;

namespace W3WGame.Admin.Controllers.GameDownloadUrlsManager
{

    public class GameDownloadUrlsManagerController : BaseController
    {
        private readonly GameDownloadUrlsTask _gamedownloadurlsTask = new GameDownloadUrlsTask();
        private readonly MobilGameTask _mobilGameTask = new MobilGameTask();
        public ActionResult List(int? gameid,int pageIndex = 1, int pageSize = 20)
        {
            var pagedList = _gamedownloadurlsTask.GetPagedList(gameid,pageIndex, pageSize);
            var gamelist = _mobilGameTask.GetAll(null, "").ToSelectList(c => c.ID.ToString(), c => c.GameName);
            gamelist.Insert(0, new SelectListItem
            {
                Selected = true,
                Text = "请选择",
                Value = string.Empty
            });
            ViewData["gamelist"] = gamelist;


            var model = new PagedList<GameDownloadUrls>(pagedList.ToList(), pageIndex, pageSize, pagedList.TotalItemCount);

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
            var model = new SaveGameDownloadUrls();

            if (id != null)
            {
                var item = _gamedownloadurlsTask.GetById((int)id);
                if (item == null)
                    return AlertMsg("参数错误", HttpContext.Request.UrlReferrer.PathAndQuery);

                model = EntityMapper.Map<GameDownloadUrls, SaveGameDownloadUrls>(item);
            }
            return View(model);
        }

        [HttpPost]
        public ActionResult Save(SaveGameDownloadUrls savemodel)
        {
            ViewData["syslist"] = GameSysEnum.Andior.ToSelectListAddDefault();
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
                    if(_gamedownloadurlsTask.Exists(savemodel.GameID,savemodel.GameSys))
                    {
                        return AlertMsg("已存在", HttpContext.Request.UrlReferrer.PathAndQuery);
                    }
                    var model = new GameDownloadUrls
                    {
                      
                        GameID = savemodel.GameID,
                        GameSys = savemodel.GameSys,
                        DownloadUrl = savemodel.DownloadUrl,
                        Count = savemodel.Count,
                        CreateDate = DateTime.Now,
                        LastDownloadDate =Convert.ToDateTime("1980-01-01"),
                    };
                    _gamedownloadurlsTask.Add(model);
                }
                else
                {
                    var model = _gamedownloadurlsTask.GetById((int)savemodel.ID);

                    if (model == null)
                        return AlertMsg("参数错误", HttpContext.Request.UrlReferrer.PathAndQuery);

                  
                    model.GameID = savemodel.GameID;
                    model.GameSys = savemodel.GameSys;
                    model.DownloadUrl = savemodel.DownloadUrl;
                    model.Count = savemodel.Count;
                   


                    _gamedownloadurlsTask.Update(model);
                }
                return AlertMsg("保存成功", HttpContext.Request.UrlReferrer.PathAndQuery);
            }
            return View(savemodel);
        }



        #region 删除用户信息 Delete

        [HttpPost]
        public void Delete(int id)
        {
            _gamedownloadurlsTask.Delete(id);
        }

        #endregion
    }
}