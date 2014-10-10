using System.Web.Mvc;
using W3WGame.Task;

namespace W3WGame.Ka.Controller
{
    public class BaseController : System.Web.Mvc.Controller
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

      

       
    }
}
