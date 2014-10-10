using System;
using WangFramework.ORM;
namespace W3WGame.Core.Entities
{

    [TableName("VoucherHistory")]
    [PrimaryKey("ID")]
    public class VoucherHistory
    {
        public int ID { get; set; }
        public string Code { get; set; }
        public string Account { get; set; }
        public int Gold { get; set; }
        public decimal RMB { get; set; }
        public string RetCode { get; set; }
        public string IP { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime FinishDate { get; set; }
        public int GoldState { get; set; }
        public int GameID { get; set; }
        public int ServerID { get; set; }

    }
}