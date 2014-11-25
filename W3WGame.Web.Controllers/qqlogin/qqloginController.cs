using System.Web.Mvc;

namespace W3WGame.Web.Controllers.qqlogin
{
    public class qqloginController : BaseController
    {
        public ActionResult test()
        {
            return View();
        }
        public ActionResult reply()
        {
            ViewBag.Acc = Request["accessToken"];
            return View();
        }
    }
}
