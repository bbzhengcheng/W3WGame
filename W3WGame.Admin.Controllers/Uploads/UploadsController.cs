using System;
using System.Collections;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using W3WGame.Admin.Controllers.Uploads.ViewModels;
using W3WGame.Core.Entities;
using W3WGame.Services;
using W3WGame.Task;
using WangFramework.Mappers;
using WangFramework.MvcPager;

namespace W3WGame.Admin.Controllers.Uploads
{
    public class UploadsController : BaseController
    {
      

        [HttpPost]
        public ActionResult SaveSystemImage()
        {
            var hash = new Hashtable();

            if (Request.Files.Count == 0 || Request.Files[0] == null || Request.Files[0].ContentLength == 0)
            {
                hash["error"] = 1;
                hash["message"] = "上传的图片不能为空";
                var result = Json(hash, JsonRequestBehavior.AllowGet);
                result.ContentType = "text/html";
                return result;
            }

            string errMsg, savePath;
            if (!UploadService.UploadSystemImage(Request.Files[0], out errMsg, out savePath))
            {
                hash["error"] = 1;
                hash["message"] = errMsg;
                var result = Json(hash, JsonRequestBehavior.AllowGet);
                result.ContentType = "text/html";
                return result;
            }
            else
            {
                hash["error"] = 0;
                hash["url"] = savePath;
                var result = Json(hash, JsonRequestBehavior.AllowGet);
                result.ContentType = "text/html";
                return result;
            }
        }

        [HttpPost]
        public ActionResult SaveGoodsImage()
        {
            var hash = new Hashtable();
            if (Request.Files.Count == 0 || Request.Files[0] == null || Request.Files[0].ContentLength == 0)
            {
                hash["error"] = 1;
                hash["message"] = "上传的图片不能为空";
                return Json(hash, JsonRequestBehavior.AllowGet);
            }

            string errMsg, savePath;
            if (!UploadService.UploadGoodsImage(Request.Files[0], out errMsg, out savePath))
            {
                hash["error"] = 1;
                hash["message"] = errMsg;
                return Json(hash, JsonRequestBehavior.AllowGet);
            }
            else
            {
               
                hash["error"] = 0;
                hash["url"] = savePath;
                return Json(hash, JsonRequestBehavior.AllowGet);
            }
        }


        [HttpPost]
        public ActionResult UploadGoodsImg()
        {
            var hash = new Hashtable();
            if (Request.Files.Count == 0 || Request.Files[0] == null || Request.Files[0].ContentLength == 0)
                return AlertMsg("请选择要上传的图片", Request.UrlReferrer.PathAndQuery);

            string errMsg, savePath;
            if (!UploadService.UploadGoodsImage(Request.Files[0], out savePath, out errMsg))
                return AlertMsg(errMsg, Request.UrlReferrer.PathAndQuery);
            else
            {
               
                return AlertMsg("上传成功", Request.UrlReferrer.PathAndQuery);
            }
        }

        [HttpPost]
        public ActionResult UploadFile()
        {
            if (Request.Files.Count == 0 || Request.Files[0] == null || Request.Files[0].ContentLength == 0)
                return AlertMsg("请选择要上传的文件", Request.UrlReferrer.PathAndQuery);

            string errMsg, savePath;
            if (!UploadService.UploadFile(Request.Files[0], out savePath, out errMsg))
                return AlertMsg(errMsg, Request.UrlReferrer.PathAndQuery);
            else
            {
                return AlertMsg("上传成功", Request.UrlReferrer.PathAndQuery);
            }

        }

       
    }
}