﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using W3WGame.Core.Dtos;
using WangFramework.Common;

namespace W3WGame.Services.otherapi
{
    public class QQAPI
    {
        private const string APP_ID = "101172605";
        private const string APP_KEY = "6d7f2ff693d35bc7c2e185d91a71bcb7";

        private const string DOMAIN = "https://graph.qq.com";

        private const string CALLBACK_URL = "http://ka.w3wgame.com/otherlogin/qqcallback";
        //：获取Authorization Code

        public static string GetLoginUrl(string state)
        {
            string scope = "get_user_info";
            string url = string.Format("{0}/oauth2.0/authorize?" +
                                       "response_type={1}" +
                                       "&client_id={2}" +
                                       "&redirect_uri={3}" +
                                       "&state={4}" +
                                       "&scope={5}" +
                                       "&display={6}" +
                                       "&g_ut={7}", DOMAIN, "code", APP_ID, CALLBACK_URL, state, scope, "", "");
            return url;
        }

        //通过Authorization Code获取Access Token

        public static string GetAccessToken(string authorizationCode, out string refreshToken)
        {
            refreshToken = string.Empty;
            string url = string.Format("{0}/oauth2.0/token?" +
                                       "grant_type={1}" +
                                       "&client_id={2}" +
                                       "&client_secret={3}" +
                                       "&code={4}" +
                                       "&redirect_uri={5}", DOMAIN, "authorization_code", APP_ID, APP_KEY, authorizationCode, CALLBACK_URL);
            var returnValue = WebUtils.DoGet(url);

            var list = returnValue.Split('&');
            var dict = new Dictionary<string, string>();
            foreach (var s in list)
            {
                var clist = s.Split('=');
                dict.Add(clist[0], clist[1]);
            }
            refreshToken = dict["refresh_token"];
            return dict["access_token"];

        }

        //通过Authorization Code获取Access Token

        public static string GetOpenID(string accessToken)
        {

            string url = string.Format("{0}/oauth2.0/me?access_token={1}", DOMAIN, accessToken);
            var returnValue = WebUtils.DoGet(url);
            string str = returnValue.Replace("callback(", "").Replace(");", "");

            QQJson info = JsonConvert.DeserializeObject<QQJson>(str);

            return info.openid;
        }

        /// <summary>
        /// 获取用户信息
        /// </summary>
        /// <param name="accessToken"></param>
        /// <param name="openID"></param>
        /// <returns></returns>
        public static GetUserInfoJson GetUserInfoToNickName(string accessToken, string openID)
        {
            string url = string.Format("{0}/user/get_user_info?access_token={1}&oauth_consumer_key={2}&openid={3}"
                                       , DOMAIN, accessToken, APP_ID, openID);
            var returnValue = WebUtils.DoGet(url);
            
            GetUserInfoJson info = JsonConvert.DeserializeObject<GetUserInfoJson>(returnValue);

            return info;

        }

        public static string ListAlbum(string accessToken, string openID)
        {
            string url = string.Format("{0}//photo/list_album?access_token={1}&oauth_consumer_key={2}&openid={3}&format={4}"
                                     , DOMAIN, accessToken, APP_ID, openID,"json");
            var returnValue = WebUtils.DoGet(url);

            return returnValue;


        }




    }

    public class QQJson
    {
        public string client_id { get; set; }

        public string openid { get; set; }
    }

  
}
