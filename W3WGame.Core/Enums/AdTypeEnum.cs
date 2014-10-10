using System.ComponentModel;

namespace W3WGame.Core.Enums
{
    public enum AdTypeEnum
    {
        /// <summary>
        /// 首页轮播广告
        /// </summary>
        [Description("图片")]
        Img = 1,

        /// <summary>
        /// 最新商品轮播广告
        /// </summary>
        [Description("flash")]
        Flash = 2,

    }
}