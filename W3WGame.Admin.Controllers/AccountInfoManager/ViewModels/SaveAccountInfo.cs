using System;
using System.ComponentModel.DataAnnotations;
using W3WGame.Core.Enums;
using WangFramework.ORM;

namespace W3WGame.Admin.Controllers.AccountInfoManager.ViewModels
{

    [TableName("AccountInfo")]
    [PrimaryKey("ID")]
    public class SaveAccountInfo
    {
       
        public int? ID { get; set; }
        [Display(Name = ""), Required(ErrorMessage = "请输入！")]
        public string Account { get; set; }
        [Display(Name = ""), Required(ErrorMessage = "请输入！")]
        public string Password { get; set; }
        [Display(Name = ""), Required(ErrorMessage = "请输入！")]
        public string NickName { get; set; }
        [Display(Name = ""), Required(ErrorMessage = "请输入！")]
        public DateTime RegDate { get; set; }
        [Display(Name = ""), Required(ErrorMessage = "请输入！")]
        public string RegIP { get; set; }
        [Display(Name = ""), Required(ErrorMessage = "请输入！")]
        public string IPAddress { get; set; }

        public string Phone { get; set; }

        public string QQ { get; set; }

        public string Email { get; set; }

    }
}