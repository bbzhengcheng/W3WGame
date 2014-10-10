using System;
using System.Collections.Generic;
using System.Linq;
using WangFramework.ORM;
using WangFramework.MvcPager;
using W3WGame.Core.Dtos;
using W3WGame.Core.Entities;

namespace W3WGame.Dao.Daos
{
	
	public  class ADConfigDao:BaseDao<ADConfig>
	{
	     public PagedList<ADConfig> GetPagedList(int? placeid,int pageIndex, int pageSize)
        {
            var sql = Sql.Builder.Where("1=1");
            if(placeid!=null)
            {
                sql.Where("Place = @0",placeid);
            }
            return PagedList<ADConfig>(pageIndex, pageSize, sql);
        }
        
         public ADConfig GetById(int id)
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

        public List<ADConfig> GetListBy(int placeid)
        {
            var sql = Sql.Builder.Where("Place = @0", placeid);
            sql.OrderBy("Sort");
            return Query(sql).ToList();
        }
		
				
	

   
	}
}