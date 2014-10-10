
using System;
using System.Collections.Generic;
using WangFramework.MvcPager;
using W3WGame.Dao.Daos;
using W3WGame.Core.Dtos;
using W3WGame.Core.Entities;

namespace W3WGame.Task
{
	
	public  class FriendLinkTask
	{
	     private readonly FriendLinkDao _dao = new FriendLinkDao();
         public PagedList<FriendLink> GetPagedList(int? typeid, int pageIndex, int pageSize)
        {
            return _dao.GetPagedList(typeid, pageIndex, pageSize);
        }
        
         public FriendLink GetById(int id)
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
		
		public void Add(FriendLink model)
		{
			
             _dao.Add(model);
		}
		
		public void Update(FriendLink model)
		{
			
             _dao.Update(model);
		}
		
		public List<FriendLink> GetAll()
		{
		    return _dao.GetAll();
		}




	}
}