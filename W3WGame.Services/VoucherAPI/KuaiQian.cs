using System;
using System.Text;
using System.Web.Security;

namespace W3WGame.Services.VoucherAPI
{
    public class KuaiQian
    {
        #region 接口配置参数
        /// <summary>
        /// 快钱-网银 人民币网关密钥
        /// </summary>
        private readonly static string key_bank = "NNBJXK43LZX8G8QE";//新 2012-3-29
        
        /// <summary>
        /// 快钱-游戏卡密钥
        /// </summary>
        private readonly static string key_gameCard = "GLLGLK7732105513";//快钱游戏卡密钥

        #endregion


        /// <summary>
        /// 快钱支付14-网银
        /// </summary>
        /// <param name="code">订单号</param>
        /// <param name="num1">申请金额</param>
        /// <param name="typeCode">充值渠道（表VoucherHistory中的typecode）</param>
        /// <param name="userID">用户Id（LK平台）</param>
        /// <param name="bgUrl">
        /// 接收通知页面，如：http://deposit.lkgame.com:53120/myLk78/balance/VoucherKuaiQianNotify.aspx
        /// </param>
        /// <returns></returns>
        public static string GetPayUrl_Bank(string code, decimal num1, string typeCode, int userID, string bgUrl)
        {
            //人民币网关账户号
            ///请登录快钱系统获取用户编号，用户编号后加01即为人民币网关账户号。

            string merchantAcctId = "1002160665101";//"";

            ///人民币网关密钥

            ///区分大小写.请与快钱联系索取
            string key = key_bank;

            //字符集.固定选择值。可为空。

            ///只能选择1、2、3.
            ///1代表UTF-8; 2代表GBK; 3代表gb2312
            ///默认值为1
            string inputCharset = "1";

            //服务器接受支付结果的后台地址.与[pageUrl]不能同时为空。必须是绝对地址。

            ///快钱通过服务器连接的方式将交易结果发送到[bgUrl]对应的页面地址，在商户处理完成后输出的<result>如果为1，页面会转向到<redirecturl>对应的地址。

            ///如果快钱未接收到<redirecturl>对应的地址，快钱将把支付结果GET到[pageUrl]对应的页面。

            //网关版本.固定值

            ///快钱会根据版本号来调用对应的接口处理程序。

            ///本代码版本号固定为v2.0
            string version = "v2.0";

            //语言种类.固定选择值。

            ///只能选择1、2、3
            ///1代表中文；2代表英文
            ///默认值为1
            string language = "1";

            //签名类型.固定值

            ///1代表MD5签名
            ///当前版本固定为1
            string signType = "1";

            //支付人姓名

            ///可为中文或英文字符

            string payerName = userID.ToString();//"kcoin";

            //支付人联系方式类型.固定选择值

            ///只能选择1
            ///1代表Email
            string payerContactType = "1";

            //支付人联系方式

            ///只能选择Email或手机号
            string payerContact = "";

            //商户订单号

            ///由字母、数字、或[-][_]组成
            string orderId = code.Replace("@", "-");//DateTime.Now.ToString("yyyyMMddHHmmss");

            //订单金额
            ///以分为单位，必须是整型数字

            ///比方2，代表0.02元

            decimal temp = num1 * 100;
            string orderAmount = decimal.ToInt32(temp).ToString();//"2";

            //订单提交时间
            ///14位数字。年[4位]月[2位]日[2位]时[2位]分[2位]秒[2位]
            ///如；20080101010101
            string orderTime = DateTime.Now.ToString("yyyyMMddHHmmss");

            //商品名称
            ///可为中文或英文字符

            string productName = "coin";

            //商品数量
            ///可为空，非空时必须为数字
            string productNum = "1";

            //商品代码
            ///可为字符或者数字

            string productId = "";

            //商品描述
            string productDesc = "";

            //扩展字段1
            ///在支付结束后原样返回给商户

            string ext1 = userID.ToString();//"";

            //扩展字段2
            ///在支付结束后原样返回给商户

            string ext2 = "";

            //支付方式.固定选择值

            ///只能选择00、10、11、12、13、14
            ///00：组合支付（网关支付页面显示快钱支持的各种支付方式，推荐使用）10：银行卡支付（网关支付页面只显示银行卡支付）.11：电话银行支付（网关支付页面只显示电话支付）.12：快钱账户支付（网关支付页面只显示快钱账户支付）.13：线下支付（网关支付页面只显示线下支付方式）
            string payType = "10";

            string bankId = GetBankId(typeCode);

            //同一订单禁止重复提交标志
            ///固定选择值： 1、0
            ///1代表同一订单号只允许提交1次；0表示同一订单号在没有支付成功的前提下可重复提交多次。默认为0建议实物购物车结算类商户采用0；虚拟产品类商户采用1
            string redoFlag = "1";

            //快钱的合作伙伴的账户号

            ///如未和快钱签订代理合作协议，不需要填写本参数
            string pid = "";

            //生成加密签名串

            ///请务必按照如下顺序和规则组成加密串！
            string signMsgVal = "";
            signMsgVal = appendParam(signMsgVal, "inputCharset", inputCharset);
            signMsgVal = appendParam(signMsgVal, "bgUrl", bgUrl);
            signMsgVal = appendParam(signMsgVal, "version", version);
            signMsgVal = appendParam(signMsgVal, "language", language);
            signMsgVal = appendParam(signMsgVal, "signType", signType);

            signMsgVal = appendParam(signMsgVal, "merchantAcctId", merchantAcctId);
            signMsgVal = appendParam(signMsgVal, "payerName", payerName);
            signMsgVal = appendParam(signMsgVal, "payerContactType", payerContactType);
            signMsgVal = appendParam(signMsgVal, "payerContact", payerContact);
            signMsgVal = appendParam(signMsgVal, "orderId", orderId);

            signMsgVal = appendParam(signMsgVal, "orderAmount", orderAmount);
            signMsgVal = appendParam(signMsgVal, "orderTime", orderTime);
            signMsgVal = appendParam(signMsgVal, "productName", productName);
            signMsgVal = appendParam(signMsgVal, "productNum", productNum);
            signMsgVal = appendParam(signMsgVal, "productId", productId);

            signMsgVal = appendParam(signMsgVal, "productDesc", productDesc);
            signMsgVal = appendParam(signMsgVal, "ext1", ext1);
            signMsgVal = appendParam(signMsgVal, "ext2", ext2);
            signMsgVal = appendParam(signMsgVal, "payType", payType);

            signMsgVal = appendParam(signMsgVal, "bankId", bankId);// 
            signMsgVal = appendParam(signMsgVal, "redoFlag", redoFlag);

            signMsgVal = appendParam(signMsgVal, "pid", pid);
            string urlPara = signMsgVal;

            signMsgVal = appendParam(signMsgVal, "key", key);
            string signMsg = FormsAuthentication.HashPasswordForStoringInConfigFile(signMsgVal, "MD5").ToUpper();


            signMsgVal = appendParam(urlPara, "signMsg", signMsg);
            string url = "https://www.99bill.com/gateway/recvMerchantInfoAction.htm?";

            return url + signMsgVal;
        }

