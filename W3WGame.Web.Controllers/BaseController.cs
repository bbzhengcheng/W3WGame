using System.Web.Mvc;
using W3WGame.Task;


namespace W3WGame.Web.Controllers
{
    public class BaseController : Controller
    {
        protected ActionResult AlertMsg(string msg, string returnUrl)
        {
            var script = string.Format("<script>alert('{0}');this.location.href='{1}';</script>", msg, returnUrl);
            Response.Write(script);
            Response.End();
            return new EmptyResult();
        }
    }
}
