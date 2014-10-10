using System;
using WangFramework.ORM;
namespace W3WGame.Core.Entities
{

    [TableName("ADConfig")]
    [PrimaryKey("ID")]
    public class ADConfig
    {
        public int ID { get; set; }
        public string AdPath { get; set; }
        public string Title { get; set; }
        public string Link { get; set; }
        public int Sort { get; set; }
        public int Place { get; set; }
        public int AdType { get; set; }
        public DateTime CreateDate { get; set; }
        public string CreatePeople { get; set; }

    }
}