using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using System.Xml.Linq;
using SealyStore.Web.Controllers.Account.ViewModels;
using W3WGame.Core.Dtos.Web;
using W3WGame.Core.Enums;
using W3WGame.Ka.Controller.personal.ViewModels;
using W3WGame.Services;
using W3WGame.Task;
using WangFramework.Common;
using WangFramework.Utility;

namespace W3WGame.Ka.Controller.personal
{
    public class personalController:BaseController
    {
        private readonly AccountInfoTask _accountInfoTask = new AccountInfoTask();
        private readonly ValidateCodeService _validateCodeService = new ValidateCodeService();

      
        public ActionResult phonereg()
        {
            return View();
        }
        public ActionResult lingqu()
        {
            return View();
        }

        public ActionResult yuding()
        {
            return View();
        }
        #region 登录 LogOn

        public ActionResult login(string returnUrl)
        {
            if (FormsAuthService.IsSignedIn())
            {
                return string.IsNullOrEmpty(returnUrl)
                           ? Redirect(Url.Action("Index", "Home"))
                           : Redirect(returnUrl);
            }

            return View();
        }

        [HttpPost]
        public ActionResult login(UserLogOnModel model)
        {
            if (!_validateCodeService.CheckCode(model.ValidCode))
            {
                _validateCodeService.ClearSession();
                return Json(new { result = false, message = "验证码不正确" }, JsonRequestBehavior.AllowGet);
            }

            var userInfo = _userInfoTask.GetByUserName(model.UserName);
            if (userInfo == null)
                return Json(new { result = false, message = "用户不存在" }, JsonRequestBehavior.AllowGet);

            if (userInfo.Password != CryptTools.HashPassword(model.Password))
                return Json(new { result = false, message = "用户名或密码不正确" }, JsonRequestBehavior.AllowGet);

            // 添加登录日志
           // _userLoginLogsTask.CreateLog(userInfo.UserId, userInfo.UserName, DNTRequest.GetIP());

            // 更新购物车
            

            FormsAuthService.SignIn(model.UserName, false);
            return Json(new { result = true, message = string.Empty }, JsonRequestBehavior.AllowGet);
        }

        #endregion

        #region 会员注册 Register

        public ActionResult Register(string returnUrl)
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(RegisterModel model, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                if (!_validateCodeService.CheckCode(model.ValidCode))
                    return AlertMsg("验证码不正确", Request.UrlReferrer.PathAndQuery);

                if (_userInfoTask.ExistsUserName(model.UserName))
                    return AlertMsg("用户名已存在", Request.UrlReferrer.PathAndQuery);

                if (_userInfoTask.ExistsEmail(model.Email))
                    return AlertMsg("电子邮箱已存在", Request.UrlReferrer.PathAndQuery);

                var ipAddress = DNTRequest.GetIP();
                var userInfo = _userInfoTask.Register(model.UserName, model.Password, model.Email, ipAddress);
                FormsAuthService.SignIn(model.UserName, false);
                _userLoginLogsTask.CreateLog(userInfo.UserId, userInfo.UserName, DNTRequest.GetIP());

                return string.IsNullOrEmpty(returnUrl)
                          ? Redirect(Url.Action("Index", "Home"))
                          : Redirect(returnUrl);
            }
            return View(model);
        }

        #endregion

        #region 安全退出 LogOff

        public ActionResult LogOff()
        {
            FormsAuthService.SignOut();
            return RedirectToAction("Index", "Home");
        }

        #endregion

        #region 用户是否存在 ExistsUser

        public ActionResult ExistsUser(string userName)
        {
            var isOK = _userInfoTask.ExistsUserName(userName);
            return Json(isOK, JsonRequestBehavior.AllowGet);
        }

        #endregion

        #region 邮箱地址是否已存在 ExistsEmail

        public ActionResult ExistsEmail(string email)
        {
            var isOK = _userInfoTask.ExistsEmail(email);
            return Json(isOK, JsonRequestBehavior.AllowGet);
        }

        #endregion
    }
}
