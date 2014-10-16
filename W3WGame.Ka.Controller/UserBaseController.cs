using System.Web.Mvc;
using W3WGame.Task;
using W3WGame.Web.Controllers;

namespace W3WGame.Ka.Controller
{
    public class UserBaseController : BaseController
    {
        private readonly AdminPowerTask _powersTask = new AdminPowerTask();
        private readonly AdminUserTask _adminUserTask = new AdminUserTask();

        protected override void OnAuthorization(AuthorizationContext filterContext)
        {
            if (!FormsAuthServiceCookie.IsSignedIn())
            {
                filterContext.HttpContext.Response.Write("<script>window.top.location.href='/personal/login';</script>");
                filterContext.HttpContext.Response.End();
                return;
            }


        }

        public string LogOnUserName
        {
            get
            {
                return FormsAuthServiceCookie.IsSignedIn() ? FormsAuthServiceCookie.GetCurrentIdentity() : string.Empty;
            }
        }

    }
}
