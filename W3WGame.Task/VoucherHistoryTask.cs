
using System;
using WangFramework.MvcPager;
using W3WGame.Dao.Daos;
using W3WGame.Core.Dtos;
using W3WGame.Core.Entities;

namespace W3WGame.Task
{
	
	public  class VoucherHistoryTask
	{
	     private readonly VoucherHistoryDao _dao = new VoucherHistoryDao();
	     public PagedList<VoucherHistory> GetPagedList(int pageIndex, int pageSize)
        {
            return _dao.GetPagedList(pageIndex,pageSize);
        }
        
         public VoucherHistory GetById(int id)
        {
            return _dao.GetById(id);
        }
        
          public void Delete(int id)
        {
            
            _dao.Delete(id);
        }
        
   		     
		public bool Exists(int id)
		{
			
            return _dao.Exists(id);
		}
		
		public void Add(VoucherHistory model)
		{
			
             _dao.Add(model);
		}
		
		public void Update(VoucherHistory model)
		{
			
             _dao.Update(model);
		}
		
		
		
		
   
	}
}