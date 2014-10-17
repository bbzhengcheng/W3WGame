using System;
using System.Collections.Generic;
using System.Linq;
using WangFramework.ORM;
using WangFramework.MvcPager;
using W3WGame.Core.Dtos;
using W3WGame.Core.Entities;

namespace W3WGame.Dao.Daos
{
	
	public  class GameServersDao:BaseDao<GameServers>
	{
        public PagedList<GameServers> GetPagedList(int? gameid, int? serverid, int pageIndex, int pageSize)
        {
            var sql = Sql.Builder.Where("1=1");
            if(gameid!=null)
            {
                sql.Where("GameID = @0", gameid);
            }
            if(serverid !=null)
            {
                sql.Where("ServerID = @0", serverid);
            }
            return PagedList<GameServers>(pageIndex, pageSize, sql);
        }
        
         public GameServers GetById(int id)
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
            if(FirstOrDefault(sql)!=null)
            {
                return true;
            }
            return false;
		}
		
	    
        public List<GameServers> GetAll(int gameid)
        {
            var sql = Sql.Builder.Where("GameID = @0", gameid);
            return Query<GameServers>(sql).ToList();
        }

        public List<GameServers> GetAll(int? top, string strwhere)
        {
            string topselect = top == null ? "" : "TOP " + top.ToString();
            var sql = Sql.Builder.Select(topselect + "  * ")
                .From("GameServers WITH(NOLOCK)");
            if (!string.IsNullOrEmpty(strwhere))
            {
                sql.Where(strwhere);
            }
            sql.OrderBy("OpenTime DESC");
            return Query<GameServers>(sql).ToList();
        }


	    public List<GameServersDto> GetHomeServerList(int serverState)
	    {
	        var sql =
                Sql.Builder.Append("SELECT TOP 12 a.*,b.GameName,b.ImgPath FROM GameServers a WITH(NOLOCK) LEFT JOIN MobilGame b WITH(NOLOCK) ON a.GameID = b.ID WHERE ServerStat = @0", serverState);
	        return Query<GameServersDto>(sql).ToList();
	    }

        public List<GameServersDto> GetServerList(DateTime? starttime,DateTime? endtime,bool IsXinfu)
        {
            var sql =
                Sql.Builder.Append("SELECT TOP 12 a.*,b.GameName,b.ImgPath,b.GameType,b.HotScore,b.YunYingState FROM GameServers a WITH(NOLOCK) LEFT JOIN MobilGame b WITH(NOLOCK) ON a.GameID = b.ID WHERE 1=1 ");
            if(starttime !=null)
            {
                sql.Append(" AND a.OpenTime > @0", starttime);
            }
            if(endtime !=null)
            {
                sql.Append(" AND a.OpenTime <@0", endtime);
            }
           if(IsXinfu)
           {
                sql.Append(" AND a.ServerStat = 3");
           }
           else
           {
               sql.Append(" AND a.ServerStat != 3");
           }
            return Query<GameServersDto>(sql).ToList();
        }

	}
}