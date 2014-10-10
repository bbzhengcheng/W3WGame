
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
using W3WGame.Admin.Controllers.GameKaManager.ViewModels;

namespace W3WGame.Admin.Controllers.GameKaManager
{

    public class GameKaManagerController : BaseController
    {
        private readonly GameKaTask _gamekaTask = new GameKaTask();
        private readonly MobilGameTask _mobilGameTask = new MobilGameTask();
        private readonly GameKaDetailTask _gameKaDetailTask = new GameKaDetailTask();

        public ActionResult List(int? gameid,int? serverid,int pageIndex = 1, int pageSize = 20)
        {
            var pagedList = _gamekaTask.GetPagedList(pageIndex, pageSize);

            var kalist = KaTypeEnum.SpecialCard.ToSelectList();
            kalist.Insert(0,new SelectListItem
                                {
                                    Selected = true,
                                    Text = "请选择",
                                    Value = string.Empty,
                                });
            ViewBag.KaType = kalist;

            var model = new PagedList<GameKa>(pagedList.ToList(), pageIndex, pageSize, pagedList.TotalItemCount);
            var gamelist = _mobilGameTask.GetAll(null, "").ToSelectList(c => c.ID.ToString(), c => c.GameName);
            gamelist.Insert(0,new SelectListItem
                                  {
                                      Selected = true,
                                      Text = "请选择",
                                      Value = string.Empty
                                  });
            ViewData["gamelist"] = gamelist;
            return View(model);
        }

        public ActionResult AddCode(int kaid)
        {
            ViewData["gamelist"] = _mobilGameTask.GetAll(null, "").ToSelectList(c => c.ID.ToString(), c => c.GameName);
            var info = _gamekaTask.GetById(kaid);
            var gameinfo = _mobilGameTask.GetById(info.GameID);

            ViewBag.CaName = string.Format("{0}-{1}区-{2}", gameinfo.GameName, info.ServerID, info.KaTitle);
            return View();
        }

        [HttpPost]
        public ActionResult AddCode(int kaid,string codelist)
        {
            ViewData["gamelist"] = _mobilGameTask.GetAll(null, "").ToSelectList(c => c.ID.ToString(), c => c.GameName);

            var info = _gamekaTask.GetById(kaid);
           
            if(info ==null)
            {
                return AlertMsg("参数错误", HttpContext.Request.UrlReferrer.PathAndQuery); 
            }
            ViewBag.ServerID = info.ServerID;
            ViewData["kalist"] = _gamekaTask.GetAll(null, "").ToSelectList(c => c.ID.ToString(), c => c.KaTitle);

            string[] list = codelist.Replace("\n", "").Split('\r');
            for (int i = 0; i < info.Count; i++)
            {
                if (_gameKaDetailTask.ExistsCode(list[i]))
                {
                    continue;
                }
                _gameKaDetailTask.Add(new GameKaDetail
                                          {
                                              Code = list[i],
                                              IsUser = false,
                                              KaID = kaid,
                                              UseAccount = string.Empty,
                                              UsedDate = Convert.ToDateTime("1980-01-01")
                                              
                                          });
            }
            return AlertMsg("添加成功", HttpContext.Request.UrlReferrer.PathAndQuery);
        }
        public ActionResult Save(int? id)
        {
            var kalist = KaTypeEnum.SpecialCard.ToSelectList();
            kalist.Insert(0, new SelectListItem
            {
                Selected = true,
                Text = "请选择",
                Value = string.Empty,
            });
            ViewBag.KaTypeList = kalist;
            var gamelist = _mobilGameTask.GetAll(null, "").ToSelectList(c => c.ID.ToString(), c => c.GameName);
            gamelist.Insert(0, new SelectListItem
            {
                Selected = true,
                Text = "请选择",
                Value = string.Empty
            });
            ViewData["gamelist"] = gamelist;
            var model = new SaveGameKa();

            if (id != null)
            {
                var item = _gamekaTask.GetById((int)id);
                if (item == null)
                    return AlertMsg("参数错误", HttpContext.Request.UrlReferrer.PathAndQuery);

                model = EntityMapper.Map<GameKa, SaveGameKa>(item);
            }
            return View(model);
        }

        [HttpPost]
        public ActionResult Save(SaveGameKa savemodel)
        {

            var kalist = KaTypeEnum.SpecialCard.ToSelectList();
            kalist.Insert(0, new SelectListItem
            {
                Selected = true,
                Text = "请选择",
                Value = string.Empty,
            });
            ViewBag.KaType = kalist;
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
                    var model = new GameKa
                                    {
                                        KaType = savemodel.KaType,
                                        KaTitle = savemodel.KaTitle,
                                        Count = savemodel.Count,
                                        GameID = savemodel.GameID,
                                        ServerID = savemodel.ServerID,
                                        CreateDate = DateTime.Now,
                                        Shengyu = savemodel.Count,
                                        StartDate = savemodel.StartDate,
                                        EndDate = savemodel.EndDate,
                                        IsDisplayHome = savemodel.IsDisplayHome,
                                        
                                    };
                    _gamekaTask.Add(model);
                }
                else
                {
                    var model = _gamekaTask.GetById((int)savemodel.ID);

                    if (model == null)
                        return AlertMsg("参数错误", HttpContext.Request.UrlReferrer.PathAndQuery);


                    model.KaType = savemodel.KaType;
                    model.KaTitle = savemodel.KaTitle;
                    model.Count = savemodel.Count;
                    model.GameID = savemodel.GameID;
                    model.ServerID = savemodel.ServerID;
                   
                    model.Shengyu = savemodel.Shengyu;
                    model.StartDate = savemodel.StartDate;
                    model.EndDate = savemodel.EndDate;
                    model.IsDisplayHome = savemodel.IsDisplayHome;
                    _gamekaTask.Update(model);
                }
                return AlertMsg("保存成功", HttpContext.Request.UrlReferrer.PathAndQuery);
            }
            return View(savemodel);
        }


        #region 删除用户信息 Delete

        [HttpPost]
        public void Delete(int id)
        {
            _gamekaTask.Delete(id);
        }

        public ActionResult GetKaList(int gameid)
        {
            var list = _gamekaTask.GetAll(null,"GameID = "+gameid.ToString()).Select(c => new SelectListItem
            {
                Text = c.KaTitle,
                Value = c.ID.ToString(),
            }).ToList();
            return Json(list, JsonRequestBehavior.AllowGet);
        }


        #endregion
    }
}