using System.Web.Mvc;
using W3WGame.Task;

namespace W3WGame.Admin.Controllers
{
    public class BaseController : Controller
    {
        private readonly AdminPowerTask _powersTask = new AdminPowerTask();
        private readonly AdminUserTask _adminUserTask = new AdminUserTask();

        protected ActionResult AlertMsg(string msg, string returnUrl)
        {
            var script = string.Format("<script>alert('{0}');this.location.href='{1}';</script>", msg, returnUrl);
            Response.Write(script);
            Response.End();
            return new EmptyResult();
        }

        protected override void OnAuthorization(AuthorizationContext filterContext)
        {
            if (!FormsAuthService.IsSignedIn())
            {
                filterContext.HttpContext.Response.Write("<script>window.top.location.href='/Account/LogOn';</script>");
                filterContext.HttpContext.Response.End();
                return;
            }

            var controllerName = filterContext.RouteData.Values["controller"].ToString();
            var actionName = filterContext.RouteData.Values["action"].ToString();
            var powerInfo = _powersTask.Get(controllerName, actionName);
            if (powerInfo == null) return;

            if (!_adminUserTask.ExistsPower(LogOnUserName, powerInfo.PowerId))
            {
                filterContext.HttpContext.Response.Write("对不起，您没有此权限");
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
