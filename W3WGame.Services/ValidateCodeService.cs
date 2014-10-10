using System.Configuration;
using System.Drawing;
using System.Web;
using WangFramework.Utility;

namespace W3WGame.Services
{
    public class ValidateCodeService
    {
        private static readonly string ValidCodeSessionName = ConfigurationManager.AppSettings["ValidCodeName"] ??
                                                           "ValidCodeSessionName";

        public Image CreateCode()
        {
            var validateCode = new ValidateCode();
            string code;
            var image = validateCode.CreateImage(80, 20, out code);
            HttpContext.Current.Session[ValidCodeSessionName] = code;
            return image;
        }

        public bool CheckCode(string validateCode)
        {
            var isOK = !string.IsNullOrEmpty(validateCode)
                   && HttpContext.Current.Session[ValidCodeSessionName] != null
                   && HttpContext.Current.Session[ValidCodeSessionName].ToString().ToLower() == validateCode.ToLower();
            return isOK;
        }

        public void ClearSession()
        {
            if (HttpContext.Current.Session[ValidCodeSessionName] != null)
                HttpContext.Current.Session.Remove(ValidCodeSessionName);
        }
    }
}