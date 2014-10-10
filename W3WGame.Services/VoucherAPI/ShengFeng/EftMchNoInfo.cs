namespace W3WGame.Services.VoucherAPI.ShengFeng
{
    /// <summary>
    /// EftMchNoInfo 易付通订单信息类
    /// </summary>
    public class EftMchNoInfo
    {
        public EftMchNoInfo()
        {
            //
            // TODO: 在此处添加构造函数逻辑
            //
        
        }
        private string mchNo;
        /// <summary>
        /// 订单号
        /// </summary>
        public string MchNo
        {
            get { return mchNo; }
            set { mchNo = value; }
        }
        private string account;
        /// <summary>
        /// 用户充值账户
        /// </summary>
        public string Account
        {
            get { return account; }
            set { account = value; }
        }
        private string productCode;
        /// <summary>
        /// 用户选择产品计费编码
        /// </summary>
        public string ProductCode
        {
            get { return productCode; }
            set { productCode = value; }
        }
        private string mchid;
        /// <summary>
        /// 商户编码
        /// </summary>
        public string Mchid
        {
            get { return mchid; }
            set { mchid = value; }
        }
        private string gkId;
        /// <summary>
        /// 取动态密钥ID
        /// </summary>
        public string GkId
        {
            get { return gkId; }
            set { gkId = value; }
        }
        private string eftUrl;
        /// <summary>
        /// 易付通提交地址
        /// </summary>
        public string EftUrl
        {
            get { return eftUrl; }
            set { eftUrl = value; }
        }
        private string ekUrl;
        /// <summary>
        /// 易付通取动态加密密钥地址
        /// </summary>
        public string EkUrl
        {
            get { return ekUrl; }
            set { ekUrl = value; }
        }
        private string prim;
        /// <summary>
        /// 密文参数串
        /// </summary>
        public string Prim
        {
            get { return prim; }
            set { prim = value; }
        }
        private string key;
        /// <summary>
        /// 加密密钥
        /// 16位
        /// </summary>
        public string Key
        {
            get { return key; }
            set { key = value; }
        }
        private string id;
        /// <summary>
        /// 密文参数串对应解密id
        /// 32位
        /// </summary>
        public string Id
        {
            get { return id; }
            set { id = value; }
        }
    }
}
