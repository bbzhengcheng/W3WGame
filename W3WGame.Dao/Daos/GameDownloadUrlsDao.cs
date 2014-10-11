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

    public class GameDownloadUrlsDao : BaseDao<GameDownloadUrls>
    {
        public PagedList<GameDownloadUrls> GetPagedList(int? gameid, int pageIndex, int pageSize)
        {
            var sql = Sql.Builder.Where("1=1");
            if (gameid != null)
            {
                sql.Where("GameiD =@0", gameid);
            }
            return PagedList<GameDownloadUrls>(pageIndex, pageSize, sql);
        }

        public GameDownloadUrls GetById(int id)
        {
            var sql = Sql.Builder.Where("id = @0", id);
            return FirstOrDefault(sql);
        }

        public GameDownloadUrls GetById(int gameid, int sysid)
        {
            var sql = Sql.Builder.Where("GameID = @0 AND GameSys = @1", gameid, sysid);
            return FirstOrDefault(sql);
        }

        public void Delete(int id)
        {
            var sql = Sql.Builder.Where("ID = @0", id);
            Delete(sql);
        }


        public bool Exists(int gameid, int sysid)
        {
            var sql = Sql.Builder.Where("GameID = @0 AND GameSys = @1", gameid, sysid);

            if (FirstOrDefault(sql) != null)
            {
                return true;
            }
            return false;
        }
        public List<GameDownloadDto> GetRandTop50()
        {
            var sql = Sql.Builder.Append(@"SELECT a.*,mg.GameName,mg.ImgPath,mg.HotScore,mg.Size,mg.YunYingState FROM MobilGame mg
LEFT JOIN  (SELECT top 80 g.GameID,COUNT(g.[Count]) AS [Count] FROM GameDownloadUrls g WITH(NOLOCK) GROUP BY g.GameID) a ON mg.ID = a.GameID 
ORDER BY a.[Count] Desc");
            return Query<GameDownloadDto>(sql).ToList();
        }

        public List<GameDownloadUrls> GetAll(int? top, string strwhere)
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
            var sql = Sql.Builder.Select(sqltop).From(" GameDownloadUrls WITH(NOLOCK)");
            if (!string.IsNullOrEmpty(strwhere))
            {
                sql.Where(strwhere);
            }
            sql.OrderBy("CreateDate Desc");
            return Query<GameDownloadUrls>(sql).ToList();
        }



    }
}