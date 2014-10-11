using System;
using WangFramework.ORM;
namespace W3WGame.Core.Entities
{

    [TableName("GameDownloadUrls")]
    [PrimaryKey("ID")]
    public class GameDownloadUrls
    {
        /// <summary>
        /// ID
        /// </summary>
        public int ID { get; set; }

        /// <summary>
        /// 游戏
        /// </summary>
        public int GameID { get; set; }

        /// <summary>
        /// 运行系统
        /// </summary>
        public int GameSys { get; set; }

        /// <summary>
        /// 下载地址
        /// </summary>
        public string DownloadUrl { get; set; }

        /// <summary>
        /// 下载次数
        /// </summary>
        public int Count { get; set; }

        /// <summary>
        /// 添加时间
        /// </summary>
        public DateTime CreateDate { get; set; }

        /// <summary>
        /// 最久一次下载日期
        /// </summary>
        public DateTime LastDownloadDate { get; set; }


    }
}