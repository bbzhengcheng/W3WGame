using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;

namespace W3WGame.Ka.Controller.inbox
{
   public class inboxController:BaseController
    {
       public ActionResult kabox()
       {
           return View();
       }

       public ActionResult bookingbox()
       {
           return View();
       }

       public ActionResult myfollow()
       {
           return View();
       }
    }
}
