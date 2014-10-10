using System.ComponentModel;

namespace W3WGame.Core.Enums
{
    /// <summary>
    /// 支付状态
    /// </summary>
    public enum PayStatus
    {
        /// <summary>
        /// 待支付
        /// </summary>
        [Description("待支付")]
        Wait = 1,

        /// <summary>
        /// 支付成功
        /// </summary>
        [Description("支付成功")]
        Success = 2,

        /// <summary>
        /// 支付失败
        /// </summary>
        [Description("支付失败")]
        False = 3
    }
}