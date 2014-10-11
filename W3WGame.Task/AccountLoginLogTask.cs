
using System;
using WangFramework.MvcPager;
using W3WGame.Dao.Daos;
using W3WGame.Core.Dtos;
using W3WGame.Core.Entities;
using System.Collections.Generic;
using WangFramework.Utility;

namespace W3WGame.Task
{

    public class AccountLoginLogTask
    {
        private readonly AccountLoginLogDao _dao = new AccountLoginLogDao();
        public PagedList<AccountLoginLog> GetPagedList(int pageIndex, int pageSize)
        {
            return _dao.GetPagedList(pageIndex, pageSize);
        }

        public AccountLoginLog GetById(int id)
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

        public void Add(AccountLoginLog model)
        {

            _dao.Add(model);
        }

        public void Update(AccountLoginLog model)
        {

            _dao.Update(model);
        }

        public List<AccountLoginLog> GetAll(int? top, string strwhere)
        {
            return _dao.GetAll(top, strwhere);
        }

       


    }
}