        //获取银行Id
        private static string GetBankId(string typeCode)
        {
            switch (typeCode)
            {
                case "0301": return "ICBC";//中国工商银行
                case "0302": return "ABC";//中国农业银行
                case "0303": return "CCB";//中国建设银行
                case "0304": return "CMB";//招商银行
                case "0305": return "CMBC";//中国民生银行
                case "0306": return "SPDB";//上海浦东发展银行
                case "0307": return "CIB";//兴业银行
                case "0308": return "SDB";//深圳发展银行
                case "0309": return "BOB";//北京银行
                case "0310": return "CEB";//中国光大银行
                case "0311": return "BCOM";//交通银行

                case "0312": return "CITIC";//中信银行
                case "0313": return "BOC";//中国银行
                case "0314": return "CPSRB";//中国邮政
                case "0315": return "HXB";//华夏银行
                case "0316": return "PAB";//平安银行
                //17
                //18
                case "0319": return "GDB";//广东发展银行
                case "0320": return "GZRCC";//广州市农村信用合作社
                case "0321": return "GZCB";//广州市商业银行

                case "0322": return "SHRCC";//上海农村商业银行
                case "0323": return "NJCB";//南京银行
                case "0324": return "BEA";//东亚银行
                case "0325": return "CBHB";//渤海银行
                case "0326": return "BJRCB";//北京农村商业银行
                case "0327": return "CUPS";//"CNPY";break;//中国银联 2011-8-12 CNPY 改为CUPS
                case "0328": return "HSB";//徽商银行
                case "0329": return "SHB";//上海银行
                case "0330": return "HZB";//杭州银行
                case "0331": return "NBCB";//宁波银行
                default: return string.Empty;
            }
        }

