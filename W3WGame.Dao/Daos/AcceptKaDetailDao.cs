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

    public class AcceptKaDetailDao : BaseDao<AcceptKaDetail>
    {
        public PagedList<AcceptKaDetail> GetPagedList(int pageIndex, int pageSize)
        {
            var sql = Sql.Builder.Where("1=1");

            return PagedList<AcceptKaDetail>(pageIndex, pageSize, sql);
        }

        public PagedList<AcceptKaDetailDto> GetPagedList(string account,int? gameid, int? serverid, int? katype, int? accepyytpe, int pageIndex, int pageSize)
        {
            var sql = Sql.Builder.Select("akd.*,mg.GameName,mg.ImgPath,gk.KaTitle,gk.StartDate,gk.EndDate ")
                .From(
                    " dbo.AcceptKaDetail akd LEFT JOIN dbo.GameKa gk ON akd.KaID = gk.ID LEFT JOIN dbo.MobilGame mg ON akd.GameID = mg.ID")
                ;
            if(gameid !=null)
            {
                sql.Where("akd.GameID = @0", gameid);
            }
            if(serverid !=null)
            {
                sql.Where("akd.ServerID = @0", serverid);
            }
            if(katype !=null)
            {
                sql.Where("gk.KaType = @0", katype);
            }
            if(accepyytpe !=null)
            {
                sql.Where("akd.AcceptType = @0",accepyytpe);
            }
            if(string.IsNullOrEmpty(account))
            {
                sql.Where("akd.Account = @0", account);
            }
            return PagedList<AcceptKaDetailDto>(pageIndex, pageSize, sql);
        }


        public AcceptKaDetail GetById(int id)
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

        public List<AcceptKaDetail> GetAll(int? top, string strwhere)
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
            var sql = Sql.Builder.Select(sqltop).From(" AcceptKaDetail WITH(NOLOCK)");
            if (!string.IsNullOrEmpty(strwhere))
            {
                sql.Where(strwhere);
            }
            sql.OrderBy("CreateDate Desc");
            return Query<AcceptKaDetail>(sql).ToList();
        }



    }
}