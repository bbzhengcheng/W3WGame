using System;
using System.Collections.Generic;
using W3WGame.Core.Entities;
using W3WGame.Dao.Daos;
namespace W3WGame.Task
{
	/// <summary>
	///
	/// </summary>
	public class AdminRolePowerTask
	{
		private readonly AdminRolePowerDao _adminRolePower = new AdminRolePowerDao();

	    public List<AdminRolePower> GetListByRoleId(int roleId)
	    {
	        return _adminRolePower.GetListByRoleId(roleId);
	    }
	}
}

