using System.ComponentModel.DataAnnotations;

namespace W3WGame.Admin.Controllers.SysManage.ViewModels
{
    public class SaveUserRoleModel
    {
        /// <summary>
        /// 
        /// </summary>
        public int? RoleId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Display(Name = "角色名称"), Required]
        public string RoleName { get; set; }
    }
}