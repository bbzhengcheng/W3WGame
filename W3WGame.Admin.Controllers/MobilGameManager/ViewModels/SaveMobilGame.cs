using System;
using System.ComponentModel.DataAnnotations;
using W3WGame.Core.Enums;
using WangFramework.ORM;

namespace W3WGame.Admin.Controllers.MobilGameManager.ViewModels
{


    public class SaveMobilGame
    {

        public int? ID { get; set; }
        [Display(Name = "游戏名称"), Required(ErrorMessage = "请输入！")]
        public string GameName { get; set; }

        [Display(Name = "图片路径")]
        public string ImgPath { get; set; }

        [Display(Name = "游戏大小")]
        public decimal Size { get; set; }

        [Display(Name = "是否有卡礼包")]
        public bool HasGift { get; set; }

        [Display(Name = "是否热点")]
        public bool IsHot { get; set; }

        [Display(Name = "是否最新")]
        public bool IsNew { get; set; }

        [Display(Name = "是否必玩")]
        public bool IsBiWan { get; set; }

        [Display(Name = "是否本周热点")]
        public bool IsThisAWeekHot { get; set; }

        [Display(Name = "是否推荐")]
        public bool IsTuiJian { get; set; }

        [Display(Name = "游戏类型"), Required(ErrorMessage = "请输入！")]
        public int GameType { get; set; }

        [Display(Name = "游戏特征"), Required(ErrorMessage = "请输入！")]
        public int GameTeZhen { get; set; }

        [Display(Name = "运营状态"), Required(ErrorMessage = "请输入！")]
        public int YunYingState { get; set; }

        [Display(Name = "分数"), Required(ErrorMessage = "请输入！")]
        public int HotScore { get; set; }

        [Display(Name = "添加时间"), Required(ErrorMessage = "请输入！")]
        public DateTime CreateDate { get; set; }

        [Display(Name = "是否首页抢礼包")]
        public bool IsQianLiBao { get; set; }

        [Display(Name = "是否首页游戏分类")]
        public bool IsGameType { get; set; }

        [Display(Name = "游戏系统"), Required(ErrorMessage = "请输入！")]
        public int Sys { get; set; }

        [Display(Name = "排序")]
        public int Sort { get; set; }

        [Display(Name = "网站域名"), Required(ErrorMessage = "请输入！")]
        public string Domain { get; set; }

        [Display(Name = "游戏描述"), Required(ErrorMessage = "请输入！")]
        public string GameDes { get; set; }



    }
}