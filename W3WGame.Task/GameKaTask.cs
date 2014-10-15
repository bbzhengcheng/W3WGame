
using System;
using System.Collections.Generic;
using W3WGame.Core.Dtos.Web;
using WangFramework.MvcPager;
using W3WGame.Dao.Daos;
using W3WGame.Core.Dtos;
using W3WGame.Core.Entities;

namespace W3WGame.Task
{
	
	public  class GameKaTask
	{
	     private readonly GameKaDao _dao = new GameKaDao();
	     public PagedList<GameKa> GetPagedList(int pageIndex, int pageSize)
        {
            return _dao.GetPagedList(pageIndex,pageSize);
        }
        
         public GameKa GetById(int id)
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
		
		public void Add(GameKa model)
		{
			
             _dao.Add(model);
		}
		
		public void Update(GameKa model)
		{
			
             _dao.Update(model);
		}

        public List<GameKa>  GetAll(int? top ,string strWhere)
        {
            return _dao.GetAll(top, strWhere);
        }

        public List<GameKaDto> GetHomeList()
        {
            return _dao.GetHomeList();
        }

        public List<NewsKaDto> GetRanKa(int katype, int top)
        {
            return _dao.GetRanKa(katype, top);
        }

        public PagedList<NewsKaDto> GetKaPagedList(string title,int katype, int pageIndex, int pageSize)
        {
            return _dao.GetKaPagedList(title,katype, pageIndex, pageSize);
        }



	}
}