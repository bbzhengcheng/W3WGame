using System;
using System.ComponentModel.DataAnnotations;
using W3WGame.Core.Enums;
using WangFramework.ORM;

namespace W3WGame.Admin.Controllers.GameDownloadUrlsManager.ViewModels
{


    public class SaveGameDownloadUrls
    {

        public int? ID { get; set; }

        [Display(Name = "游戏"), Required(ErrorMessage = "请输入！")]
        public int GameID { get; set; }

        [Display(Name = "运行系统"), Required(ErrorMessage = "请输入！")]
        public int GameSys { get; set; }

        [Display(Name = "下载地址"), Required(ErrorMessage = "请输入！")]
        public string DownloadUrl { get; set; }

        
        public int Count { get; set; }

       
        public DateTime CreateDate { get; set; }

       
        public DateTime LastDownloadDate { get; set; }




    }
}