        //功能函数。将变量值不为空的参数组成字符串
        private static string appendParam1(String returnStr, String paramId, String paramValue)
        {
            if (returnStr != "")
            {
                //if(paramValue!="")
                //{
                returnStr += "&" + paramId + "=" + System.Web.HttpUtility.UrlEncode(paramValue);
                //}
            }
            else
            {
                //if(paramValue!="")
                //{
                returnStr = paramId + "=" + System.Web.HttpUtility.UrlEncode(paramValue);
                //}
            }
            return returnStr;
        }

        private static string appendParam(String returnStr, String paramId, String paramValue)
        {
            if (returnStr != "")
            {
                if (paramValue != "")
                {
                    returnStr += "&" + paramId + "=" + paramValue;
                }
            }
            else
            {
                if (paramValue != "")
                {
                    returnStr = paramId + "=" + paramValue;
                }
            }
            return returnStr;
        }
        //功能函数。将变量值不为空的参数组成字符串。结束

        /// <summary>
        /// 手机卡充值-快钱支付
        /// </summary>
        /// <param name="code">订单号</param>
        /// <param name="num1">申请金额</param>
        /// <param name="typeCode">充值渠道</param>
        /// <param name="userID">用户ID</param>
        /// <param name="bgUrl">通知页面，如：http://www.lkgame.com/myLk78/balance/VoucherKuaiQianNotify_ka.aspx </param>
        /// <returns></returns>
        public static string GetPayUrl_Mobile(string code, decimal num1, string typeCode, int userID, string bgUrl)
        {
            //神州行网关账户号
            ///请与快钱技术联系索取

            string merchantAcctId = GetKeyMerchantAcctIdByTypecode("merchantAcctId", typeCode);//

            //设置神州行网关密钥

            ///区分大小写

            string key = GetKeyMerchantAcctIdByTypecode("key", typeCode);//"ZUZNJB8MF63GA83J";

            if (merchantAcctId.Trim().Length <= 0)
            {
                return string.Empty;
            }

            //字符集.固定选择值。可为空。

            ///只能选择1、2、3、5
            ///1代表UTF-8; 2代表GBK; 3代表gb2312; 5 代表big5
            ///默认值为1
            string inputCharset = "1";

            //服务器接受支付结果的后台地址.与[pageUrl]不能同时为空。必须是绝对地址。

            ///快钱通过服务器连接的方式将交易结果发送到[bgUrl]对应的页面地址，在商户处理完成后输出的<result>如果为1，页面会转向到<redirecturl>对应的地址。

            //接受支付结果的页面地址.与[bgUrl]不能同时为空。必须是绝对地址。

            ///如果[bgUrl]为空，快钱将支付结果GET到[pageUrl]对应的地址。

            ///如果[bgUrl]不为空，并且[bgUrl]页面指定的<redirecturl>地址不为空，则转向到<redirecturl>对应的地址.
            string pageUrl = "";

            //网关版本.固定值

            ///快钱会根据版本号来调用对应的接口处理程序。

            ///本代码版本号固定为v2.0
            string version = "v2.0";

            //语言种类.固定选择值。

            ///只能选择1、2、3
            ///1代表中文；2代表英文
            ///默认值为1
            string language = "1";

            //签名类型.固定值

            ///1代表MD5签名
            ///当前版本固定为1
            string signType = "1";


            //支付人姓名

            ///可为中文或英文字符

            string payerName = userID.ToString();//"支付人";

            //支付人联系方式类型.固定选择值

            ///只能选择1
            ///1代表Email
            string payerContactType = "1";

            //支付人联系方式

            ///只能选择Email或手机号
            string payerContact = "";

            //商户订单号

            ///由字母、数字、或[-][_]组成
            string orderId = code;//DateTime.Now.ToString("yyyyMMddHHmmss");

            //订单金额
            ///以分为单位，必须是整型数字

            ///比方2，代表0.02元

            decimal temp = num1 * 100;
            string orderAmount = decimal.ToInt32(temp).ToString();//temp.ToString(); 

            //支付方式.固定选择值

            ///可选择00、41、42、52
            ///00 代表快钱默认支付方式，目前为神州行卡密支付和快钱账户支付；41 代表快钱账户支付；42 代表神州行卡密支付和快钱账户支付；52 代表神州行卡密支付

            string payType = "42";

            //神州行卡序号
            ///仅在商户定制了神州行卡密直连功能时填写

            string cardNumber = "";

            //神州行卡密码
            ///仅在商户定制了神州行卡密直连功能时填写

            string cardPwd = "";

            //全额支付标志
            ///只能选择数字 0 或 1
            ///0 代表非全额支付方式，支付完成后返回订单金额为商户提交的订单金额。如果预付费卡面额小于订单金额时，返回支付结果为失败；预付费卡面额大于或等于订单金额时，返回支付结果为成功；
            ///1 代表全额支付方式，支付完成后返回订单金额为用户预付费卡的面额。只要预付费卡销卡成功，返回支上海快钱信息服务有限公司 版权所有 第 6 页付结果都为成功。如果商户定制神州行卡密直连时，本参数固定值为1
            string fullAmountFlag = "0";

            //订单提交时间
            ///14位数字。年[4位]月[2位]日[2位]时[2位]分[2位]秒[2位]
            ///如；20080101010101
            string orderTime = DateTime.Now.ToString("yyyyMMddHHmmss");

            //商品名称
            ///可为中文或英文字符

            string productName = "kcoin";


            //商品数量
            ///可为空，非空时必须为数字
            string productNum = "1";

            //商品代码
            ///可为字符或者数字

            string productId = "";

            //商品描述
            string productDesc = "coin";

            //扩展字段1
            ///在支付结束后原样返回给商户

            string ext1 = userID.ToString();

            //扩展字段2
            ///在支付结束后原样返回给商户

            string ext2 = "";


            string bossType = "9";
            switch (typeCode)
            {
                case "13":
                    bossType = "0"; break; //移动卡

                case "14":
                    bossType = "1"; break; //联通卡
                case "15":
                    bossType = "3"; break;  //电信卡

            }

            //对所有可能含有中文字符的参数进行编码
            payerName = System.Web.HttpUtility.UrlEncode(payerName, Encoding.GetEncoding("UTF-8")).ToUpper();
            productName = System.Web.HttpUtility.UrlEncode(productName, Encoding.GetEncoding("UTF-8")).ToUpper();
            productDesc = System.Web.HttpUtility.UrlEncode(productDesc, Encoding.GetEncoding("UTF-8")).ToUpper();
            ext1 = System.Web.HttpUtility.UrlEncode(ext1, Encoding.GetEncoding("UTF-8")).ToUpper();
            ext2 = System.Web.HttpUtility.UrlEncode(ext2, Encoding.GetEncoding("UTF-8")).ToUpper();



            //生成加密签名串

            ///请务必按照如下顺序和规则组成加密串！
            string signMsgVal = "";
            signMsgVal = appendParam(signMsgVal, "inputCharset", inputCharset);
            signMsgVal = appendParam(signMsgVal, "bgUrl", bgUrl);
            signMsgVal = appendParam(signMsgVal, "pageUrl", pageUrl);
            signMsgVal = appendParam(signMsgVal, "version", version);
            signMsgVal = appendParam(signMsgVal, "language", language);
            signMsgVal = appendParam(signMsgVal, "signType", signType);
            signMsgVal = appendParam(signMsgVal, "merchantAcctId", merchantAcctId);
            signMsgVal = appendParam(signMsgVal, "payerName", payerName);
            signMsgVal = appendParam(signMsgVal, "payerContactType", payerContactType);
            signMsgVal = appendParam(signMsgVal, "payerContact", payerContact);
            signMsgVal = appendParam(signMsgVal, "orderId", orderId);
            signMsgVal = appendParam(signMsgVal, "orderAmount", orderAmount);
            signMsgVal = appendParam(signMsgVal, "payType", payType);
            signMsgVal = appendParam(signMsgVal, "cardNumber", cardNumber);
            signMsgVal = appendParam(signMsgVal, "cardPwd", cardPwd);
            signMsgVal = appendParam(signMsgVal, "fullAmountFlag", fullAmountFlag);
            signMsgVal = appendParam(signMsgVal, "orderTime", orderTime);
            signMsgVal = appendParam(signMsgVal, "productName", productName);
            signMsgVal = appendParam(signMsgVal, "productNum", productNum);
            signMsgVal = appendParam(signMsgVal, "productId", productId);
            signMsgVal = appendParam(signMsgVal, "productDesc", productDesc);
            signMsgVal = appendParam(signMsgVal, "ext1", ext1);
            signMsgVal = appendParam(signMsgVal, "ext2", ext2);
            signMsgVal = appendParam(signMsgVal, "bossType", bossType);

            string urlPara = signMsgVal;
            signMsgVal = appendParam(signMsgVal, "key", key);
            string signMsg = GetMD5(signMsgVal, "utf-8").ToUpper();

            signMsgVal = appendParam(urlPara, "signMsg", signMsg);
            string url = "https://www.99bill.com/szxgateway/recvMerchantInfoAction.htm?";

            return url + signMsgVal;
        }

