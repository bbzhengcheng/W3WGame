
using System;
using System.Linq;
using System.Web.Mvc;
using System.Xml.Linq;
using W3WGame.Services;
using W3WGame.Task;
using WangFramework.Mappers;
using WangFramework.Utility;
using WangFramework.MvcPager;
using WangFramework.Extensions;
using W3WGame.Core.Dtos;
using W3WGame.Core.Entities;
using W3WGame.Admin.Controllers.MobilGameManager.ViewModels;

namespace W3WGame.Admin.Controllers.XmlConfig
{
    public class XmlConfigController : BaseController
    {
        public ActionResult HomeNews()
        {
            XElement root = XElement.Load(Server.MapPath("~/Config/HomeConfig.xml"));
            ViewData["xml"] = root.Element("TodayNews").ToString();

            return View();
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult HomeNews(string savestr)
        {
            XElement root = XElement.Load(Server.MapPath("~/Config/HomeConfig.xml"));
            XElement xml = XElement.Parse(savestr);

            root.RemoveAll();
            root.Add(xml);

            root.Save(Server.MapPath("~/Config/HomeConfig.xml"));
            ViewData["xml"] = root.Value;
            return View();
        }
    }
}
