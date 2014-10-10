
using WangFramework.Utility;

namespace W3WGame.Services.VoucherAPI
{
    /// <summary>
    /// 盈华讯方充值接口
    /// </summary>
    public class VnetoneApi
    {
        /// <summary>
        /// SP编号
        /// </summary>
        private const string SP = "30120";

        /// <summary>
        /// SP密钥
        /// </summary>
        private const string SPPwd = "hys8yd5g36gdbvsakj";

        /// <summary>
        /// 充值页面地址
        /// </summary>
        private const string SPReq = "http://web.lkgame.com/ChargeCenter/Message";

        /// <summary>
        /// 前台展示地址(充值成功)
        /// </summary>
        private const string SPSuc = "http://web.lkgame.com/VoucherReceive/VnetoneSuccess";
         
        /// <summary>
        /// 短信充值URL
        /// </summary>
        public const string MessageAPIUrl = "http://ydzf.vnetone.com/Default_mo.aspx";

        /// <summary>
        /// 生成充值URL地址
        /// </summary>
        /// <param name="code"></param>
        /// <param name="num"></param>
        /// <param name="userId"></param>
        /// <returns></returns>
        public static string GetMessagePayUrl(string code, int num, string userId)
        {
            var md5 = CryptHelper.MD5Hash(string.Format("{0}{1}{2}{3}{4}{5}"
                                                        , SP
                                                        , code
                                                        , SPPwd
                                                        , num
                                                        , SPReq
                                                        , SPSuc)).ToUpper();
            var url = string.Format("{0}?sp={1}&od={2}&mz={3}&md5={4}&spreq={5}&spsuc={6}&spzdy={7}&uid={8}"
                                    , MessageAPIUrl
                                    , SP
                                    , code
                                    , num
                                    , md5
                                    , SPReq
                                    , SPSuc
                                    , "LKWebGame"
                                    , userId);
            return url;
        }

        /// <summary>
        /// MD5校验
        /// </summary>
        /// <param name="spid"></param>
        /// <param name="oid"></param>
        /// <param name="spOrder"></param>
        /// <param name="mz"></param>
        /// <param name="md5"></param>
        /// <returns></returns>
        public static bool VerifyCallback(string spid, string oid, string spOrder, string mz, string md5)
        {
            var checkMd5 = CryptHelper.MD5Hash(string.Format("{0}{1}{2}{3}{4}"
                                                             , oid
                                                             , spOrder
                                                             , SP
                                                             , mz
                                                             , SPPwd)).ToUpper();
            return checkMd5.ToLower() == md5.ToLower();
        }
    }
}