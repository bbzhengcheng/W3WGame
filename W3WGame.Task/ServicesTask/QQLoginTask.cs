using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using W3WGame.Services.otherapi;

namespace W3WGame.Task.ServicesTask
{
    public class QQLoginTask
    {
        public static bool GetAccessTokenAndOpenID(string code, string state, out string accessToken, out string openID)
        {
            accessToken = string.Empty;
            openID = string.Empty;
            try
            {
               
                if (string.IsNullOrEmpty(code))
                {
                    return false;
                }

                if (System.Web.HttpContext.Current.Session["qqstate"] == null || System.Web.HttpContext.Current.Session["qqstate"].ToString() != state)
                {
                    return false;
                }

                string refreshToken = string.Empty;

                accessToken = QQAPI.GetAccessToken(code, out refreshToken);

                openID = QQAPI.GetOpenID(accessToken);
            }
            catch (Exception e)
            {
                //写个日志
                return false;
            }
            return true;

        }

    }
}
