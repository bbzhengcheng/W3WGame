using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace W3WGame.Core.Dtos.Web
{
   public class AcceptKaDetailDto
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

        public string GameName { get; set; }

        public string ImgPath { get; set; }

        public string KaTitle { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }
    }
}
