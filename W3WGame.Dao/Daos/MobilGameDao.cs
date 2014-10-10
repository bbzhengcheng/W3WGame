using System;
using System.Collections.Generic;
using System.Linq;
using WangFramework.ORM;
using WangFramework.MvcPager;
using W3WGame.Core.Dtos;
using W3WGame.Core.Entities;

namespace W3WGame.Dao.Daos
{
	
	public  class MobilGameDao:BaseDao<MobilGame>
	{
	     public PagedList<MobilGame> GetPagedList(bool? isAndior,bool? isIOS,bool? hasGift,
             bool? isHot,bool? isNew,bool? IsBiWan,bool? isThisAweekHot,bool? isTuiJian,int? gameType,int? gameTeZhen,int? yunyingState,bool? isQianLiBao,bool? isGameType,
             int pageIndex, int pageSize)
        {
            var sql = Sql.Builder.Where("1=1");
            if (isAndior !=null)
            {
                sql.Where("IsAndior = 1");
            }
            if (isIOS != null)
            {
                sql.Where("isIOS = 1");
            }
            if (hasGift != null)
            {
                sql.Where("hasGift = 1");
            }
            if (isHot != null)
            {
                sql.Where("isHot = 1");
            }
            if (isNew != null)
            {
                sql.Where("isNew = 1");
            }
            if (IsBiWan != null)
            {
                sql.Where("IsBiWan = 1");
            }
            if (isThisAweekHot != null)
            {
                sql.Where("isThisAweekHot = 1");
            } if (isTuiJian != null)
            {
                sql.Where("isTuiJian = 1");
            }
            if (gameType != null)
            {
                sql.Where("gameType = @0",gameType);
            }
            if (gameTeZhen != null)
            {
                sql.Where("gameTeZhen = @0", gameTeZhen);
            }
            if (yunyingState != null)
            {
                sql.Where("yunyingState = @0", yunyingState);
            }
            if (isQianLiBao != null)
            {
                sql.Where("isQianLiBao = 1");
            }
            if (isGameType != null)
            {
                sql.Where("isGameType = 1");
            }
            return PagedList<MobilGame>(pageIndex, pageSize, sql);
        }
        
         public MobilGame GetById(int id)
        {
            var sql = Sql.Builder.Where("id = @0", id);
            return FirstOrDefault(sql);
        }
        
          public void Delete(int id)
        {
            var sql = Sql.Builder.Where("ID = @0", id);
            Delete(sql);
        }
        
        public List<MobilGame> GetAll(int? top,string strwhere)
        {
            string sqltop = "";
            if(top !=null)
            {
                sqltop = "TOP " + top.ToString() + " * ";
            }
            else
            {
                sqltop = " * ";
            }
            var sql = Sql.Builder.Select(sqltop).From("MobilGame WITH(NOLOCK)");
            if(!string.IsNullOrEmpty(strwhere))
            {
                sql.Where(strwhere);
            }
            sql.OrderBy("Sort ASC");
            return Query<MobilGame>(sql).ToList();
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
		
				
	

   
	}
}