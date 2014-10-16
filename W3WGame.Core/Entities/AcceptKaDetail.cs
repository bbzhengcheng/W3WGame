using System;
using WangFramework.ORM;
namespace W3WGame.Core.Entities
{

    [TableName("AcceptKaDetail")]
    [PrimaryKey("ID")]
    public class AcceptKaDetail
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
        /// Code
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// AcceptDate
        /// </summary>
        public DateTime AcceptDate { get; set; }

        /// <summary>
        /// KaID
        /// </summary>
        public int KaID { get; set; }

        /// <summary>
        /// AcceptType
        /// </summary>
        public int AcceptType { get; set; }

        /// <summary>
        /// GameID
        /// </summary>
        public int GameID { get; set; }

        /// <summary>
        /// ServerID
        /// </summary>
        public int ServerID { get; set; }


    }
}