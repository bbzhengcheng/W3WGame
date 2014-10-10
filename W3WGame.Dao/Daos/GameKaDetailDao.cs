using System;
using WangFramework.ORM;
using WangFramework.MvcPager;
using W3WGame.Core.Dtos;
using W3WGame.Core.Entities;

namespace W3WGame.Dao.Daos
{

    public class GameKaDetailDao : BaseDao<GameKaDetail>
    {
        public PagedList<GameKaDetail> GetPagedList(int pageIndex, int pageSize)
        {
            var sql = Sql.Builder.Where("1=1");

            return PagedList<GameKaDetail>(pageIndex, pageSize, sql);
        }

        public GameKaDetail GetById(int id)
        {
            var sql = Sql.Builder.Where("id = @0", id);
            return FirstOrDefault(sql);
        }

        public void Delete(int id)
        {
            var sql = Sql.Builder.Where("ID = @0", id);
            Delete(sql);
        }
        public bool ExistsCode(string code)
        {
            var sql = Sql.Builder.Where("Code = @0", code);
            if (FirstOrDefault(sql) != null)
            {
                return true;
            }
            return false;
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





    }
}