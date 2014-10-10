using System;
using W3WGame.Core.Enums;
using WangFramework.ORM;

namespace W3WGame.Core.Entities
{
    /// <summary>
    /// AdInfo:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [TableName("AdInfo")]
    [PrimaryKey("AdInfoId")]
    public class AdInfo
    {
        /// <summary>
        /// 广告ID
        /// </summary>
        public int AdInfoId { get; set; }

        /// <summary>
        /// 广告类型
        /// </summary>
        public AdTypeEnum AdType { get; set; }

        /// <summary>
        /// 广告标题
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// 广告图片地址
        /// </summary>
        public string ImgPath { get; set; }

        /// <summary>
        /// 广告指向地址
        /// </summary>
        public string Ahref { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreateDate { get; set; }

        /// <summary>
        /// 广告排序
        /// </summary>
        public int Sort { get; set; }
    }
}
