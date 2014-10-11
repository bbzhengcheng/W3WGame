using System;
using WangFramework.ORM;
using WangFramework.MvcPager;
using W3WGame.Core.Dtos;
using W3WGame.Core.Entities;

namespace W3WGame.Dao.Daos
{
	
	public  class AccountInfoDao:BaseDao<AccountInfo>
	{
        public PagedList<AccountInfo> GetPagedList(string selecttype, string keyword, DateTime? startdate, DateTime? enddate, int pageIndex, int pageSize)
        {
            var sql = Sql.Builder.Where("1=1");
            if(!string.IsNullOrEmpty(keyword))
            {
                sql.Where("@0 = @1", selecttype, keyword);
            }
            if(startdate !=null)
            {
                sql.Where("CreateDate > @0", startdate);
            }
            if(enddate !=null)
            {
                sql.Where("CreateDate <@0", enddate);
            }
            return PagedList<AccountInfo>(pageIndex, pageSize, sql);
        }
        
         public AccountInfo GetById(int id)
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

        public bool Exists(string account)
        {
            var sql = Sql.Builder.Where("Account = @0", account);
            if (FirstOrDefault(sql) != null)
            {
                return true;
            }
            return false;
        }

        public bool ExistsEmail(string email)
        {
            var sql = Sql.Builder.Where("Email = @0", email);
            if (FirstOrDefault(sql) != null)
            {
                return true;
            }
            return false;
        }



        public AccountInfo GetAccount(string account)
        {
            var sql = Sql.Builder.Where("Account = @0", account);
            return FirstOrDefault(sql);
        }




	}
}