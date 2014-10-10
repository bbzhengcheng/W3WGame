using System;
using System.ComponentModel.DataAnnotations;
using W3WGame.Core.Enums;
using WangFramework.ORM;

namespace W3WGame.Admin.Controllers.FriendLinkManager.ViewModels
{


    public class SaveFriendLink
    {

        public int? ID { get; set; }

        [Display(Name = "链接URL"), Required(ErrorMessage = "请输入！")]
        public string LinkUrl { get; set; }

        [Display(Name = "链接名称"), Required(ErrorMessage = "请输入！")]
        public string LinkName { get; set; }

        [Display(Name = "链接类型"), Required(ErrorMessage = "请输入！")]
        public int LinkType { get; set; }

        [Display(Name = "创建日期"), Required(ErrorMessage = "请输入！")]
        public DateTime CreateDate { get; set; }




    }
}