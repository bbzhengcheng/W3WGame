using System;
using WangFramework.ORM;
namespace W3WGame.Core.Entities
{

    [TableName("AccountLoginLog")]
    [PrimaryKey("ID")]
    public class AccountLoginLog
    {
        /// <summary>
        /// ID
        /// </summary>
        public int ID { get; set; }

        /// <summary>
        /// Account
        /// </summary>
        public string Account { get; set; }

        /// <summary>
        /// IP
        /// </summary>
        public string IP { get; set; }

        /// <summary>
        /// CreateDate
        /// </summary>
        public DateTime CreateDate { get; set; }


    }
}