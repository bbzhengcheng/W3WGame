
using System;
using System.Collections.Generic;
using WangFramework.MvcPager;
using W3WGame.Dao.Daos;
using W3WGame.Core.Dtos;
using W3WGame.Core.Entities;

namespace W3WGame.Task
{
	
	public  class ADConfigTask
	{
	     private readonly ADConfigDao _dao = new ADConfigDao();
	     public PagedList<ADConfig> GetPagedList(int? placeid,int pageIndex, int pageSize)
        {
            return _dao.GetPagedList(placeid,pageIndex,pageSize);
        }
        
         public ADConfig GetById(int id)
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
		
		public void Add(ADConfig model)
		{
			
             _dao.Add(model);
		}
		
		public void Update(ADConfig model)
		{
			
             _dao.Update(model);
		}
        public List<ADConfig> GetListBy(int placeid)
        {
            return _dao.GetListBy(placeid);
        }




	}
}