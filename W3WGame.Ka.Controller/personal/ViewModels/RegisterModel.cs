using System.ComponentModel.DataAnnotations;

namespace SealyStore.Web.Controllers.Account.ViewModels
{
    public class RegisterModel
    {
       
       
        [Display(Name = "登录密码"), Required]
        public string Password { get; set; }

        [Display(Name = "确认密码"), Required]
        public string ConfirmPassword { get; set; }

        [Display(Name = "电子邮箱"), Required]
        public string Email { get; set; }

        [Display(Name = "验证码"), Required]
        public string ValidCode { get; set; }
    }
}