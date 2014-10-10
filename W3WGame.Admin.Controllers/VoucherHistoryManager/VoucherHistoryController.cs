
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
using W3WGame.Admin.Controllers.VoucherHistoryManager.ViewModels;

namespace W3WGame.Admin.Controllers.VoucherHistoryManager
{

    public class VoucherHistoryManagerController : BaseController
    {
        private readonly VoucherHistoryTask _voucherhistoryTask = new VoucherHistoryTask();
        private readonly MobilGameTask _mobilGameTask = new MobilGameTask();

        public ActionResult List(int pageIndex = 1, int pageSize = 20)
        {
            var pagedList = _voucherhistoryTask.GetPagedList(pageIndex, pageSize);
            var gamelist = _mobilGameTask.GetAll(null, "").ToSelectList(c => c.ID.ToString(), c => c.GameName);
            gamelist.Insert(0, new SelectListItem
            {
                Selected = true,
                Text = "请选择",
                Value = string.Empty
            });
            ViewData["gamelist"] = gamelist;


            var model = new PagedList<VoucherHistory>(pagedList.ToList(), pageIndex, pageSize, pagedList.TotalItemCount);

            return View(model);
        }


        public ActionResult Save(int? id)
        {


            var model = new SaveVoucherHistory();

            if (id != null)
            {
                var item = _voucherhistoryTask.GetById((int)id);
                if (item == null)
                    return AlertMsg("参数错误", HttpContext.Request.UrlReferrer.PathAndQuery);

                model = EntityMapper.Map<VoucherHistory, SaveVoucherHistory>(item);
            }
            return View(model);
        }

        [HttpPost]
        public ActionResult Save(SaveVoucherHistory savemodel)
        {


            if (ModelState.IsValid)
            {
                if (savemodel.ID == null)
                {
                    var model = new VoucherHistory
                                    {

                                    };
                    _voucherhistoryTask.Add(model);
                }
                else
                {
                    var model = _voucherhistoryTask.GetById((int)savemodel.ID);

                    if (model == null)
                        return AlertMsg("参数错误", HttpContext.Request.UrlReferrer.PathAndQuery);




                    _voucherhistoryTask.Update(model);
                }
                return AlertMsg("保存成功", HttpContext.Request.UrlReferrer.PathAndQuery);
            }
            return View(savemodel);
        }


    }
}