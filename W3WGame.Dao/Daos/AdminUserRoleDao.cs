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
	public class AdminUserRoleDao : BaseDao<AdminUserRole>
	{
	    public List<AdminUserRole> GetAll()
	    {
	        var sql = Sql.Builder.Where("1=1");
	        return Query(sql).ToList();
	    }

	    public AdminUserRole GetByRoleId(int roleId)
	    {
	        var sql = Sql.Builder.Where("RoleId = @0", roleId);
	        return FirstOrDefault(sql);
	    }
	}
}

