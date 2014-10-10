using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace W3WGame.Core.Dtos.Web
{
    public class NewsDto
    {
        public int ID { get; set; }
        public int GameID { get; set; }
        public int NewsType { get; set; }
        public string Title { get; set; }
        public string ShortDes { get; set; }
        public string ShortDesImg { get; set; }
        public DateTime CreateDate { get; set; }

    }
}