        /// <summary>
        /// 获取游戏卡充值跳转地址
        /// </summary>
        /// <param name="code"></param>
        /// <param name="pageUrl">如：http://www.lkgame.com/myLk78/balance/VoucherHistory.aspx </param>
        /// <param name="bgUrl">如：http://deposit.lkgame.com:53120/myLk78/balance/VoucherKuaiQianNotify_KQgame.aspx </param>
        /// <returns></returns>
        public static string GetGoToUrl_GameCard(string code, string pageUrl, string bgUrl)
        {
            string merchantAcctId = "107902";
            string orderId = code;
            string orderAmount = "0";
            string payType = "0";
            string ext1 = "Coin";//扩展字段1///在支付结束后原样返回给商户
            string ext2 = "";//扩展字段2///在支付结束后原样返回给商户
            string signMsg = "";
            string url = "http://222.73.15.116/Pay_gateselkq.aspx?";
            string key = key_gameCard;//key_gameCard

            //对所有可能含有中文字符的参数进行编码 
            ext1 = System.Web.HttpUtility.UrlEncode(ext1, Encoding.GetEncoding("UTF-8")).ToUpper();
            ext2 = System.Web.HttpUtility.UrlEncode(ext2, Encoding.GetEncoding("UTF-8")).ToUpper();

            //生成加密签名串
            ///请务必按照如下顺序和规则组成加密串！
            string signMsgVal = "";
            signMsgVal = appendParam(signMsgVal, "merchantAcctId", merchantAcctId);
            signMsgVal = appendParam(signMsgVal, "orderId", orderId);
            signMsgVal = appendParam(signMsgVal, "orderAmount", orderAmount);
            signMsgVal = appendParam(signMsgVal, "payType", payType);
            signMsgVal = appendParam(signMsgVal, "pageUrl", pageUrl);

            signMsgVal = appendParam(signMsgVal, "bgUrl", bgUrl);
            signMsgVal = appendParam(signMsgVal, "ext1", ext1);
            signMsgVal = appendParam(signMsgVal, "ext2", ext2);
            signMsgVal = appendParam(signMsgVal, "key", key);
            signMsg = GetMD5(signMsgVal, "GB2312").ToUpper();

            signMsgVal = "";
            signMsgVal = appendParam1(signMsgVal, "merchantAcctId", merchantAcctId);
            signMsgVal = appendParam1(signMsgVal, "orderId", orderId);
            signMsgVal = appendParam1(signMsgVal, "orderAmount", orderAmount);
            signMsgVal = appendParam1(signMsgVal, "payType", payType);
            signMsgVal = appendParam1(signMsgVal, "pageUrl", pageUrl);

            signMsgVal = appendParam1(signMsgVal, "bgUrl", bgUrl);
            signMsgVal = appendParam1(signMsgVal, "ext1", ext1);
            signMsgVal = appendParam1(signMsgVal, "ext2", ext2);

            string urlPara = signMsgVal;

            signMsgVal = appendParam1(urlPara, "signMsg", signMsg);
            return url + signMsgVal;
        }

