using System;
using System.Collections.Generic;
using System.Linq;
using WangFramework.ORM;
using WangFramework.MvcPager;
using W3WGame.Core.Dtos;
using W3WGame.Core.Entities;

namespace W3WGame.Dao.Daos
{

    public class AccountLoginLogDao : BaseDao<AccountLoginLog>
    {
        public PagedList<AccountLoginLog> GetPagedList(int pageIndex, int pageSize)
        {
            var sql = Sql.Builder.Where("1=1");

            return PagedList<AccountLoginLog>(pageIndex, pageSize, sql);
        }

        public AccountLoginLog GetById(int id)
        {
            var sql = Sql.Builder.Where("id = @0", id);
            return FirstOrDefault(sql);
        }

        public void Delete(int id)
        {
            var sql = Sql.Builder.Where("ID = @0", id);
            Delete(sql);
        }


        public bool Exists(int id)
        {
            var sql = Sql.Builder.Where("ID = @0", id);
            if (FirstOrDefault(sql) != null)
            {
                return true;
            }
            return false;
        }

        public List<AccountLoginLog> GetAll(int? top, string strwhere)
        {
            string sqltop = "";
            if (top != null)
            {
                sqltop = "TOP " + top.ToString() + " * ";
            }
            else
            {
                sqltop = " * ";
            }
            var sql = Sql.Builder.Select(sqltop).From(" AccountLoginLog WITH(NOLOCK)");
            if (!string.IsNullOrEmpty(strwhere))
            {
                sql.Where(strwhere);
            }
            sql.OrderBy("CreateDate Desc");
            return Query<AccountLoginLog>(sql).ToList();
        }



    }
}