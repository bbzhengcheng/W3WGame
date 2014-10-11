using System.ComponentModel.DataAnnotations;

namespace W3WGame.Ka.Controller.personal.ViewModels
{
    public class UserLogOnModel
    {
        [Display(Name = "用户名"),Required]
        public string Account { get; set; }

        [Display(Name = "密  码"), Required]
        public string Password { get; set; }

        [Display(Name = "验证码"), Required]
        public string ValidCode { get; set; }
    }
}