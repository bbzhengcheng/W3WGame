
using System;
using W3WGame.Core.Dtos.Web;
using WangFramework.MvcPager;
using W3WGame.Dao.Daos;
using W3WGame.Core.Dtos;
using W3WGame.Core.Entities;
using System.Collections.Generic;

namespace W3WGame.Task
{

    public class AcceptKaDetailTask
    {
        private readonly AcceptKaDetailDao _dao = new AcceptKaDetailDao();
        public PagedList<AcceptKaDetail> GetPagedList(int pageIndex, int pageSize)
        {
            return _dao.GetPagedList(pageIndex, pageSize);
        }

        public PagedList<AcceptKaDetailDto> GetPagedList(string account,int? gameid, int? serverid, int? katype, int? accepyytpe, int pageIndex, int pageSize)
        {
            return _dao.GetPagedList(account,gameid, serverid, katype, accepyytpe, pageIndex, pageSize);
        }

        public AcceptKaDetail GetById(int id)
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

        public void Add(AcceptKaDetail model)
        {

            _dao.Add(model);
        }

        public void Update(AcceptKaDetail model)
        {

            _dao.Update(model);
        }

        public List<AcceptKaDetail> GetAll(int? top, string strwhere)
        {
            return _dao.GetAll(top, strwhere);
        }



    }
}