        /// <summary>
        /// 快钱游戏卡验证Md5值
        /// </summary>
        /// <param name="orderId"></param>
        /// <param name="payAmount"></param>
        /// <param name="cardNumber"></param>
        /// <param name="payResult"></param>
        /// <param name="dealId"></param>
        /// <param name="merchantAcctId"></param>
        /// <param name="ext1"></param>
        /// <param name="ext2"></param>
        /// <param name="signMsg"></param>
        /// <returns></returns>
        public static bool IsMatchMd5_GameCard(string orderId, string payAmount, string cardNumber, string payResult,
            string dealId, string merchantAcctId, string ext1, string ext2, string signMsg)
        {
            //生成加密串。必须保持如下顺序。
            string merchantSignMsgVal = "";
            merchantSignMsgVal = appendParam(merchantSignMsgVal, "payResult", payResult);
            merchantSignMsgVal = appendParam(merchantSignMsgVal, "dealId", dealId);
            merchantSignMsgVal = appendParam(merchantSignMsgVal, "merchantAcctId", merchantAcctId);

            merchantSignMsgVal = appendParam(merchantSignMsgVal, "orderId", orderId);
            merchantSignMsgVal = appendParam(merchantSignMsgVal, "payAmount", payAmount);
            merchantSignMsgVal = appendParam(merchantSignMsgVal, "cardNumber", cardNumber);
            if (cardNumber == "")
                merchantSignMsgVal = merchantSignMsgVal + "&cardNumber=";

            merchantSignMsgVal = appendParam(merchantSignMsgVal, "ext1", ext1);
            merchantSignMsgVal = appendParam(merchantSignMsgVal, "ext2", ext2);
            merchantSignMsgVal = appendParam(merchantSignMsgVal, "key", key_gameCard);
            string beforeMd5 = merchantSignMsgVal;
            string merchantSignMsg = GetMD5(merchantSignMsgVal, "utf-8");
            if (signMsg.ToUpper() == merchantSignMsg.ToUpper())
                return true;
            else
                return false;

        }

