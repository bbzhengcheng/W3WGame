
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using W3WGame.Core.Enums;
using W3WGame.Services;
using W3WGame.Task;
using WangFramework.Mappers;
using WangFramework.Utility;
using WangFramework.MvcPager;
using WangFramework.Extensions;
using W3WGame.Core.Dtos;
using W3WGame.Core.Entities;
using W3WGame.Admin.Controllers.MobilGameManager.ViewModels;

namespace W3WGame.Admin.Controllers.MobilGameManager
{

    public class MobilGameManagerController : BaseController
    {
        private readonly MobilGameTask _mobilgameTask = new MobilGameTask();

        public ActionResult List(int? gamesys, bool? hasGift,bool? isHot, bool? isNew, bool? IsBiWan, bool? isThisAweekHot, bool? isTuiJian, int? gameType, int? gameTeZhen, int? yunyingState, bool? isQianLiBao, bool? isGameType, int pageIndex=1, int pageSize=20)
        {
            var pagedList = _mobilgameTask.GetPagedList( gamesys,  hasGift,isHot,  isNew,  IsBiWan,  isThisAweekHot,  isTuiJian,  gameType, gameTeZhen,  yunyingState,  isQianLiBao,  isGameType,
             pageIndex,pageSize);
            var boolselect = new SelectListItem {Selected = true, Text = "全部", Value = string.Empty};

            var boolselectlist = new List<SelectListItem>
                                     {
                                         boolselect,
                                         new SelectListItem{Selected = false,Text = "是",Value = "True"},
                                         new SelectListItem{Selected = false,Text = "否",Value = "False"},
                                     };
            
            ViewData["hasGiftList"] = boolselectlist;
            ViewData["isHotList"] = boolselectlist;
            ViewData["isNewList"] = boolselectlist;
            ViewData["IsBiWanList"] = boolselectlist;
            ViewData["isThisAweekHotList"] = boolselectlist;
            ViewData["isTuiJianList"] = boolselectlist;
            ViewData["isQianLiBaoList"] = boolselectlist;
            ViewData["isGameType"] = boolselectlist;
            var gameTypeList= GameTypeEnum.CeLve.ToSelectList();
            gameTypeList.Insert(0,boolselect);
            ViewData["gameTypeList"] = gameTypeList;
            var gameTeZhenList = GameTeZhenEnum.Chongwu.ToSelectList();
            ViewData["syslist"] = GameSysEnum.All.ToSelectListAddDefault();

            gameTeZhenList.Insert(0,boolselect);
            ViewData["gameTeZhenList"] = gameTeZhenList;
            var yunyingStateList = YunYingStateEnum.XinFu.ToSelectList();
            yunyingStateList.Insert(0,new SelectListItem
                                          {
                                              Selected = true,
                                              Text = "全部",
                                              Value = string.Empty,
                                          });
            ViewData["yunyingStateList"] = yunyingStateList;
            var model = new PagedList<MobilGame>(pagedList.ToList(), pageIndex, pageSize, pagedList.TotalItemCount);

            return View(model);
        }


        public ActionResult Save(int? id)
        {
            //var GameSysEnumList = GameSysEnum.Andior.ToSelectList();
            var autolist = new SelectListItem
                               {
                                   Selected = true,
                                   Text = "请选择",
                                   Value = ""
                               };
            //GameSysEnumList.Insert(0,autolist);
            //ViewData["GameSysEnumList"] = GameSysEnumList;
            var GameTeZhenList = GameTeZhenEnum.Chongwu.ToSelectList();
            GameTeZhenList.Insert(0, autolist);
            ViewData["GameTeZhenList"] = GameTeZhenList;
            var GameTypeEnumList = GameTypeEnum.CeLve.ToSelectList();
            GameTypeEnumList.Insert(0,autolist);
            ViewData["GameTypeEnumList"] = GameTypeEnumList;
            ViewData["syslist"] = GameSysEnum.All.ToSelectListAddDefault();
            var YunYingStateEnumList = YunYingStateEnum.XinFu.ToSelectList();
            YunYingStateEnumList.Insert(0,autolist);
            ViewData["YunYingStateEnumList"] = YunYingStateEnumList;
            var model = new SaveMobilGame
                            {
                                GameDes = string.Empty,

                            };

            if (id != null)
            {
                var item = _mobilgameTask.GetById((int)id);
                if (item == null)
                    return AlertMsg("参数错误", HttpContext.Request.UrlReferrer.PathAndQuery);

                model = EntityMapper.Map<MobilGame, SaveMobilGame>(item);
            }
            return View(model);
        }

