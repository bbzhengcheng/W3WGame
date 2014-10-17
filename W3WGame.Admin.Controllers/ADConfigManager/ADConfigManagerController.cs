
using System;
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
using W3WGame.Admin.Controllers.ADConfigManager.ViewModels;

namespace W3WGame.Admin.Controllers.ADConfigManager
{
	
	public  class ADConfigManagerController:BaseController
	{
        private readonly ADConfigTask _lunBoAdTask = new ADConfigTask();
	    private readonly MobilGameTask _mobilGameTask = new MobilGameTask();

        public ActionResult List(int? placeid, int? gameid,int pageIndex = 1, int pageSize = 10)
        {
            var gamelist = _mobilGameTask.GetAll(null, "").ToSelectList(c => c.ID.ToString(), c => c.GameName);
            gamelist.Insert(1, new SelectListItem
            {
                Selected = false,
                Text = "不属于任何游戏",
                Value = "0"
            });
            gamelist.Insert(0, new SelectListItem
            {
                Selected = true,
                Text = "请选择",
                Value = string.Empty
            });
            ViewData["gamelist"] = gamelist;

            var placelist = ADConfigPlaceEnum.HomeLunBo.ToSelectList();
            placelist.Insert(0,new SelectListItem
                                   {
                                       Selected = true,
                                       Text = "请选择",
                                       Value = string.Empty,
                                   });
            ViewData["adconfiglist"] = placelist;
            var list = _lunBoAdTask.GetPagedList(placeid,gameid,pageIndex, pageSize);
            var model = new PagedList<ADConfig>(list.ToList(), pageIndex, pageSize, list.TotalItemCount);

            return View(model);
        }

        public ActionResult Save(int? id)
        {
            ViewData["AdTypeList"] = AdTypeEnum.Flash.ToSelectList();
            var placelist = ADConfigPlaceEnum.HomeLunBo.ToSelectList();
            ViewData["placelist"] = placelist;
            var gamelist = _mobilGameTask.GetAll(null, "").ToSelectList(c => c.ID.ToString(), c => c.GameName);
            gamelist.Insert(1, new SelectListItem
            {
                Selected = false,
                Text = "不属于任何游戏",
                Value = "0"
            }); 
            gamelist.Insert(0, new SelectListItem
            {
                Selected = true,
                Text = "请选择",
                Value = string.Empty
            });
            ViewData["gamelist"] = gamelist;

            var model = new SaveADConfig
            {
                CreateDate = DateTime.Now,
            };

            if (id != null)
            {
                var item = _lunBoAdTask.GetById((int)id);
                if (item == null)
                    return AlertMsg("参数错误", HttpContext.Request.UrlReferrer.PathAndQuery);
                model = EntityMapper.Map<ADConfig, SaveADConfig>(item);
            }
            return View(model);


        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Save(SaveADConfig savemodel)
        {
            var gamelist = _mobilGameTask.GetAll(null, "").ToSelectList(c => c.ID.ToString(), c => c.GameName);
            gamelist.Insert(1, new SelectListItem
            {
                Selected = false,
                Text = "不属于任何游戏",
                Value = "0"
            });
            gamelist.Insert(0, new SelectListItem
            {
                Selected = true,
                Text = "请选择",
                Value = string.Empty
            });
            ViewData["gamelist"] = gamelist;
            ViewData["AdType"] = AdTypeEnum.Flash.ToSelectList();
            var placelist = ADConfigPlaceEnum.HomeLunBo.ToSelectList();
            placelist.Insert(0, new SelectListItem
            {
                Selected = true,
                Text = "请选择",
                Value = string.Empty,
            });
            ViewData["placelist"] = placelist;
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

                    var model = new ADConfig
                    {
                        Title = savemodel.Title,
                        CreateDate = DateTime.Now,
                        AdPath = savePath,
                        Link = savemodel.Link,
                        AdType = savemodel.AdType,
                        Sort = savemodel.Sort,
                        Place = savemodel.Place,
                        CreatePeople = LogOnUserName,
                    };
                    _lunBoAdTask.Add(model);
                }
                else
                {
                    var model = _lunBoAdTask.GetById((int)savemodel.ID);
                    if (Request.Files.Count != 0 && Request.Files[0].ContentLength != 0)
                    {
                        if (!UploadService.UploadFile(Request.Files[0], out savePath, out errMsg))
                            return AlertMsg(errMsg, Request.UrlReferrer.PathAndQuery);

                        model.AdPath = savePath;
                    }


                    if (model == null)
                        return AlertMsg("参数错误", HttpContext.Request.UrlReferrer.PathAndQuery);

                   
                    model.Link = savemodel.Link;
                    model.Title = savemodel.Title;
                    model.AdType = savemodel.AdType;
                    model.Place = savemodel.Place;
                    model.Sort = savemodel.Sort;
                    _lunBoAdTask.Update(model);
                    
                }
                return AlertMsg("保存成功", HttpContext.Request.UrlReferrer.PathAndQuery);
            }
            return View(savemodel);
        }



        [HttpPost]
        public void Delete(int id)
        {
            _lunBoAdTask.Delete(id);
        }


    }
}
