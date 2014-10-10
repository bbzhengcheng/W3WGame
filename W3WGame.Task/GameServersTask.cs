
using System;
using System.Collections.Generic;
using WangFramework.MvcPager;
using W3WGame.Dao.Daos;
using W3WGame.Core.Dtos;
using W3WGame.Core.Entities;

namespace W3WGame.Task
{
	
	public  class GameServersTask
	{
	     private readonly GameServersDao _dao = new GameServersDao();
         public PagedList<GameServers> GetPagedList(int? gameid, int? serverid, int pageIndex, int pageSize)
        {
            return _dao.GetPagedList(gameid,serverid,pageIndex,pageSize);
        }
        
         public GameServers GetById(int id)
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
		
		public void Add(GameServers model)
		{
			
             _dao.Add(model);
		}
		
		public void Update(GameServers model)
		{
			
             _dao.Update(model);
		}
        public List<GameServers> GetAll(int gameid)
        {
            return _dao.GetAll(gameid);
        }

        public List<GameServersDto> GetHomeServerList(int ServerState )
        {
            return _dao.GetHomeServerList(ServerState);
        }

        public List<GameServersDto> GetServerList(DateTime? starttime, DateTime? endtime,bool IsXinfu)
        {
            return _dao.GetServerList( starttime, endtime,IsXinfu);
        }


	}
}