using System;
using System.Linq;
using System.Web;
using WangFramework.Common;

namespace W3WGame.Services.web
{
   public static class FormsAuthServiceCookie
   {
       /// <summary>
       /// COOKIE名称
       /// </summary>
       private const string SignInCookieName = "W3WGameDomainAuth";
       private static readonly string Domain = "";


       /// <summary>
       /// 超时时间（分钟）
       /// </summary>
       private const int TimeoutMins = 1000;

       public static void SignIn(string userName, bool createPersistentCookie)
       {
           var context = HttpContext.Current;
           var cookie = context.Request.Cookies[SignInCookieName];
           var timeOut = DateTime.Now.AddMinutes(TimeoutMins);


           if (cookie != null)
           {
               if (!string.IsNullOrEmpty(Domain))
                   cookie.Domain = Domain;
               cookie["Token"] = DES.EncryptDES(string.Format("{0}[&]{1}", userName, timeOut.ToString()));
               context.Response.SetCookie(cookie);
           }
           else
           {
               cookie = new HttpCookie(SignInCookieName);
               if (!string.IsNullOrEmpty(Domain))
                   cookie.Domain = Domain;
               cookie["Token"] = DES.EncryptDES(string.Format("{0}[&]{1}", userName, timeOut.ToString()));
               context.Response.Cookies.Add(cookie);
           }
       }

       public static void SignOut()
       {

           var context = HttpContext.Current;
           var cookie = context.Request.Cookies[SignInCookieName];
           if (cookie != null && !string.IsNullOrEmpty(cookie["Token"]))
           {
               var userName = DES.DecryptDES(cookie["Token"])
                   .Split(new[] { "[&]" }, StringSplitOptions.RemoveEmptyEntries)[0];
               if (!string.IsNullOrEmpty(Domain))
                   cookie.Domain = Domain;
               cookie["Token"] = string.Empty;
               context.Response.SetCookie(cookie);
           }
       }

       public static bool IsSignedIn()
       {
      
           var context = HttpContext.Current;
           var cookie = context.Request.Cookies[SignInCookieName];
           if (cookie == null)
               return false;

           if (string.IsNullOrEmpty(cookie["Token"]))
               return false;

           var array = DES.DecryptDES(cookie["Token"])
               .Split(new[] { "[&]" }, StringSplitOptions.RemoveEmptyEntries).ToList();

           if (array.Count != 2)
               return false;

           var userName = array[0];
           DateTime timeout;
           if (!DateTime.TryParse(array[1], out timeout))
               return false;
           if (timeout < DateTime.Now)
               return false;

           if (!string.IsNullOrEmpty(Domain))
               cookie.Domain = Domain;
           cookie["Token"] = DES.EncryptDES(string.Format("{0}[&]{1}", userName, DateTime.Now.AddMinutes(TimeoutMins)));
           context.Response.SetCookie(cookie);
           return true;
       }

       public static string GetCurrentIdentity()
       {
        

           if (IsSignedIn())
           {
               var context = HttpContext.Current;
               var cookie = context.Request.Cookies[SignInCookieName];
               var array = DES.DecryptDES(cookie["Token"])
                   .Split(new[] { "[&]" }, StringSplitOptions.RemoveEmptyEntries).ToList();
               return array[0];
           }
           return string.Empty;
       }
   }
}
