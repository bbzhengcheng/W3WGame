using System;
using WangFramework.ORM;
namespace W3WGame.Core.Entities
{

    [TableName("GameKa")]
    [PrimaryKey("ID")]
    public class GameKa
    {
        public int ID { get; set; }
        public int KaType { get; set; }
        public string KaTitle { get; set; }
        public int Count { get; set; }
        public int GameID { get; set; }
        public int ServerID { get; set; }
        public DateTime CreateDate { get; set; }
        public int Shengyu { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public bool? IsDisplayHome { get; set; }

        public string KaContent { get; set; }

        public string KaUseDes { get; set; }
    }
}