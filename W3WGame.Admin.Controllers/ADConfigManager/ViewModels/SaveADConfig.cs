using System;
using System.ComponentModel.DataAnnotations;
using W3WGame.Core.Enums;
using WangFramework.ORM;

namespace W3WGame.Admin.Controllers.ADConfigManager.ViewModels
{


    public class SaveADConfig
    {

        public int? ID { get; set; }
        
        public string AdPath { get; set; }

        [Display(Name = "素材标题"), Required(ErrorMessage = "请输入！")]
        public string Title { get; set; }

        [Display(Name = "素材指向地址"), Required(ErrorMessage = "请输入！")]
        public string Link { get; set; }

        [Display(Name = "排序"), Required(ErrorMessage = "请输入！")]
        public int Sort { get; set; }

        [Display(Name = "位置"), Required(ErrorMessage = "请输入！")]
        public int Place { get; set; }

        [Display(Name = "素材类型"), Required(ErrorMessage = "请输入！")]
        public int AdType { get; set; }

        
        public DateTime CreateDate { get; set; }

       
        public string CreatePeople { get; set; }

        [Display(Name = "游戏ID"), Required(ErrorMessage = "请输入！")]
        public int GameID { get; set; }


    }
}