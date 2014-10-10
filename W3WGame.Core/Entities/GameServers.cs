using System;
using WangFramework.ORM;
namespace W3WGame.Core.Entities
{

    [TableName("GameServers")]
    [PrimaryKey("ID")]
    public class GameServers
    {
        public int ID { get; set; }
        public int GameID { get; set; }
        public string ServerName { get; set; }
        public int ServerID { get; set; }
        public DateTime OpenTime { get; set; }
        public DateTime CreateDate { get; set; }
        public int ServerStat { get; set; }

    }
}