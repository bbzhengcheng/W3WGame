﻿using System;
using System.Collections.Generic;
using W3WGame.Core.Entities;
using W3WGame.Dao.Daos;
namespace W3WGame.Task
{
    /// <summary>
    ///
    /// </summary>
    public class AdminMenuTask
    {
        private readonly AdminMenuDao _adminMenu = new AdminMenuDao();

        public IEnumerable<AdminMenu> GetAll()
        {
            return _adminMenu.GetAll();
        }

        public List<AdminMenu> GetParentList()
        {
            return _adminMenu.GetParentList();
        }

        public AdminMenu GetByMenuId(int menuid)
        {
            return _adminMenu.GetByMenuId(menuid);
        }

        public void Add(AdminMenu info)
        {
            _adminMenu.Add(info);
        }

        public void Update(AdminMenu info)
        {
            _adminMenu.Update(info);
        }

        public void DeleteByMenuId(int menuId)
        {
            _adminMenu.DeleteByMenuId(menuId);
        }
    }
}

