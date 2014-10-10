using System;
using WangFramework.ORM;
namespace W3WGame.Core.Entities
{

    [TableName("FriendLink")]
    [PrimaryKey("ID")]
    public class FriendLink
    {
        public int ID { get; set; }
        public string LinkUrl { get; set; }
        public string LinkName { get; set; }
        public int LinkType { get; set; }
        public DateTime CreateDate { get; set; }

    }
}