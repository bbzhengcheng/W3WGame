using System;

namespace W3WGame.Core.Dtos
{
    public class ArticleDto
    {
        /// <summary>
        /// 新闻Id
        /// </summary>
        public int ArticleId { get; set; }

        /// <summary>
        /// 新闻类别Id
        /// </summary>
        public int ArticleCategoryId { get; set; }

        /// <summary>
        /// 新闻类型名称
        /// </summary>
        public string CategoryName { get; set; }

        /// <summary>
        /// 新闻标题
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// 新闻排序编码
        /// </summary>
        public int SortOrder { get; set; }

        /// <summary>
        /// 是否显示
        /// </summary>
        public bool IsShow { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreateTime { get; set; }
    }
}
