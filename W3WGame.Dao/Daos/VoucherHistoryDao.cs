using System;
using WangFramework.ORM;
using WangFramework.MvcPager;
using W3WGame.Core.Dtos;
using W3WGame.Core.Entities;

namespace W3WGame.Dao.Daos
{
	
	public  class VoucherHistoryDao:BaseDao<VoucherHistory>
	{
	     public PagedList<VoucherHistory> GetPagedList(int pageIndex, int pageSize)
        {
            var sql = Sql.Builder.Where("1=1");
           
            return PagedList<VoucherHistory>(pageIndex, pageSize, sql);
        }
        
         public VoucherHistory GetById(int id)
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
		
				
	

   
	}
}