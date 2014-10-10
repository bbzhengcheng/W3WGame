
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
using W3WGame.Admin.Controllers.GameKaDetailManager.ViewModels;

namespace W3WGame.Admin.Controllers.GameKaDetailManager
{

    public class GameKaDetailManagerController : BaseController
    {
        private readonly GameKaDetailTask _gamekadetailTask = new GameKaDetailTask();
        private readonly MobilGameTask _mobilGameTask = new MobilGameTask();
        public ActionResult List(int pageIndex=1, int pageSize=20)
        {
            var pagedList = _gamekadetailTask.GetPagedList(pageIndex, pageSize);

            var gamelist = _mobilGameTask.GetAll(null, "").ToSelectList(c => c.ID.ToString(), c => c.GameName);
            gamelist.Insert(0, new SelectListItem
            {
                Selected = true,
                Text = "请选择",
                Value = string.Empty
            });
            ViewData["gamelist"] = gamelist;

            var model = new PagedList<GameKaDetail>(pagedList.ToList(), pageIndex, pageSize, pagedList.TotalItemCount);

            return View(model);
        }


        public ActionResult Save(int? id)
        {


            var model = new SaveGameKaDetail();

            if (id != null)
            {
                var item = _gamekadetailTask.GetById((int)id);
                if (item == null)
                    return AlertMsg("参数错误", HttpContext.Request.UrlReferrer.PathAndQuery);

                model = EntityMapper.Map<GameKaDetail, SaveGameKaDetail>(item);
            }
            return View(model);
        }

        [HttpPost]
        public ActionResult Save(SaveGameKaDetail savemodel)
        {


            if (ModelState.IsValid)
            {
                if (savemodel.ID == null)
                {
                    var model = new GameKaDetail
                                    {
                                        KaID = savemodel.KaID,
                                        IsUser = savemodel.IsUser,
                                        UseAccount = savemodel.UseAccount,
                                        UsedDate = savemodel.UsedDate,
                                        Code = savemodel.Code,
                                    };
                    _gamekadetailTask.Add(model);
                }
                else
                {
                    var model = _gamekadetailTask.GetById((int)savemodel.ID);

                    if (model == null)
                        return AlertMsg("参数错误", HttpContext.Request.UrlReferrer.PathAndQuery);

                    model.KaID = savemodel.KaID;
                    model.IsUser = savemodel.IsUser;
                    model.UseAccount = savemodel.UseAccount;
                    model.UsedDate = savemodel.UsedDate;
                    model.Code = savemodel.Code;


                    _gamekadetailTask.Update(model);
                }
                return AlertMsg("保存成功", HttpContext.Request.UrlReferrer.PathAndQuery);
            }
            return View(savemodel);
        }


        #region 删除用户信息 Delete

        [HttpPost]
        public void Delete(int id)
        {
            _gamekadetailTask.Delete(id);
        }

        #endregion
    }
}