        /// <summary>
        /// 根据typeCode获取key,merchantAcctId
        /// </summary>
        /// <param name="typeCode">充值渠道</param>
        /// <returns></returns>
        private static String GetKeyMerchantAcctIdByTypecode(string type, string typeCode)
        {
            if (type == "key")
            {
                switch (typeCode)
                {
                    case "13":
                        return "T6AKGUQQNMTYWJ5J"; //移动卡

                    case "14":
                        return "IDXXAQBHU9FBRX6R";  //联通卡
                    case "15":
                        return "JT3353NTCMFGSWMU";  //电信卡
                    case "05":
                        return "DFZK4C78RFDFG9UY"; //骏网一卡通

                }
            }
            if (type == "merchantAcctId")
            {
                switch (typeCode)
                {
                    case "13":
                        return "1002160665102"; //移动卡

                    case "14":
                        return "1002160665103";  //联通卡
                    case "15":
                        return "1002160665104";  //电信卡

                }
            }
            return "";
        }
        private static string GetKeyByTypeCode(string typeCode)
        {
            switch (typeCode)
            {
                case "13":
                    return "T6AKGUQQNMTYWJ5J"; //移动卡

                case "14":
                    return "IDXXAQBHU9FBRX6R";  //联通卡
                case "15":
                    return "JT3353NTCMFGSWMU";  //电信卡
                case "05":
                    return "DFZK4C78RFDFG9UY";
                default:
                    return string.Empty;
            }
        }