        [HttpPost]
        public ActionResult Save(SaveMobilGame savemodel)
        {

            ViewData["syslist"] = GameSysEnum.All.ToSelectListAddDefault();
            if (ModelState.IsValid)
            {
                string errMsg, savePath = string.Empty;
                if (savemodel.ID == null)
                {
                    if (Request.Files.Count != 0 && Request.Files[0].ContentLength != 0)
                    {
                        if (!UploadService.UploadFile(Request.Files[0], out savePath, out errMsg))
                            return AlertMsg(errMsg, Request.UrlReferrer.PathAndQuery);


                    }

                    var model = new MobilGame
                                    {
                                        GameName = savemodel.GameName,
                                        ImgPath = savePath,
                                        Sys = savemodel.Sys,
                                        Size = savemodel.Size,
                                        HasGift = savemodel.HasGift,
                                        IsHot = savemodel.IsHot,
                                        IsNew = savemodel.IsNew,
                                        IsBiWan = savemodel.IsBiWan,
                                        IsThisAWeekHot = savemodel.IsThisAWeekHot,
                                        IsTuiJian = savemodel.IsTuiJian,
                                        GameType = savemodel.GameType,
                                        GameTeZhen = savemodel.GameTeZhen,
                                        YunYingState = savemodel.YunYingState,
                                        HotScore = savemodel.HotScore,
                                        CreateDate = DateTime.Now,
                                        IsGameType = savemodel.IsGameType,
                                        IsQianLiBao = savemodel.IsQianLiBao,
                                        Sort  = savemodel.Sort,
                                        Domain = savemodel.Domain,
                                        GameDes = savemodel.GameDes,
                                      
                                    };
                    _mobilgameTask.Add(model);
                }
                else
                {
                    var model = _mobilgameTask.GetById((int)savemodel.ID);

                    if (Request.Files.Count != 0 && Request.Files[0].ContentLength != 0)
                    {
                        if (!UploadService.UploadFile(Request.Files[0], out savePath, out errMsg))
                            return AlertMsg(errMsg, Request.UrlReferrer.PathAndQuery);

                        model.ImgPath = savePath;
                    }


                    if (model == null)
                        return AlertMsg("参数错误", HttpContext.Request.UrlReferrer.PathAndQuery);

                    model.GameName = savemodel.GameName;

                    model.Sys = savemodel.Sys;
                    model.Size = savemodel.Size;
                    model.HasGift = savemodel.HasGift;
                    model.IsHot = savemodel.IsHot;
                    model.IsNew = savemodel.IsNew;
                    model.IsBiWan = savemodel.IsBiWan;
                    model.IsThisAWeekHot = savemodel.IsThisAWeekHot;
                    model.IsTuiJian = savemodel.IsTuiJian;
                    model.GameType = savemodel.GameType;
                    model.GameTeZhen = savemodel.GameTeZhen;
                    model.YunYingState = savemodel.YunYingState;
                    model.HotScore = savemodel.HotScore;
                    model.IsGameType = savemodel.IsGameType;
                    model.IsQianLiBao = savemodel.IsQianLiBao;
                    model.Sort = savemodel.Sort;
                    model.Domain = savemodel.Domain;
                    model.GameDes = savemodel.GameDes;
                    _mobilgameTask.Update(model);
                }
                return AlertMsg("保存成功", HttpContext.Request.UrlReferrer.PathAndQuery);
            }
            return View(savemodel);
        }

        #region 删除用户信息 Delete

        [HttpPost]
        public void Delete(int id)
        {
            _mobilgameTask.Delete(id);
        }

        #endregion
    }
}