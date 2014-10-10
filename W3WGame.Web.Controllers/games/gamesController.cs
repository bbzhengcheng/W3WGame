using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;

namespace W3WGame.Web.Controllers.games
{
    public class gamesController:BaseController
    {
        public ActionResult index()
        {
            return View();
        }

        public ActionResult news()
        {
            return View();
        }

        public ActionResult newinfo()
        {
            return View();
        }
    }
}
