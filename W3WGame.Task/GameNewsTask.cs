
using System;
using System.Collections.Generic;
using W3WGame.Core.Dtos.Web;
using WangFramework.MvcPager;
using W3WGame.Dao.Daos;
using W3WGame.Core.Dtos;
using W3WGame.Core.Entities;

namespace W3WGame.Task
{
	
	public  class GameNewsTask
	{
	     private readonly GameNewsDao _dao = new GameNewsDao();
         public PagedList<GameNews> GetPagedList(int? platId, int? newstype, bool? isWeb,bool? isDisplayHome, int pageIndex, int pageSize)
        {
            return _dao.GetPagedList(platId,newstype,isWeb,isDisplayHome,pageIndex,pageSize);
        }
        
         public GameNews GetById(int id)
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
		
		public void Add(GameNews model)
		{
			
             _dao.Add(model);
		}
		
		public void Update(GameNews model)
		{
			
             _dao.Update(model);
		}
        public List<NewsDto> GetAll(int? top, string strwhere)
        {
            return _dao.GetAll(top, strwhere);
        }
        public List<GameNewsDto> GetGameNewsList(int gameid)
        {
            return _dao.GetGameNewsList(gameid);
        }

	}
}