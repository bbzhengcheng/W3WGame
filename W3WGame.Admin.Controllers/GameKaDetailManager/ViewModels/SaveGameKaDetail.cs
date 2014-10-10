using System;
using System.ComponentModel.DataAnnotations;
using W3WGame.Core.Enums;
using WangFramework.ORM;

namespace W3WGame.Admin.Controllers.GameKaDetailManager.ViewModels
{


    public class SaveGameKaDetail
    {

        public int? ID { get; set; }
        [Display(Name = "卡ID"), Required(ErrorMessage = "请输入！")]
        public int KaID { get; set; }

        [Display(Name = "是否使用"), Required(ErrorMessage = "请输入！")]
        public bool IsUser { get; set; }

        [Display(Name = "使用者账号"), Required(ErrorMessage = "请输入！")]
        public string UseAccount { get; set; }

        [Display(Name = "使用日期"), Required(ErrorMessage = "请输入！")]
        public DateTime UsedDate { get; set; }

        [Display(Name = "序列号"), Required(ErrorMessage = "请输入！")]
        public string Code { get; set; }




    }
}