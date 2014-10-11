
using System;
using System.Collections.Generic;
using WangFramework.MvcPager;
using W3WGame.Dao.Daos;
using W3WGame.Core.Dtos;
using W3WGame.Core.Entities;

namespace W3WGame.Task
{
	
	public  class MobilGameTask
	{
	     private readonly MobilGameDao _dao = new MobilGameDao();
         public PagedList<MobilGame> GetPagedList(int? gamesys, bool? hasGift,
             bool? isHot, bool? isNew, bool? IsBiWan, bool? isThisAweekHot, bool? isTuiJian, int? gameType, int? gameTeZhen, int? yunyingState, bool? isQianLiBao, bool? isGameType,
             int pageIndex, int pageSize)
        {
            return _dao.GetPagedList(gamesys, hasGift,
              isHot, isNew, IsBiWan, isThisAweekHot,isTuiJian, gameType, gameTeZhen, yunyingState,  isQianLiBao, isGameType,
             pageIndex, pageSize);
        }
        
         public MobilGame GetById(int id)
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
		
		public void Add(MobilGame model)
		{
			
             _dao.Add(model);
		}
		
		public void Update(MobilGame model)
		{
			
             _dao.Update(model);
		}

        public List<MobilGame> GetAll(int? top, string strwhere)
        {
            return _dao.GetAll(top, strwhere);
        }





	}
}