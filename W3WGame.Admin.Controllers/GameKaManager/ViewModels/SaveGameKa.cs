using System;
using System.ComponentModel.DataAnnotations;
using W3WGame.Core.Enums;
using WangFramework.ORM;

namespace W3WGame.Admin.Controllers.GameKaManager.ViewModels
{


    public class SaveGameKa
    {

        public int? ID { get; set; }
        [Display(Name = "卡类型"), Required(ErrorMessage = "请输入！")]
        public int KaType { get; set; }

        [Display(Name = "卡标题"), Required(ErrorMessage = "请输入！")]
        public string KaTitle { get; set; }

        [Display(Name = "数量"), Required(ErrorMessage = "请输入！")]
        public int Count { get; set; }

        [Display(Name = "游戏"), Required(ErrorMessage = "请输入！")]
        public int GameID { get; set; }

        [Display(Name = "服务器ID"), Required(ErrorMessage = "请输入！")]
        public int ServerID { get; set; }

        [Display(Name = "创建日期"), Required(ErrorMessage = "请输入！")]
        public DateTime CreateDate { get; set; }

         [Display(Name = "是否显示在首页")]
        public bool? IsDisplayHome { get; set; }

        [Display(Name = "剩余数量")]
        public int Shengyu { get; set; }
        
        [Display(Name = "有效期开始时间"), Required(ErrorMessage = "请输入！")]
        public DateTime StartDate { get; set; }

        [Display(Name = "有效期结束时间"), Required(ErrorMessage = "请输入！")]
        public DateTime EndDate { get; set; }





    }
}