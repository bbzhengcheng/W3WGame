
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
using W3WGame.Admin.Controllers.GameNewsManager.ViewModels;

namespace W3WGame.Admin.Controllers.GameNewsManager
{

    public class GameNewsManagerController : BaseController
    {
        private readonly GameNewsTask _gamenewsTask = new GameNewsTask();
        private readonly MobilGameTask _mobilGameTask = new MobilGameTask();

        public ActionResult List(int? platId,int? newstype,bool? isWeb,bool? isDisplayHome,int pageIndex=1, int pageSize=20)
        {
            var pagedList = _gamenewsTask.GetPagedList(platId,newstype,isWeb,isDisplayHome,pageIndex, pageSize);

            var newsplatform = _mobilGameTask.GetAll(null, "").ToSelectList(c => c.ID.ToString(), c => c.GameName);
           
            newsplatform.Insert(0, new SelectListItem
            {
                Selected = true,
                Value = string.Empty,
                Text = "请选择"
            });
            ViewData["newsplatform"] = newsplatform;
            ViewData["newstypelist"] = NewsTypeEnum.Active.ToSelectListAddDefault();

            var model = new PagedList<GameNews>(pagedList.ToList(), pageIndex, pageSize, pagedList.TotalItemCount);

            return View(model);
        }


        public ActionResult Save(int? id)
        {
            ViewData["newstypelist"] = NewsTypeEnum.Active.ToSelectListAddDefault();

            var gamelist = _mobilGameTask.GetAll(null, "").ToSelectList(c => c.ID.ToString(), c => c.GameName);
            gamelist.Insert(0,new SelectListItem
                                  {
                                      Selected = true,
                                      Text = "平台",
                                      Value = "0"
                                  });
            ViewData["gamelist"] = gamelist;
            var model = new SaveGameNews
                            {
                                ClickCount = 0,
                                CreateDate = DateTime.Now,
                            };

            if (id != null)
            {
                var item = _gamenewsTask.GetById((int)id);
                if (item == null)
                    return AlertMsg("参数错误", HttpContext.Request.UrlReferrer.PathAndQuery);

                model = EntityMapper.Map<GameNews, SaveGameNews>(item);
            }
            return View(model);
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Save(SaveGameNews savemodel)
        {
            var gamelist = _mobilGameTask.GetAll(null, "").ToSelectList(c => c.ID.ToString(), c => c.GameName);
            gamelist.Insert(0, new SelectListItem
            {
                Selected = true,
                Text = "平台",
                Value = "0"
            });
            ViewData["gamelist"] = gamelist;
            ViewData["newstypelist"] = NewsTypeEnum.Active.ToSelectListAddDefault();
            if (ModelState.IsValid)
            {
                if (savemodel.ID == null)
                {
                    var model = new GameNews
                                    {
                                        GameID = savemodel.GameID,
                                        NewsType = savemodel.NewsType,
                                        Title = savemodel.Title,
                                        Content = savemodel.Content,
                                        ShortDes = savemodel.ShortDes,
                                        ShortDesImg = "",
                                        IsDisplayHomePage = savemodel.IsDisplayHomePage,
                                        ClickCount = savemodel.ClickCount,
                                        CreateDate = savemodel.CreateDate,
                                        CreatePeople = savemodel.CreatePeople,
                                        IsWeb = savemodel.IsWeb,
                                    };
                    _gamenewsTask.Add(model);
                }
                else
                {
                    var model = _gamenewsTask.GetById((int)savemodel.ID);

                    if (model == null)
                        return AlertMsg("参数错误", HttpContext.Request.UrlReferrer.PathAndQuery);

                    model.GameID = savemodel.GameID;
                    model.NewsType = savemodel.NewsType;
                    model.Title = savemodel.Title;
                    model.Content = savemodel.Content;
                    model.ShortDes = savemodel.ShortDes;
                    model.ShortDesImg ="";
                    model.IsDisplayHomePage = savemodel.IsDisplayHomePage;
                    model.ClickCount = savemodel.ClickCount;
                    model.CreateDate = savemodel.CreateDate;
                    model.CreatePeople = savemodel.CreatePeople;
                    model.IsWeb = savemodel.IsWeb;

                    _gamenewsTask.Update(model);
                }
                return AlertMsg("保存成功", HttpContext.Request.UrlReferrer.PathAndQuery);
            }
            return View(savemodel);
        }

        #region 删除用户信息 Delete

        [HttpPost]
        public void Delete(int id)
        {
            _gamenewsTask.Delete(id);
        }

        #endregion
    }
}