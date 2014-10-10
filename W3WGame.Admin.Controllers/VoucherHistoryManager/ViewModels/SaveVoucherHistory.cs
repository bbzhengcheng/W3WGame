using System;
using System.ComponentModel.DataAnnotations;
using W3WGame.Core.Enums;
using WangFramework.ORM;

namespace W3WGame.Admin.Controllers.VoucherHistoryManager.ViewModels
{


    public class SaveVoucherHistory
    {

        public int? ID { get; set; }
        [Display(Name = "订单号"), Required(ErrorMessage = "请输入！")]
        public string Code { get; set; }

        [Display(Name = "账号"), Required(ErrorMessage = "请输入！")]
        public string Account { get; set; }

        [Display(Name = "游戏币"), Required(ErrorMessage = "请输入！")]
        public int Gold { get; set; }

        [Display(Name = "人民币"), Required(ErrorMessage = "请输入！")]
        public decimal RMB { get; set; }

        [Display(Name = "接口返回代码"), Required(ErrorMessage = "请输入！")]
        public string RetCode { get; set; }

        [Display(Name = "充值ip"), Required(ErrorMessage = "请输入！")]
        public string IP { get; set; }

        [Display(Name = "添加时间"), Required(ErrorMessage = "请输入！")]
        public DateTime CreateDate { get; set; }

        [Display(Name = "完成时间"), Required(ErrorMessage = "请输入！")]
        public DateTime FinishDate { get; set; }

        [Display(Name = "订单状态"), Required(ErrorMessage = "请输入！")]
        public int GoldState { get; set; }

        [Display(Name = "游戏ID"), Required(ErrorMessage = "请输入！")]
        public int GameID { get; set; }

        [Display(Name = "服务器ID"), Required(ErrorMessage = "请输入！")]
        public int ServerID { get; set; }




    }
}