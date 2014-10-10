using System;
using System.Collections.Generic;
using W3WGame.Core.Entities;
using W3WGame.Dao.Daos;
namespace W3WGame.Task
{
	/// <summary>
	///
	/// </summary>
	public class AdminRoleMenuTask
	{
		private readonly AdminRoleMenuDao _adminRoleMenu = new AdminRoleMenuDao();

	    public List<AdminRoleMenu> GetListByRoleId(int roleId)
	    {
	        return _adminRoleMenu.GetListByRoleId(roleId);
	    }

	    public List<AdminMenu> GetMenuLstByRoleId(int roleId)
	    {
	        return _adminRoleMenu.GetMenuLstByRoleId(roleId);
	    }
	}
}

