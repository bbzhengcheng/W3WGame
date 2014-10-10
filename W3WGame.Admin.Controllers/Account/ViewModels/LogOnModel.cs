using System.ComponentModel.DataAnnotations;

namespace W3WGame.Admin.Controllers.Account.ViewModels
{
    public class LogOnModel
    {
        [Display(Name = "账 号"), Required]
        public string UserName { get; set; }

        [Display(Name = "密 码"), Required]
        public string Password { get; set; }
    }
}