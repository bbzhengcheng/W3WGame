
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
using W3WGame.Admin.Controllers.FriendLinkManager.ViewModels;

namespace W3WGame.Admin.Controllers.FriendLinkManager
{

    public class FriendLinkManagerController : BaseController
    {
        private readonly FriendLinkTask _friendlinkTask = new FriendLinkTask();

        public ActionResult List(int? typeid,int pageIndex=1, int pageSize=20)
        {
            var pagedList = _friendlinkTask.GetPagedList(typeid,pageIndex, pageSize);
            ViewData["FriendlinkTypeList"] = FriendlinkTypeEnum.Friend.ToSelectListAddDefault();
            var model = new PagedList<FriendLink>(pagedList.ToList(), pageIndex, pageSize, pagedList.TotalItemCount);

            return View(model);
        }


        public ActionResult Save(int? id)
        {

            ViewData["FriendlinkTypeList"] = FriendlinkTypeEnum.Friend.ToSelectListAddDefault();
            var model = new SaveFriendLink();

            if (id != null)
            {
                var item = _friendlinkTask.GetById((int)id);
                if (item == null)
                    return AlertMsg("参数错误", HttpContext.Request.UrlReferrer.PathAndQuery);

                model = EntityMapper.Map<FriendLink, SaveFriendLink>(item);
            }
            return View(model);
        }

        [HttpPost]
        public ActionResult Save(SaveFriendLink savemodel)
        {

            ViewData["FriendlinkTypeList"] = FriendlinkTypeEnum.Friend.ToSelectListAddDefault();
            if (ModelState.IsValid)
            {
                if (savemodel.ID == null)
                {
                    var model = new FriendLink
                                    {
                                        LinkUrl = savemodel.LinkUrl,
                                        LinkName = savemodel.LinkName,
                                        LinkType = savemodel.LinkType,
                                        CreateDate = DateTime.Now,
                                    };
                    _friendlinkTask.Add(model);
                }
                else
                {
                    var model = _friendlinkTask.GetById((int)savemodel.ID);

                    if (model == null)
                        return AlertMsg("参数错误", HttpContext.Request.UrlReferrer.PathAndQuery);


                    model.LinkUrl = savemodel.LinkUrl;
                    model.LinkName = savemodel.LinkName;
                    model.LinkType = savemodel.LinkType;
                   


                    _friendlinkTask.Update(model);
                }
                return AlertMsg("保存成功", HttpContext.Request.UrlReferrer.PathAndQuery);
            }
            return View(savemodel);
        }


        #region 删除用户信息 Delete

        [HttpPost]
        public void Delete(int id)
        {
            _friendlinkTask.Delete(id);
        }

        #endregion
    }
}