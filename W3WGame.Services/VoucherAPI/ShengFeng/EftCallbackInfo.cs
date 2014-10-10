namespace W3WGame.Services.VoucherAPI.ShengFeng
{
    /// <summary>
    /// EFTReBackInfo 易付通回调信息
    /// </summary>
    public class EftCallbackInfo
    {
        public EftCallbackInfo()
        {
            //
            // TODO: 在此处添加构造函数逻辑
            //
        }

        private string prim;
        /// <summary>
        /// 易付通回调加密参数串
        /// </summary>
        public string Prim
        {
            get { return prim; }
            set { prim = value; }
        }
        private string id;
        /// <summary>
        /// 易付通回调加密参数串动态解密密钥对应id
        /// </summary>
        public string Id
        {
            get { return id; }
            set { id = value; }
        }
        private string dkUrl;
        /// <summary>
        /// 易付通回调加密参数串取动态解密密钥地址
        /// </summary>
        public string DkUrl
        {
            get { return dkUrl; }
            set { dkUrl = value; }
        }
        private string key;
        /// <summary>
        /// 解密密钥
        /// </summary>
        public string Key
        {
            get { return key; }
            set { key = value; }
        }
        private string payState;
        /// <summary>
        /// 订单状态
        /// </summary>
        public string PayState
        {
            get { return payState; }
            set { payState = value; }
        }
        private string mchNo;
        /// <summary>
        /// 订单号,原样返回,充值唯一凭证
        /// </summary>
        public string MchNo
        {
            get { return mchNo; }
            set { mchNo = value; }
        }
        private string productCode;
        /// <summary>
        /// 产品计费编码,原样返回,验证用
        /// </summary>
        public string ProductCode
        {
            get { return productCode; }
            set { productCode = value; }
        }
        private string ip;
        /// <summary>
        /// 易付通服务器当前请求ip,验证用
        /// </summary>
        public string Ip
        {
            get { return ip; }
            set { ip = value; }
        }
        private string whiteIpList;
        /// <summary>
        /// ip白名单,验证用
        /// </summary>
        public string WhiteIpList
        {
            get { return whiteIpList; }
            set { whiteIpList = value; }
        }
    }
}
