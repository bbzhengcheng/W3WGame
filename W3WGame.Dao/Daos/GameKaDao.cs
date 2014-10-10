using System;
using System.Collections.Generic;
using System.Linq;
using W3WGame.Core.Dtos.Web;
using WangFramework.ORM;
using WangFramework.MvcPager;
using W3WGame.Core.Dtos;
using W3WGame.Core.Entities;

namespace W3WGame.Dao.Daos
{

    public class GameKaDao : BaseDao<GameKa>
    {
        public PagedList<GameKa> GetPagedList(int pageIndex, int pageSize)
        {
            var sql = Sql.Builder.Where("1=1");

            return PagedList<GameKa>(pageIndex, pageSize, sql);
        }

        public List<GameKaDto> GetHomeList()
        {
            var sql =
                Sql.Builder.Append(
                    @"SELECT TOP 6 mg.GameName,gk.GameID,gk.ID,ServerID,gk.KaTitle ,mg.ImgPath FROM dbo.GameKa gk 
LEFT JOIN dbo.MobilGame mg ON gk.GameID = mg.ID
WHERE gk.IsDisplayHome=1 ORDER BY StartDate Desc");
            return Query<GameKaDto>(sql).ToList();
        }
        public GameKa GetById(int id)
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

        public List<GameKa> GetAll(int? top, string strwhere)
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
            var sql = Sql.Builder.Select(sqltop).From("MobilGame WITH(NOLOCK)");
            if (!string.IsNullOrEmpty(strwhere))
            {
                sql.Where(strwhere);
            }
            sql.OrderBy("CreateDate Desc");
            return Query<GameKa>(sql).ToList();
        }





    }
}