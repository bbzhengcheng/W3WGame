
using System;
using WangFramework.MvcPager;
using W3WGame.Dao.Daos;
using W3WGame.Core.Dtos;
using W3WGame.Core.Entities;
using WangFramework.Utility;

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
        public AccountInfo GetAccount(string account)
        {
            return _dao.GetAccount(account);
        }

        public bool Exists(string account)
        {
            return _dao.Exists(account);
        }

        public bool ExistsEmail(string email)
        {
            return _dao.ExistsEmail(email);
        }
        /// <summary>
        /// 注册
        /// </summary> 
        public AccountInfo Register(string account, string password,string nickname, string email,string qq, string ipAddress)
        {
            var userInfo = new AccountInfo
            {
                Email = email,
                Account = account,
              
                Password = CryptTools.HashPassword(password),
                Phone = string.Empty,
                RegDate = DateTime.Now,
                RegIP = ipAddress,
                QQ = qq,
                NickName = nickname,

            };
            var userId = Convert.ToInt32(_dao.Add(userInfo));
            userInfo.ID = userId;
            return userInfo;
        }

        /// <summary>
        /// 修改密码
        /// </summary> 
        public void ChangePassword(string account, string newPassword)
        {
            var userInfo = _dao.GetAccount(account);
            if (userInfo != null)
            {
                userInfo.Password = CryptTools.HashPassword(newPassword);
                _dao.Update(userInfo);
            }
        }

    }
}