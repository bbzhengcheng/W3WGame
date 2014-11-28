using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using W3WGame.Services.otherapi;
using W3WGame.Task.ServicesTask;

namespace W3WGame.Ka.Controller.otherlogin
{
    public class otherloginController:BaseController
    {
        private static Random RndSeed = new Random();
        public ActionResult qqlogin()
        {
            Session["qqstate"] = (RndSeed.Next(1, 0x5f5e0ff).ToString("00000000") + RndSeed.Next(1, 0x5f5e0ff).ToString("00000000") +
                    RndSeed.Next(1, 0x5f5e0ff).ToString("00000000") + RndSeed.Next(1, 0x5f5e0ff).ToString("00000000"));
            return Redirect(QQAPI.GetLoginUrl(Session["qqstate"].ToString()));
        }
        public ActionResult qqcallback()
        {
            string code = Request.QueryString["code"];
            string state = Request.QueryString["state"];
            string accessToken = string.Empty;
            string openid = string.Empty;
            if(QQLoginTask.GetAccessTokenAndOpenID(code,state,out accessToken,out openid))
            {
                //登录成功逻辑
            }
            else
            {
                //登录失败逻辑
            }
            return Content(string.Format("accessToken={0}&openid={1}", accessToken, openid));
        }
    }
}
