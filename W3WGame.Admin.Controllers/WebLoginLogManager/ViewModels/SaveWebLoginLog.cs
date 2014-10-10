using System;
using System.ComponentModel.DataAnnotations;
using W3WGame.Core.Enums;
using WangFramework.ORM;

namespace W3WGame.Admin.Controllers.WebLoginLogManager.ViewModels
{


    public class SaveWebLoginLog
    {

        public int? ID { get; set; }
        [Display(Name = "账号"), Required(ErrorMessage = "请输入！")]
        public string Account { get; set; }

        [Display(Name = "登录时间"), Required(ErrorMessage = "请输入！")]
        public DateTime LoginDate { get; set; }

        [Display(Name = "登陆IP"), Required(ErrorMessage = "请输入！")]
        public string IP { get; set; }




    }
}