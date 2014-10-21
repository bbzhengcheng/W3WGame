using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace W3WGame.Core.Enums
{
    public enum ADConfigPlaceEnum
    {
         [Description("首页轮播")]
         HomeLunBo =1,
         [Description("首页今日新闻广告图200*150")]
         HomeNews = 2,
         [Description("手机游戏测评广告图180*135")]
         HomeCePing = 3,
         [Description("游戏官网轮播340*340")]
         GameLunBo = 4,
         [Description("游戏官网底部游戏展示327*480")]
         GameBLook = 5,
         [Description("平台网游资讯右侧广告248*147")]
         PlatformNewsRight = 6,
         [Description("平台网游资讯右侧广告热门活动230*130")]
         PlatformNewsRightActive = 7,




    }
}

