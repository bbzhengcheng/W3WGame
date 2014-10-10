
using System;
using WangFramework.MvcPager;
using W3WGame.Dao.Daos;
using W3WGame.Core.Dtos;
using W3WGame.Core.Entities;

namespace W3WGame.Task
{
	
	public  class WebLoginLogTask
	{
	     private readonly WebLoginLogDao _dao = new WebLoginLogDao();
	     public PagedList<WebLoginLog> GetPagedList(int pageIndex, int pageSize)
        {
            return _dao.GetPagedList(pageIndex,pageSize);
        }
        
         public WebLoginLog GetById(int id)
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
		
		public void Add(WebLoginLog model)
		{
			
             _dao.Add(model);
		}
		
		public void Update(WebLoginLog model)
		{
			
             _dao.Update(model);
		}
		
		
		
		
   
	}
}