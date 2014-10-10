using System.Text;

namespace W3WGame.Services.VoucherAPI.ShengFeng
{
    public class ShengFengApi
    {
        /// <summary>
        /// 商户编码
        /// </summary>
        public const string Mchid = "LGWL";

        /// <summary>
        /// 易付通取动态加密密钥地址
        /// </summary>
        public const string EKUrl = "http://pay.9epay.com.cn/GetEK.aspx";

        public const string DKUrl = "http://pay.9epay.com.cn/GetDK.aspx";

        /// <summary>
        /// 动态密钥ID
        /// </summary>
        public const string GkId = "FBB5E0D61D41D59A";

        /// <summary>
        /// 易付通提交地址
        /// </summary>
        public const string EftUrl = "http://pay.9epay.com.cn/yddxzf/PAY.aspx";

        /// <summary>
        /// IP白名单 
        /// </summary>
        public const string WhiteIPList = "221.122.50.28,218.241.156.85,218.241.156.86,127.0.0.1";

        /// <summary>
        /// 生成充值URL地址
        /// </summary> 
        public static string CreatePayFormHtml(string code, int num, string userId)
        {
            var productCode = string.Empty;
            switch (num)
            {
                case 10:
                    productCode = "3441";
                    break;
                case 20:
                    productCode = "3442";
                    break;
                case 30:
                    productCode = "3443";
                    break;
            }

            var eftMchNoInfo = new EftMchNoInfo
                                   {
                                       Account = userId,
                                       ProductCode = productCode,
                                       MchNo = code,
                                       Mchid = Mchid,
                                       GkId = GkId,
                                       EftUrl = EftUrl,
                                       EkUrl = EKUrl,
                                   };
            var gtMsg = WebHP.PostInfo(eftMchNoInfo.EkUrl, "GkId=" + eftMchNoInfo.GkId);
            var gtMsgArr = gtMsg.Split('~');

            eftMchNoInfo.Id = gtMsgArr[0];
            eftMchNoInfo.Key = gtMsgArr[1];

            var aes = new AES();
            aes.setKey(eftMchNoInfo.Key);
            eftMchNoInfo.Prim = aes.AESEncrypt(eftMchNoInfo.MchNo + "~" + eftMchNoInfo.Account + "~" + eftMchNoInfo.ProductCode + "~" + eftMchNoInfo.Mchid + "~");

            return BuildFormHtml(eftMchNoInfo.EftUrl, eftMchNoInfo.Id, eftMchNoInfo.Prim);
        }

        private static string BuildFormHtml(string etfUrl, string id, string prim)
        {
            var sbHtml = new StringBuilder();
            sbHtml.AppendFormat("<form id='form1' name='form1' action='{0}' method='post'>", etfUrl);
            sbHtml.AppendFormat("<input name='ID' type='Hidden' value='{0}' />", id);
            sbHtml.AppendFormat("<input name='Prim' type='Hidden' value='{0}' />", prim);
            sbHtml.Append("</form>");
            sbHtml.Append("<script>document.forms['form1'].submit();</script>");
            return sbHtml.ToString();
        }

    }
}