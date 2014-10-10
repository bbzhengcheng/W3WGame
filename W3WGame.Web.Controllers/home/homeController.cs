using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using System.Xml.Linq;
using W3WGame.Core.Dtos.Web;
using W3WGame.Core.Enums;
using W3WGame.Task;

namespace W3WGame.Web.Controllers.home
{
    public class homeController : BaseController
    {
        private readonly ADConfigTask _adConfigTask = new ADConfigTask();
        private readonly MobilGameTask _mobilGameTask = new MobilGameTask();
        private readonly GameServersTask _gameServersTask = new GameServersTask();
        private readonly FriendLinkTask _friendLinkTask = new FriendLinkTask();
        private readonly GameNewsTask _gameNewsTask = new GameNewsTask();
        private readonly GameKaTask _gameKaTask = new GameKaTask();

        public ActionResult index()
        {
            //首页广告

            ViewData["newsAdList"] = _adConfigTask.GetListBy((int)ADConfigPlaceEnum.HomeNews);
            ViewData["cePingAdList"] = _adConfigTask.GetListBy((int)ADConfigPlaceEnum.HomeCePing);

            //今日新闻
            XElement root = XElement.Load("http://localhost:2459/config/HomeConfig.xml");
            var todayxe = root.Element("TodayNews").Element("HotNews").Elements("li");
            var newsHight = new List<NewsXmlDto>();
            foreach (var xe in todayxe)
            {
               newsHight.Add(new NewsXmlDto
                                 {
                                     Href = xe.Attribute("href").Value,
                                     Title = xe.Value,
                                 });

            }
            ViewData["newsHight"] = newsHight;
            //新闻列表
            ViewData["newlist"] = _gameNewsTask.GetAll(4,
                                               "NewsType = " + ((int)NewsTypeEnum.News).ToString() +
                                               " AND IsDisplayHomePage=1");

            ViewData["Activenewslist"] = _gameNewsTask.GetAll(4,
                                               "NewsType = " + ((int)NewsTypeEnum.Active).ToString() +
                                               " AND IsDisplayHomePage=1");

            ViewData["cepingList"] = _gameNewsTask.GetAll(4,
                                               "NewsType = " + ((int)NewsTypeEnum.Active).ToString() +
                                               " AND IsDisplayHomePage=1");
            //活动列表


            //本周热门
            ViewData["thisweenHotGame"] = _mobilGameTask.GetAll(10, "IsThisAWeekHot = 1");
            //抢礼包
            ViewData["qianlibaoGameList"] = _gameKaTask.GetHomeList();
            //游戏推荐
            ViewData["tuijianGameList"] = _mobilGameTask.GetAll(15, "IsTuiJian = 1");
            //游戏分类
            ViewData["gametypeGameList"] = _mobilGameTask.GetAll(null, "IsGameType = 1");
            //手机游戏开测
            ViewData["kaiceServerList"] = _gameServersTask.GetHomeServerList((int)YunYingStateEnum.GongCe);
            //手机游戏新服
            ViewData["xinfuServerList"] = _gameServersTask.GetHomeServerList((int)YunYingStateEnum.XinFu);

            ViewData["friendList"] = _friendLinkTask.GetAll();

            return View();
        }
    }
}
