using System;
using WangFramework.ORM;
namespace W3WGame.Core.Entities
{

    [TableName("GameKaDetail")]
    [PrimaryKey("ID")]
    public class GameKaDetail
    {
        public int ID { get; set; }
        public int KaID { get; set; }
        public bool IsUser { get; set; }
        public string UseAccount { get; set; }
        public DateTime? UsedDate { get; set; }
        public string Code { get; set; }

    }
}