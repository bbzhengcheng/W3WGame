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
using W3WGame.Admin.Controllers.AdminUsers.ViewModels;

namespace W3WGame.Admin.Controllers.AdminUsers
{
    public class AdminUsersController : BaseController
    {
        private readonly AdminUserRoleTask _adminUserRoleTask = new AdminUserRoleTask();
        private readonly AdminUserTask _adminUserTask = new AdminUserTask();

        #region 查看用户列表 List

        public ActionResult List(string account,int? userRole,int pageIndex = 1,int pageSize = 10)
        {
            var roleList = _adminUserRoleTask.GetAll().ToSelectList(c => c.RoleId.ToString(), c => c.RoleName);

            roleList.Insert(0, new SelectListItem {Text = "全部", Value = string.Empty});

            ViewBag.RoleList = roleList;

            var pagedList = _adminUserTask.GetPagedList(account, userRole, pageIndex, pageSize);

            var items = pagedList.Select(EntityMapper.Map<AdminUserDto, AdminUserModel>);

            var model = new PagedList<AdminUserModel>(items, pageIndex, pageSize, pagedList.TotalItemCount);

            return View(model);
        }

        #endregion

        #region 保存/修改用户信息 Save

        public ActionResult Save(int? id)
        {
            ViewBag.RoleList = _adminUserRoleTask.GetAll().ToSelectList(c => c.RoleId.ToString(), c => c.RoleName);

            var model = new SaveAdminUserModel();

            if(id != null)
            {
                var item = _adminUserTask.GetById((int) id);
                if (item == null)
                    return AlertMsg("参数错误", HttpContext.Request.UrlReferrer.PathAndQuery);

                model = EntityMapper.Map<AdminUser, SaveAdminUserModel>(item);
            }
            return View(model);
        }

        [HttpPost]
        public ActionResult Save(SaveAdminUserModel savemodel)
        {
            ViewBag.RoleList = _adminUserRoleTask.GetAll().ToSelectList(c => c.RoleId.ToString(), c => c.RoleName);

            if(ModelState.IsValid)
            {
                if(savemodel.AdminUserId == null)
                {
                    var model = new AdminUser
                                    {
                                        UserName = savemodel.UserName,
                                        Password = CryptTools.HashPassword(savemodel.Password),
                                        IsLock = false,
                                        RoleId = savemodel.RoleId
                                    };
                    _adminUserTask.Add(model);
                }
                else
                {
                    var model = _adminUserTask.GetById((int) savemodel.AdminUserId);

                    if(model == null)
                        return AlertMsg("参数错误", HttpContext.Request.UrlReferrer.PathAndQuery);

                    model.UserName = savemodel.UserName;
                    model.Password = CryptTools.HashPassword(savemodel.Password);
                    model.RoleId = savemodel.RoleId;

                    _adminUserTask.Update(model);
                }
                return AlertMsg("保存成功", HttpContext.Request.UrlReferrer.PathAndQuery);
            }
            return View(savemodel);
        }

        #endregion

        #region 删除用户信息 Delete

        [HttpPost]
        public void Delete(int id)
        {
            _adminUserTask.Delete(id);
        }

        #endregion

        #region 锁定用户 Lock

        public ActionResult Lock(int id)
        {
            var model = _adminUserTask.GetById(id);
            if(model != null)
            {
                model.IsLock = true;
                _adminUserTask.Update(model);
            }
            return AlertMsg("锁定成功", HttpContext.Request.UrlReferrer.PathAndQuery);
        }

        #endregion

        #region 用户解锁 UnLock

        public ActionResult UnLock(int id)
        {
            var model = _adminUserTask.GetById(id);
            if(model != null)
            {
                model.IsLock = false;
                _adminUserTask.Update(model);
            }
            return AlertMsg("解锁成功", HttpContext.Request.UrlReferrer.PathAndQuery);
        }

        #endregion
        public ActionResult CheckPassword()
        {

            return View();
        }

        [HttpPost]
        public ActionResult CheckPassword(ChangePasswordModel model)
        {
            if (ModelState.IsValid)
            {
                var adminusr = _adminUserTask.GetByUserName(LogOnUserName);
                if (adminusr == null)
                {
                    ModelState.AddModelError("OldPassword", "用户不存在，无法更改新密码");
                }
                if (adminusr.Password != CryptTools.HashPassword(model.OldPassword))
                {
                    ModelState.AddModelError("OldPassword", "旧密码不正确");
                }
                adminusr.Password = CryptTools.HashPassword(model.NewPassword);
                _adminUserTask.Update(adminusr);
                return AlertMsg("", Url.Action("CheckPassword", "AdminUsers"));
            }

            return View(model);
        }
    }
}
