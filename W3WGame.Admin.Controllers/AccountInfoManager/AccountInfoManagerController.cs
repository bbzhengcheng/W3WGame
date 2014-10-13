
using System;
using System.Linq;
using System.Web.Mvc;
using W3WGame.Task;
using WangFramework.Mappers;
using WangFramework.Utility;
using WangFramework.MvcPager;
using WangFramework.Extensions;
using W3WGame.Core.Dtos;
using W3WGame.Core.Entities;
using W3WGame.Admin.Controllers.AccountInfoManager.ViewModels;

namespace W3WGame.Admin.Controllers.AccountInfoManager
{

    public class AccountInfoManagerController : BaseController
    {
        private readonly AccountInfoTask _accountinfoTask = new AccountInfoTask();

        public ActionResult List(string selecttype,string keyword,DateTime? startdate,DateTime? enddate, int pageIndex=1, int pageSize=20)
        {
            var pagedList = _accountinfoTask.GetPagedList(selecttype,keyword,startdate,enddate,pageIndex, pageSize);



            var model = new PagedList<AccountInfo>(pagedList.ToList(), pageIndex, pageSize, pagedList.TotalItemCount);

            return View(model);
        }


        public ActionResult Save(int? id)
        {


            var model = new SaveAccountInfo();

            if (id != null)
            {
                var item = _accountinfoTask.GetById((int)id);
                if (item == null)
                    return AlertMsg("参数错误", HttpContext.Request.UrlReferrer.PathAndQuery);

                model = EntityMapper.Map<AccountInfo, SaveAccountInfo>(item);
            }
            return View(model);
        }

        [HttpPost]
        public ActionResult Save(SaveAccountInfo savemodel)
        {


            if (ModelState.IsValid)
            {
                if (savemodel.ID == null)
                {
                    var model = new AccountInfo
                                    {
                                        Account = savemodel.Account,
                                        Password = savemodel.Password,
                                        NickName = savemodel.NickName,
                                        RegDate = savemodel.RegDate,
                                        RegIP = savemodel.RegIP,
                                       
                                        QQ = savemodel.QQ,
                                        Email = savemodel.Email,
                                        Phone = savemodel.Phone,
                                    };
                    _accountinfoTask.Add(model);
                }
                else
                {
                    var model = _accountinfoTask.GetById((int)savemodel.ID);

                    if (model == null)
                        return AlertMsg("参数错误", HttpContext.Request.UrlReferrer.PathAndQuery);
                    model.Account = savemodel.Account;
                    model.Password = savemodel.Password;
                    model.NickName = savemodel.NickName;
                    model.RegDate = savemodel.RegDate;
                    model.RegIP = savemodel.RegIP;
                  
                    model.QQ = savemodel.QQ;
                    model.Email = savemodel.Email;
                    model.Phone = savemodel.Phone;


                    _accountinfoTask.Update(model);
                }
                return AlertMsg("保存成功", HttpContext.Request.UrlReferrer.PathAndQuery);
            }
            return View(savemodel);
        }


        #region 删除用户信息 Delete

        [HttpPost]
        public void Delete(int id)
        {
            _accountinfoTask.Delete(id);
        }

        #endregion
    }
}