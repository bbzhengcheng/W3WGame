
using System;
using WangFramework.MvcPager;
using W3WGame.Dao.Daos;
using W3WGame.Core.Dtos;
using W3WGame.Core.Entities;

namespace W3WGame.Task
{

    public class AccountInfoTask
    {
        private readonly AccountInfoDao _dao = new AccountInfoDao();
        public PagedList<AccountInfo> GetPagedList(string selecttype, string keyword, DateTime? startdate, DateTime? enddate, int pageIndex, int pageSize)
        {
            return _dao.GetPagedList(selecttype,keyword,startdate,enddate,pageIndex, pageSize);
        }

        public AccountInfo GetById(int id)
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

        public void Add(AccountInfo model)
        {

            _dao.Add(model);
        }

        public void Update(AccountInfo model)
        {

            _dao.Update(model);
        }





    }
}