        private static string GetKeyByReceiveBossType(string receiveBossType)
        {
            switch (receiveBossType)
            {
                case "0": return GetKeyByTypeCode("13");
                case "1": return GetKeyByTypeCode("14");
                case "3": return GetKeyByTypeCode("15");
                case "4": return GetKeyByTypeCode("05");
                default:
                    return string.Empty;
            }
        }


        //功能函数。将字符串进行编码格式转换，并进行MD5加密，然后返回。开始

        private static string GetMD5(string dataStr, string codeType)
        {
            System.Security.Cryptography.MD5 md5 = new System.Security.Cryptography.MD5CryptoServiceProvider();
            byte[] t = md5.ComputeHash(System.Text.Encoding.GetEncoding(codeType).GetBytes(dataStr));
            System.Text.StringBuilder sb = new System.Text.StringBuilder(32);
            for (int i = 0; i < t.Length; i++)
            {
                sb.Append(t[i].ToString("x").PadLeft(2, '0'));
            }
            return sb.ToString();
        }


        /// <summary>
        /// 验证签名值-网银
        /// </summary>
        /// <param name="signMsg">接收到的签名值</param>
        /// <param name="merchantAcctId">人民币网关账户号</param>
        /// <param name="version">网关版本.固定值</param>
        /// <param name="language">语言种类.固定选择值.1代表中文；2代表英文</param>
        /// <param name="signType">签名类型.固定值.1代表MD5签名.当前版本固定为1</param>
        /// <param name="payType">获取支付方式.值为：10、11、12、13、14.</param>
        /// <param name="bankId"></param>
        /// <param name="orderId"></param>
        /// <param name="orderTime"></param>
        /// <param name="orderAmount"></param>
        /// <param name="dealId"></param>
        /// <param name="bankDealId"></param>
        /// <param name="dealTime"></param>
        /// <param name="payAmount"></param>
        /// <param name="fee"></param>
        /// <param name="ext1"></param>
        /// <param name="ext2"></param>
        /// <param name="payResult"></param>
        /// <param name="errCode"></param>
        /// <returns></returns>
        public static bool ValidateSign(string signMsg, string merchantAcctId, string version, string language, string signType,
                                        string payType, string bankId, string orderId, string orderTime, string orderAmount,
                                        string dealId, string bankDealId, string dealTime, string payAmount, string fee,
                                        string ext1, string ext2, string payResult, string errCode)
        {
            string key = key_bank;//人民币网关密钥

            string merchantSignMsgVal = "";//生成的加密串

            //生成加密串。必须保持如下顺序。

            merchantSignMsgVal = appendParam(merchantSignMsgVal, "merchantAcctId", merchantAcctId);
            merchantSignMsgVal = appendParam(merchantSignMsgVal, "version", version);
            merchantSignMsgVal = appendParam(merchantSignMsgVal, "language", language);
            merchantSignMsgVal = appendParam(merchantSignMsgVal, "signType", signType);
            merchantSignMsgVal = appendParam(merchantSignMsgVal, "payType", payType);
            merchantSignMsgVal = appendParam(merchantSignMsgVal, "bankId", bankId);
            merchantSignMsgVal = appendParam(merchantSignMsgVal, "orderId", orderId);
            merchantSignMsgVal = appendParam(merchantSignMsgVal, "orderTime", orderTime);
            merchantSignMsgVal = appendParam(merchantSignMsgVal, "orderAmount", orderAmount);
            merchantSignMsgVal = appendParam(merchantSignMsgVal, "dealId", dealId);
            merchantSignMsgVal = appendParam(merchantSignMsgVal, "bankDealId", bankDealId);
            merchantSignMsgVal = appendParam(merchantSignMsgVal, "dealTime", dealTime);
            merchantSignMsgVal = appendParam(merchantSignMsgVal, "payAmount", payAmount);
            merchantSignMsgVal = appendParam(merchantSignMsgVal, "fee", fee);
            merchantSignMsgVal = appendParam(merchantSignMsgVal, "ext1", ext1);
            merchantSignMsgVal = appendParam(merchantSignMsgVal, "ext2", ext2);
            merchantSignMsgVal = appendParam(merchantSignMsgVal, "payResult", payResult);
            merchantSignMsgVal = appendParam(merchantSignMsgVal, "errCode", errCode);
            merchantSignMsgVal = appendParam(merchantSignMsgVal, "key", key);

            string merchantSignMsg = FormsAuthentication.HashPasswordForStoringInConfigFile(merchantSignMsgVal, "MD5");

            if (signMsg.ToUpper().Equals(merchantSignMsg.ToUpper()))
                return true;//签名正确
            else
                return false;//签名错误
        }


