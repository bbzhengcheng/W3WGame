using System;
using WangFramework.ORM;
namespace W3WGame.Core.Entities
{

    [TableName("AccountInfo")]
    [PrimaryKey("ID")]
    public class AccountInfo
    {
        public int ID { get; set; }
        public string Account { get; set; }
        public string Password { get; set; }
        public string NickName { get; set; }
        public DateTime RegDate { get; set; }
        public string RegIP { get; set; }
        public string IPAddress { get; set; }

        public string Phone { get; set; }

        public string QQ { get; set; }

        public string Email { get; set; }


    }
}