using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;

namespace W3WGame.Web.Controllers.news
{
    public class newsController:BaseController
    {
        public ActionResult index()
        {
            return View();
        }
    }
}
