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
    public class AdminRoleMenuDao : BaseDao<AdminRoleMenu>
    {
        public List<AdminRoleMenu> GetListByRoleId(int roleId)
        {
            var sql = Sql.Builder.Where("RoleId = @0", roleId);
            return Query(sql).ToList();
        }

        public void DeleteByRoleId(int roleId)
        {
            var sql = Sql.Builder.Where("RoleId = @0", roleId);
            Delete(sql);
        }

        public List<AdminMenu> GetMenuLstByRoleId(int roleId)
        {
            var sql = Sql.Builder
                .Append("SELECT * FROM AdminMenu")
                .Where("MenuId IN (SELECT MenuId FROM AdminRoleMenu WHERE RoleId = @0)", roleId);
            return Query<AdminMenu>(sql).ToList();
        }
    }
}

