using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using System.Xml.Linq;
using SealyStore.Web.Controllers.Account.ViewModels;
using W3WGame.Core.Dtos.Web;
using W3WGame.Core.Entities;
using W3WGame.Core.Enums;
using W3WGame.Ka.Controller.personal.ViewModels;
using W3WGame.Services;
using W3WGame.Services.web;
using W3WGame.Task;
using WangFramework.Common;
using WangFramework.Utility;

namespace W3WGame.Ka.Controller.personal
{
    public class personalController:BaseController
    {
        private readonly AccountInfoTask _accountInfoTask = new AccountInfoTask();
        private readonly ValidateCodeService _validateCodeService = new ValidateCodeService();
        private readonly AccountLoginLogTask _accountLoginLogTask = new AccountLoginLogTask();
      
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
            //if (FormsAuthService.IsSignedIn())
            //{
            //    return string.IsNullOrEmpty(returnUrl)
            //               ? Redirect(Url.Action("Index", "Home"))
            //               : Redirect(returnUrl);
            //}

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

            var userInfo = _accountInfoTask.GetAccount(model.Account);
            if (userInfo == null)
                return Json(new { result = false, message = "用户不存在" }, JsonRequestBehavior.AllowGet);

            if (userInfo.Password != CryptTools.HashPassword(model.Password))
                return Json(new { result = false, message = "用户名或密码不正确" }, JsonRequestBehavior.AllowGet);

            // 添加登录日志
           
            _accountLoginLogTask.Add(new AccountLoginLog
                                         {
                                             Account = userInfo.Account,
                                             CreateDate = DateTime.Now,
                                             IP = DNTRequest.GetIP(),
                                         });
            // 更新购物车


            FormsAuthServiceCookie.SignIn(model.Account, false);
            return Json(new { result = true, message = string.Empty }, JsonRequestBehavior.AllowGet);
        }

        #endregion

        #region 会员注册 Register

        public ActionResult reg(string returnUrl)
        {
            return View();
        }

        [HttpPost]
        public ActionResult reg(RegisterModel model, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                if (!_validateCodeService.CheckCode(model.ValidCode))
                    return AlertMsg("验证码不正确", Request.UrlReferrer.PathAndQuery);

               
                if (_accountInfoTask.ExistsEmail(model.Email))
                    return AlertMsg("电子邮箱已存在", Request.UrlReferrer.PathAndQuery);

                var ipAddress = DNTRequest.GetIP();
               var userInfo = _accountInfoTask.Register(model.Email, model.Password, model.Email, ipAddress,"",DNTRequest.GetIP());
               FormsAuthServiceCookie.SignIn(model.Email, false);

                return string.IsNullOrEmpty(returnUrl)
                          ? Redirect(Url.Action("Index", "Home"))
                          : Redirect(returnUrl);
            }
            return AlertMsg("注册出错，请联系管理员", Request.UrlReferrer.ToString());
        }

        #endregion

        #region 安全退出 LogOff

        public ActionResult LogOff()
        {
            FormsAuthServiceCookie.SignOut();
            return RedirectToAction("Index", "Home");
        }

        #endregion

        #region 用户是否存在 ExistsUser

        public ActionResult ExistsUser(string account)
        {
            var isOK = _accountInfoTask.Exists(account);
            return Json(isOK, JsonRequestBehavior.AllowGet);
        }

        #endregion

        #region 邮箱地址是否已存在 ExistsEmail

        public ActionResult ExistsEmail(string email)
        {
            var isOK = _accountInfoTask.ExistsEmail(email);
            return Json(isOK, JsonRequestBehavior.AllowGet);
        }

        #endregion
    }
}
