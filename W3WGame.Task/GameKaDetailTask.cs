
using System;
using WangFramework.MvcPager;
using W3WGame.Dao.Daos;
using W3WGame.Core.Dtos;
using W3WGame.Core.Entities;

namespace W3WGame.Task
{
	
	public  class GameKaDetailTask
	{
	     private readonly GameKaDetailDao _dao = new GameKaDetailDao();
	     public PagedList<GameKaDetail> GetPagedList(int pageIndex, int pageSize)
        {
            return _dao.GetPagedList(pageIndex,pageSize);
        }
        
         public GameKaDetail GetById(int id)
        {
            return _dao.GetById(id);
        }
        
          public void Delete(int id)
        {
            
            _dao.Delete(id);
        }
          public bool ExistsCode(string code)
          {
              return _dao.ExistsCode(code);
          }

	    public bool Exists(int id)
		{
			
            return _dao.Exists(id);
		}
		
		public void Add(GameKaDetail model)
		{
			
             _dao.Add(model);
		}
		
		public void Update(GameKaDetail model)
		{
			
             _dao.Update(model);
		}
		
		
		
		
   
	}
}