using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace W3WGame.Core.Dtos
{
    public class GameServersDto
    {
        public int ID { get; set; }
        public string GameName { get; set; }
        public int GameID { get; set; }
        public string ServerName { get; set; }
        public int ServerID { get; set; }
        public DateTime OpenTime { get; set; }
        public DateTime CreateDate { get; set; }
        public int ServerStat { get; set; }
        public string ImgPath { get; set; }
        public int GameType { get; set; }
 
        public int YunYingState { get; set; }
        public int HotScore { get; set; }

    }
}
