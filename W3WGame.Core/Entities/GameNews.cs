using System;
using WangFramework.ORM;
namespace W3WGame.Core.Entities
{

    [TableName("GameNews")]
    [PrimaryKey("ID")]
    public class GameNews
    {
        public int ID { get; set; }
        public int GameID { get; set; }
        public int NewsType { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string ShortDes { get; set; }
        public string ShortDesImg { get; set; }
        public bool IsDisplayHomePage { get; set; }
        public int ClickCount { get; set; }
        public DateTime CreateDate { get; set; }
        public string CreatePeople { get; set; }

        public bool IsWeb { get; set; }

    }
}