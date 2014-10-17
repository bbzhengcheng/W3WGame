using System;
using System.ComponentModel.DataAnnotations;
using W3WGame.Core.Enums;
using WangFramework.ORM;

namespace W3WGame.Admin.Controllers.GameNewsManager.ViewModels
{


    public class SaveGameNews
    {

        public int? ID { get; set; }

        [Display(Name = "游戏")]
        public int GameID { get; set; }

        [Display(Name = "新闻类型"), Required(ErrorMessage = "请输入！")]
        public int NewsType { get; set; }

        [Display(Name = "新闻标题"), Required(ErrorMessage = "请输入！")]
        public string Title { get; set; }

        [Display(Name = "新闻内容"), Required(ErrorMessage = "请输入！")]
        public string Content { get; set; }

        [Display(Name = "导读")]
        public string ShortDes { get; set; }

        public string ShortDesImg { get; set; }

        [Display(Name = "是否显示在首页")]
        public bool IsDisplayHomePage { get; set; }

        [Display(Name = "点击次数"), Required(ErrorMessage = "请输入！")]
        public int ClickCount { get; set; }

        [Display(Name = "创建时间"), Required(ErrorMessage = "请输入！")]
        public DateTime CreateDate { get; set; }

        [Display(Name = "创建人")]
        public string CreatePeople { get; set; }

        [Display(Name = "是否平台新闻")]
        public bool IsWeb { get; set; }



    }
}