using System;
using WangFramework.ORM;
namespace W3WGame.Core.Entities
{

    [TableName("WebLoginLog")]
    [PrimaryKey("ID")]
    public class WebLoginLog
    {
        public int ID { get; set; }
        public string Account { get; set; }
        public DateTime LoginDate { get; set; }
        public string IP { get; set; }

    }
}