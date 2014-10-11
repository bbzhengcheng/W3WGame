using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace W3WGame.Core.Dtos.Web
{
    public class GameDownloadDto
    {
        public int GameID { get; set; }

        public int Count { get; set; }

        public string GameName { get; set; }

        public string ImgPath { get; set; }

        public int HotScore { get; set; }

        public decimal Size { get; set; }

        public int YunYingState { get; set; }
    }
}
