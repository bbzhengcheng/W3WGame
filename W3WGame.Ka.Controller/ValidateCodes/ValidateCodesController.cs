using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using W3WGame.Services;

namespace W3WGame.Ka.Controller.ValidateCodes
{
    public class ValidateCodesController : BaseController
    {
        private readonly ValidateCodeService _validateCodeService = new ValidateCodeService();

        public void Create()
        {
            var image = _validateCodeService.CreateCode();
            image.Save(Response.OutputStream, ImageFormat.Jpeg);
        }

        public ActionResult Check(string validateCode)
        {
            var isOK = _validateCodeService.CheckCode(validateCode);
            return Json(isOK, JsonRequestBehavior.AllowGet);
        }
    }
}
