using System;
using System.Text;

namespace W3WGame.Services.VoucherAPI
{
    /// <summary>
    /// 上海尧鸿充值API接口
    /// </summary>
    public class YaoHongApi
    {
        private const string PCUser = "user_ligang";
        private const string Key = "lg2948661232";
        private const string PCSubArea = "subarea_lgpage";
        private const string PCSubAreaFee = "subareafee_lgpage";

        /// <summary>
        /// 获取电信充值URL
        /// </summary>
        /// <returns></returns>
        public static string GetDianXingPayUrl(string code, int num, string account)
        {
            const string redirectUrl = "http://webdeposit.lkgame.com/VoucherReceive/YaoHongDianXing";
            const string syncUrl = "http://webdeposit.lkgame.com/VoucherReceive/YaoHongDianXing";
            var url = "http://pay.1cka.com/port/channel4u.aspx";

            const string p2Mode = "page"; //	'固定参数
            const string p3Step = "free"; //	'固定参数
            const string p4Category = "phone"; //	'固定参数
            const string pcUser = PCUser; //	'用户代码，根据文档修改 +
            const string pcSubArea = PCSubArea; //	'分区代码，根据文档修改 + 
            const string pbGate = "ivr"; //	'固定参数
            var p17TransactionNo = code;// '商户交易号，转向和同步时候原样返回 +
            const string p9ExtData = "webGame"; //  '商户扩展数据，转向和同步时候原样返回 +
            const string p8GameAccount = "game"; // '用户充值的游戏账户，建议加密后传递 +
            const string p100MD5Mode = "advivr"; // '固定参数

            var pcSubAreaFee = PCSubAreaFee;
            switch (num)
            {
                case 7:
                    pcSubAreaFee += "5";
                    break;
                case 14:
                    pcSubAreaFee += "10";
                    break;
                case 28:
                    pcSubAreaFee += "20";
                    break;
                default:
                    throw new Exception("错误的充值金额");
            }
            var p10MD5Str = MD5GB2312(p2Mode + p3Step + p4Category + pcUser + pcSubArea + pcSubAreaFee + pbGate + p17TransactionNo + Key);


            url = url + "?p2_Mode=" + p2Mode;
            url = url + "&p3_Step=" + p3Step;
            url = url + "&p4_Category=" + p4Category;
            url = url + "&pb_Gate=" + pbGate;
            url = url + "&pc_User=" + pcUser;
            url = url + "&pc_SubArea=" + pcSubArea;
            url = url + "&pc_SubAreaFee=" + pcSubAreaFee;
            url = url + "&p17_TransactionNo=" + p17TransactionNo;
            url = url + "&p8_GameAccount=" + p8GameAccount;
            url = url + "&p9_ExtData=" + p9ExtData;
            url = url + "&p13_RedirectUrl=" + redirectUrl;
            url = url + "&p18_SyncUrl=" + syncUrl;
            url = url + "&p100_MD5Mode=" + p100MD5Mode;
            url = url + "&p10_MD5Str=" + p10MD5Str;

            return url;
        }

        /// <summary>
        /// 电信接口MD5校验
        /// </summary>
        public static bool ValidateDianXingCallbackMd5(string p0Result, string pcUser, string pcSubArea, string pcSubAreaFee, string pbGate, string pbChannel, string p5OrderNo, string p6Fee, string p11TransactionNo, string md5)
        {
            var checkMd5 = MD5GB2312(string.Format("{0}{1}{2}{3}{4}{5}{6}{7}{8}{9}"
                                                             , p0Result, pcUser, pcSubArea, pcSubAreaFee, pbGate, pbChannel, p5OrderNo, p6Fee, p11TransactionNo, Key));
            return checkMd5.ToLower() == md5.ToLower();
        }

        /// <summary>
        /// 获取联通充值URL
        /// </summary>
        /// <returns></returns>
        public static string GetLianTongPayUrl(string code, int num, string account)
        {
            const string redirectUrl = "http://webdeposit.lkgame.com/VoucherReceive/YaoHongLianTong";
            const string syncUrl = "http://webdeposit.lkgame.com/VoucherReceive/YaoHongLianTong";

            string url = "http://203.93.0.161/port/channel4u.aspx";


            const string p2Mode = "page"; //	'固定参数 
            const string pbGate = "ivr"; //	'固定参数
            string p17TransactionNo = code;
            const string p9ExtData = "webGame"; //  '商户扩展数据，转向和同步时候原样返回 +
            const string p8GameAccount = "game"; // '用户充值的游戏账户，建议加密后传递 +
            const string p100MD5Mode = "advivr"; // '固定参数

            var pcSubAreaFee = PCSubAreaFee;
            switch (num)
            {
                case 8:
                    pcSubAreaFee += "5";
                    break;
                case 16:
                    pcSubAreaFee += "10";
                    break;
                case 32:
                    pcSubAreaFee += "20";
                    break;
                default:
                    throw new Exception("错误的充值金额");
            }
            string p10MD5Str = MD5GB2312(p2Mode + pbGate + PCUser + PCSubArea + pcSubAreaFee + p17TransactionNo + Key);

            url = url + "?p2_Mode=" + p2Mode;
            url = url + "&pb_Gate=" + pbGate;
            url = url + "&pc_User=" + PCUser;
            url = url + "&pc_SubArea=" + PCSubArea;
            url = url + "&pc_SubAreaFee=" + pcSubAreaFee;
            url = url + "&p17_TransactionNo=" + p17TransactionNo;
            url = url + "&p8_GameAccount=" + p8GameAccount;
            url = url + "&p9_ExtData=" + p9ExtData;
            url = url + "&p13_RedirectUrl=" + redirectUrl;
            url = url + "&p18_SyncUrl=" + syncUrl;
            url = url + "&p100_MD5Mode=" + p100MD5Mode;
            url = url + "&p10_MD5Str=" + p10MD5Str;

            return url;
        }

        /// <summary>
        /// 联通接口MD5校验
        /// </summary>
        public static bool ValidateLianTongCallbackMd5(string p0Result, string pcUser, string pcSubArea, string pcSubAreaFee, string pbGate, string pbChannel, string p5OrderNo, string p6Fee, string p11TransactionNo, string md5)
        {
            var checkMd5 = MD5GB2312(string.Format("{0}{1}{2}{3}{4}{5}{6}{7}{8}{9}"
                                                             , p0Result, pbGate, pbChannel, pcUser, pcSubArea, pcSubAreaFee, p5OrderNo, p6Fee, p11TransactionNo, Key));
            return checkMd5.ToLower() == md5.ToLower();
        }

        public static string MD5Utf8(string str)
        {
            return System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(str, "MD5");
        }


        public static string MD5GB2312(string str)
        {
            var data = Encoding.GetEncoding("GB2312").GetBytes(str);
            var m5 = new System.Security.Cryptography.MD5CryptoServiceProvider();
            var result = m5.ComputeHash(data);
            var r = BitConverter.ToString(result).ToLower().Replace("-", "");
            r = r.ToUpper();
            return r;
        }
    }
}