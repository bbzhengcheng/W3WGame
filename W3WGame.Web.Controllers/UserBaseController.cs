using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using W3WGame.Task;

namespace W3WGame.Web.Controllers
{
    public class UserBaseController : BaseController
    {
        private readonly AdminPowerTask _powersTask = new AdminPowerTask();
        private readonly AdminUserTask _adminUserTask = new AdminUserTask();

        protected override void OnAuthorization(AuthorizationContext filterContext)
        {
            if (!FormsAuthService.IsSignedIn())
            {
                filterContext.HttpContext.Response.Write("<script>window.top.location.href='/Account/LogOn';</script>");
                filterContext.HttpContext.Response.End();
                return;
            }


        }

        public string LogOnUserName
        {
            get
            {
                return FormsAuthService.IsSignedIn() ? FormsAuthService.GetCurrentIdentity().Name : string.Empty;
            }
        }

    }
}
