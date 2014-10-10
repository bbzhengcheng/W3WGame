using System.Linq;
using System.Web.Mvc;
using W3WGame.Admin.Controllers.SysManage.ViewModels;
using W3WGame.Core.Entities;
using W3WGame.Task;
using WangFramework.Mappers;

namespace W3WGame.Admin.Controllers.Home
{
    public class HomeController : BaseController
    {
        private readonly AdminUserTask _adminUserTask = new AdminUserTask();
        private readonly AdminRoleMenuTask _roleMenuTask = new AdminRoleMenuTask();
        private readonly AdminMenuTask _menusTask = new AdminMenuTask();

        public ActionResult Index()
        {
            var userPassword = _adminUserTask.GetByUserName(LogOnUserName);
            var menuIds = _roleMenuTask.GetListByRoleId(userPassword.RoleId)
                .Select(c => c.MenuId).ToList();
            return View();
        }

        public ActionResult Menu()
        {
            var userPassword = _adminUserTask.GetByUserName(LogOnUserName);
            var menus = _roleMenuTask.GetMenuLstByRoleId(userPassword.RoleId)
                .Select(EntityMapper.Map<AdminMenu, MenuModel>)
                .OrderBy(c => c.SortOrder)
                .ToList();
            return View(menus);
        }
    }
}