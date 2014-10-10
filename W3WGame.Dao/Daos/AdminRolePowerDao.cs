using System;
using System.Collections.Generic;
using System.Linq;
using WangFramework.ORM;
using W3WGame.Core.Entities;
namespace W3WGame.Dao.Daos
{
	/// <summary>
	/// 
	/// </summary>
	public class AdminRolePowerDao : BaseDao<AdminRolePower>
	{
	    public List<AdminRolePower> GetListByRoleId(int roleId)
	    {
	        var sql = Sql.Builder.Where("RoleId = @0", roleId);
	        return Query(sql).ToList();
	    }

	    public void DeleteByRoleId(int roleId)
	    {
            var sql = Sql.Builder.Where("RoleId = @0", roleId);
	        Delete(sql);
	    }
	}
}