        //验证签名-手机充值卡
        public static bool ValidateSign_Mobile(string signMsg, string merchantAcctId, string version, string language, string payType,
            string cardNumber, string cardPwd, string orderId, string orderAmount, string dealId, string orderTime,
            string ext1, string ext2, string payAmount, string billOrderTime, string payResult, string signType, string bossType,
            string receiveBossType, string receiverAcctId)
        {
            string key = GetKeyByReceiveBossType(receiveBossType);

            //生成加密串。必须保持如下顺序。
            string merchantSignMsgVal = "";
            merchantSignMsgVal = appendParam(merchantSignMsgVal, "merchantAcctId", merchantAcctId);
            merchantSignMsgVal = appendParam(merchantSignMsgVal, "version", version);
            merchantSignMsgVal = appendParam(merchantSignMsgVal, "language", language);
            merchantSignMsgVal = appendParam(merchantSignMsgVal, "payType", payType);
            merchantSignMsgVal = appendParam(merchantSignMsgVal, "cardNumber", cardNumber);
            merchantSignMsgVal = appendParam(merchantSignMsgVal, "cardPwd", cardPwd);
            merchantSignMsgVal = appendParam(merchantSignMsgVal, "orderId", orderId);
            merchantSignMsgVal = appendParam(merchantSignMsgVal, "orderAmount", orderAmount);
            merchantSignMsgVal = appendParam(merchantSignMsgVal, "dealId", dealId);
            merchantSignMsgVal = appendParam(merchantSignMsgVal, "orderTime", orderTime);
            merchantSignMsgVal = appendParam(merchantSignMsgVal, "ext1", ext1);
            merchantSignMsgVal = appendParam(merchantSignMsgVal, "ext2", ext2);
            merchantSignMsgVal = appendParam(merchantSignMsgVal, "payAmount", payAmount);
            merchantSignMsgVal = appendParam(merchantSignMsgVal, "billOrderTime", billOrderTime);
            merchantSignMsgVal = appendParam(merchantSignMsgVal, "payResult", payResult);
            merchantSignMsgVal = appendParam(merchantSignMsgVal, "signType", signType);
            merchantSignMsgVal = appendParam(merchantSignMsgVal, "bossType", bossType);
            merchantSignMsgVal = appendParam(merchantSignMsgVal, "receiveBossType", receiveBossType);
            merchantSignMsgVal = appendParam(merchantSignMsgVal, "receiverAcctId", receiverAcctId);
            merchantSignMsgVal = appendParam(merchantSignMsgVal, "key", key);

            string merchantSignMsg = GetMD5(merchantSignMsgVal, "utf-8");

            if (signMsg.ToUpper() == merchantSignMsg.ToUpper())
                return true;
            else
                return false;
        }

        public static string BuildReceiveResponse(int result, string redirecturl)
        {
            return string.Format("<result>{0}</result><redirecturl>{1}</redirecturl>", result, redirecturl);
        }
    }
}
