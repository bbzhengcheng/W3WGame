using System.Collections.Generic;
using System.ComponentModel;
using System.Web.Mvc;
using WangFramework.Common;

namespace W3WGame.Core.Enums
{
    /// <summary>
    /// 支付类型 
    /// </summary>
    public enum PayType
    {
        /// <summary>
        /// 在线支付
        /// </summary>
        [Description("在线支付")]
        OnlinePay = 1,
    }

    public struct PayFlat
    {
        /// <summary>
        /// 支付宝
        /// </summary>
        [Description("支付宝")]
        public const string AliPay = "01";

        public static string GetDescription(string code)
        {
            return CommonEnu.GetDescription(typeof (PayFlat), code);
        }

        public static List<SelectListItem> GetSelectList()
        {
            return CommonEnu.GetSelectList(typeof (PayFlat));
        }
    }

    public struct PayClass
    {
        /// <summary>
        /// 支付宝
        /// </summary>
        [Description("支付宝")]
        public const string AliPay = "01";

        /// <summary>
        /// 网上银行
        /// </summary>
        [Description("网上银行")]
        public const string Bank = "03";

        [Description("中国工商银行")]
        public const string GongShang = "0301";

        [Description("中国农业银行")]
        public const string NongYe = "0302";

        [Description("中国建设银行")]
        public const string JianShe = "0303";

        [Description("招商银行")]
        public const string ZhaoShang = "0304";

        [Description("中国民生银行")]
        public const string MinSheng = "0305";

        [Description("上海浦东发展银行")]
        public const string PuDong = "0306";

        [Description("兴业银行")]
        public const string XingYe = "0307";

        [Description("深圳发展银行")]
        public const string ShenZhenFaZhan = "0308";

        [Description("北京银行")]
        public const string Beijing = "0309";

        [Description("中国光大银行")]
        public const string GuangDa = "0310";

        [Description("交通银行")]
        public const string JiaoTong = "0311";

        [Description("中信银行")]
        public const string ZhongXin = "0312";

        [Description("中国银行")]
        public const string ZhongGuo = "0313";

        [Description("中国邮政")]
        public const string YouZheng = "0314";

        [Description("华夏银行")]
        public const string HuaXia = "0315";

        [Description("平安银行")]
        public const string PingAn = "0316";

        [Description("国家开发银行")]
        public const string GuoJiaKaiFa = "0317";

        [Description("广州银联")]
        public const string GuangZhou = "0318";

        [Description("广东发展银行")]
        public const string GuangDongFaZhan = "0319";

        [Description("广州市农村信用合作社")]
        public const string GuangZhouNongXin = "0320";

        [Description("广州市商业银行")]
        public const string GuangZhouShangYe = "0321";

        [Description("上海农村商业银行")]
        public const string ShangHaiNongShang = "0322";

        [Description("南京银行")]
        public const string NanJing = "0323";

        [Description("东亚银行")]
        public const string DongYa = "0324";

        [Description("渤海银行")]
        public const string BoHai = "0325";

        [Description("北京农村商业银行")]
        public const string BeiJingNongShang = "0326";

        [Description("中国银联")]
        public const string ZhongGuoYinLian = "0327";

        [Description("徽商银行")]
        public const string HuiShang = "0328";

        [Description("上海银行")]
        public const string ShangHai = "0329";

        [Description("杭州银行")]
        public const string HangZhou = "0330";

        [Description("宁波银行")]
        public const string NingBo = "0331";

        [Description("富滇银行")]
        public const string FuDian = "0333";

        [Description("visa")]
        public const string Visa = "0334";

        public static string GetDescription(string code)
        {
            return CommonEnu.GetDescription(typeof(PayClass), code);
        }

        public static List<SelectListItem> GetSelectList()
        {
            return CommonEnu.GetSelectList(typeof(PayClass));
        }
    }
}