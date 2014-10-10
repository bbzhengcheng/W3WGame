using System;
using System.ComponentModel.DataAnnotations;
using W3WGame.Core.Enums;
using WangFramework.ORM;

namespace W3WGame.Admin.Controllers.GameServersManager.ViewModels
{


    public class SaveGameServers
    {

        public int? ID { get; set; }
        [Display(Name = "游戏"), Required(ErrorMessage = "请输入！")]
        public int GameID { get; set; }

        [Display(Name = "服务器名称"), Required(ErrorMessage = "请输入！")]
        public string ServerName { get; set; }

        [Display(Name = "服务器ID"), Required(ErrorMessage = "请输入！")]
        public int ServerID { get; set; }

        [Display(Name = "开服时间"), Required(ErrorMessage = "请输入！")]
        public DateTime OpenTime { get; set; }



        [Display(Name = "服务器状态"), Required(ErrorMessage = "请输入！")]
        public int ServerStat { get; set; }




    }
}