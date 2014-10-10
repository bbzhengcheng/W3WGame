using System;
using System.Collections.Generic;
using System.Linq;
using WangFramework.ORM;
using WangFramework.MvcPager;
using W3WGame.Core.Dtos;
using W3WGame.Core.Entities;

namespace W3WGame.Dao.Daos
{
	
	public  class FriendLinkDao:BaseDao<FriendLink>
	{
        public PagedList<FriendLink> GetPagedList(int? typeid, int pageIndex, int pageSize)
        {
            var sql = Sql.Builder.Where("1=1");
            if (typeid != null)
            {
                sql.Where("LinkType = @0", typeid);
            }
            return PagedList<FriendLink>(pageIndex, pageSize, sql);
        }
        
         public FriendLink GetById(int id)
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


	    public List<FriendLink> GetAll()
	    {
	        var sql = Sql.Builder.Where("1=1");
	        return Query(sql).ToList();
	    }
	}
}