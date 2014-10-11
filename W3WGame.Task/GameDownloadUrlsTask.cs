
using System;
using W3WGame.Core.Dtos.Web;
using WangFramework.MvcPager;
using W3WGame.Dao.Daos;
using W3WGame.Core.Dtos;
using W3WGame.Core.Entities;
using System.Collections.Generic;

namespace W3WGame.Task
{

    public class GameDownloadUrlsTask
    {
        private readonly GameDownloadUrlsDao _dao = new GameDownloadUrlsDao();
        public PagedList<GameDownloadUrls> GetPagedList(int? gameid,int pageIndex, int pageSize)
        {
            return _dao.GetPagedList(gameid,pageIndex, pageSize);
        }

        public GameDownloadUrls GetById(int id)
        {
            return _dao.GetById(id);
        }

        public List<GameDownloadDto> GetRandTop50()
        {
            return _dao.GetRandTop50();
        }

        public void Delete(int id)
        {

            _dao.Delete(id);
        }

        public GameDownloadUrls GetById(int gameid, int sysid)
        {
            return _dao.GetById(gameid, sysid);
        }

        public bool Exists(int gameid,int sysid)
        {

            return _dao.Exists(gameid,sysid);
        }

        public void Add(GameDownloadUrls model)
        {

            _dao.Add(model);
        }

        public void Update(GameDownloadUrls model)
        {

            _dao.Update(model);
        }

        public List<GameDownloadUrls> GetAll(int? top, string strwhere)
        {
            return _dao.GetAll(top, strwhere);
        }



    }
}