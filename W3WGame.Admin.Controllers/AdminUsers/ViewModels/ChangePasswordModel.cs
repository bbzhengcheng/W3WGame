using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace W3WGame.Admin.Controllers.AdminUsers.ViewModels
{
    public class ChangePasswordModel
    {
        [Display(Name = "旧的密码"), Required(ErrorMessage = "请输入旧的密码"),
         StringLength(32, MinimumLength = 6, ErrorMessage = "密码是6-32个字节")]
        public string OldPassword { get; set; }

        [Display(Name = "新的密码"), Required(ErrorMessage = "请输入新的密码"),
         StringLength(32, MinimumLength = 6, ErrorMessage = "密码是6-32个字节")]
        public string NewPassword { get; set; }

        [System.Web.Mvc.Compare("NewPassword", ErrorMessage = "两次输入的密码不一致"), Display(Name = "确认密码"), Required(ErrorMessage = "请再次输入新的密码")]
        public string ConfirmPassword { get; set; }
    }
}
