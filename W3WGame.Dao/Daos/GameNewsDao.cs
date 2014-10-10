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

    public class GameNewsDao : BaseDao<GameNews>
    {
        public PagedList<GameNews> GetPagedList(int? platId, int? newstype, bool? isWeb, bool? isDisplayHome,int pageIndex, int pageSize)
        {
            var sql = Sql.Builder.Where("1=1");
            if(platId!=null)
            {
                sql.Where("GameID = @0", platId);
            }
            if(newstype !=null)
            {
                sql.Where("NewsType = @0", newstype);
            }
            if(isWeb !=null)
            {
                sql.Where("IsWeb = @0", isWeb);
            }
            if(isDisplayHome !=null)
            {
                sql.Where("IsDisplayHomePage = 1");
            }
            return PagedList<GameNews>(pageIndex, pageSize, sql);
        }

        public GameNews GetById(int id)
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

        public List<NewsDto> GetAll(int? top,string strwhere)
        {
            string topselect = top == null ? "" : "TOP " + top.ToString();
            var sql = Sql.Builder.Select(topselect + " ID,GameID,NewsType,Title,ShortDes,ShortDesImg,CreateDate ")
                .From("GameNews WITH(NOLOCK)");
            if(!string.IsNullOrEmpty(strwhere))
            {
                sql.Where(strwhere);
            }
            sql.OrderBy("CreateDate DESC");
            return Query<NewsDto>(sql).ToList();
        }



    }
}