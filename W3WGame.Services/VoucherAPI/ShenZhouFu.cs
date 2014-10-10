using System;
using System.Web.Security;

namespace W3WGame.Services.VoucherAPI
{
    public class ShenZhouFu
    {
        /// <summary>
        /// 密钥
        /// </summary>
        private readonly static string strKey = "UH28I594FZELAJIAB";

        /// <summary>
        /// 神州付支付13-手机卡充值

        /// </summary>
        /// <param name="code"></param>
        /// <param name="num1"></param>
        /// <param name="typeCode"></param>
        /// <param name="userID"></param>
        /// <param name="pageReturnUrl">页面返回地址，如：http://www.lkgame.com/myLk78/balance/VoucherHistory.aspx </param>
        /// <param name="serverReturnUrl">服务器返回地址,如：http://www.lkgame.com/myLk78/balance/VoucherShenZhouFuServerReceive.aspx </param>
        /// <returns></returns>
        public static string GetPayUrl_Mobile(string code, decimal num1, string typeCode, int userID, string pageReturnUrl, string serverReturnUrl)
        {
            string privateKey = strKey;
            string version = "3";//版本号 *
            string merId = "179057";//商户ID *
            decimal dTemp = num1 * 100;//int.Parse ( );
            int intTemp = Decimal.ToInt32(dTemp);//int.Parse( dTemp.ToString()) ;
            string payMoney = intTemp.ToString();//"1";//支付金额(单位：分) *

            DateTime time = DateTime.Now;
            //time.Year.ToString()+(time.Month.ToString().Length==1 ? "0"+time.Month.ToString() : time.Month.ToString())+(time.Day.ToString().Length ==1 ? "0"+time.Day.ToString() : time.Day.ToString())+
            string orderId = DateTime.Now.ToString("yyyyMMdd") + "-" + merId + "-" + code; //"20081404-151525-001";//订单号（格式：yyyyMMdd-merId-SN） * 
            string merUserName = "lkgame";//商户的用户姓名

            string merUserMail = "";//商户的用户Email 0~100
            string itemName = "";//产品名称
            string itemDesc = "";//产品描述
            string bankId = "";//平台银行ID 
            string privateField = "";//商户私有数据 
            string gatewayId = "0";//支付方式id  0 卡 1 网银 2 帐户 3 卡+帐户 4 网银+帐户
            string cardTypeCombine = "0"; //移动充值卡（神州行卡）支付 0 移动充值卡
            switch (typeCode)
            {
                case "13": cardTypeCombine = "0"; break;
                case "14": cardTypeCombine = "1"; break;
                case "15": cardTypeCombine = "2"; break;
            }
            string verifyType = "1";//数据校验方式 1MD5  2MD5+证书
            string returnType = "3";//返回结果方式 1:页面 2：服务器 3：页面和服务器

            string isDebug = "0";//是否调试 0非调试 1调试

            string PostBackUrl = "http://pay3.shenzhoufu.com/interface/version3/entry.aspx?";

            string combineString = version + "|" + merId + "|" + payMoney + "|" + orderId + "|" + pageReturnUrl + "|" + serverReturnUrl + "|" + privateField + "|" + privateKey + "|" + verifyType + "|" + returnType + "|" + isDebug;
            //Console.WriteLine("combineString=" + combineString);
            string md5String = FormsAuthentication.HashPasswordForStoringInConfigFile(combineString, "MD5").ToLower();

            merUserName = System.Web.HttpUtility.UrlEncode(merUserName);
            itemName = System.Web.HttpUtility.UrlEncode(itemName);
            itemDesc = System.Web.HttpUtility.UrlEncode(itemDesc);

            string version_1_ = "version=" + version;//版本号 *
            string merId_1 = "&merId=" + merId;//商户ID *
            string payMoney_1 = "&payMoney=" + payMoney;//支付金额(单位：分) *
            string orderId_1 = "&orderId=" + orderId;//订单号（格式：yyyyMMdd-merId-SN） * 
            string pageReturnUrl_1 = "&pageReturnUrl=" + pageReturnUrl;//页面返回地址

            string serverReturnUrl_1 = "&serverReturnUrl=" + serverReturnUrl;//服务器返回地址
            string merUserName_1 = "&merUserName=" + merUserName;//商户的用户姓名

            string merUserMail_1 = "&merUserMail=" + merUserMail;//商户的用户Email 0~100
            string itemName_1 = "&itemName=" + itemName;//产品名称
            string itemDesc_1 = "&itemDesc=" + itemDesc;//产品描述

            string bankId_1 = "&bankId=" + bankId;//平台银行ID 
            string privateField_1 = "&privateField=" + privateField;//商户私有数据 
            string md5String_1 = "&md5String=" + md5String;
            string gatewayId_1 = "&gatewayId=" + gatewayId;//支付方式id  0 卡 1 网银 2 帐户 3 卡+帐户 4 网银+帐户
            string cardTypeCombine_1 = "&cardTypeCombine=" + cardTypeCombine; //移动充值卡（神州行卡）支付 0 移动充值卡

            string verifyType_1 = "&verifyType=" + verifyType;//数据校验方式 1MD5  2MD5+证书 
            string returnType_1 = "&returnType=" + returnType;//返回结果方式 1:页面 2：服务器 3：页面和服务器

            string isDebug_1 = "&isDebug=" + isDebug;//是否调试 0非调试 1调试
            string signString_1 = "&signString=";

            string strUrl = PostBackUrl + version_1_ + merId_1 + payMoney_1 + orderId_1 + pageReturnUrl_1 + serverReturnUrl_1 + merUserName_1 + merUserMail_1 + itemName_1 + itemDesc_1 + bankId_1 + privateField_1 + md5String_1 + gatewayId_1 + cardTypeCombine_1 + verifyType_1 + returnType_1 + isDebug_1 + signString_1;
            return strUrl;
        }

        /// <summary>
        /// 判断MD5值是否匹配

        /// </summary>
        /// <param name="version"></param>
        /// <param name="merId"></param>
        /// <param name="payMoney"></param>
        /// <param name="orderId"></param>
        /// <param name="payResult"></param>
        /// <param name="privateField"></param>
        /// <param name="payDetails"></param>
        /// <param name="md5String"></param>
        /// <returns></returns>
        public static bool IsMatchMd5(string version, string merId, string payMoney, string orderId, string payResult, string privateField, string payDetails, string md5String)
        {
            string privateKey = strKey;
            String combineString = version + merId + payMoney + orderId + payResult + privateField + payDetails + privateKey;
            String md5 = FormsAuthentication.HashPasswordForStoringInConfigFile(combineString, "MD5").ToLower();

            if (md5.Equals(md5String))
                return true;
            else
                return false;

        }
    }
}
