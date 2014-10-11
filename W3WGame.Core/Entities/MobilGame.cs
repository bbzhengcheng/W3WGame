using System;
using WangFramework.ORM;
namespace W3WGame.Core.Entities
{

    [TableName("MobilGame")]
    [PrimaryKey("ID")]
    public class MobilGame
    {
        public int ID { get; set; }
        public string GameName { get; set; }
        public string ImgPath { get; set; }
        public int Sys { get; set; }
        public decimal Size { get; set; }
        public bool HasGift { get; set; }
        public bool IsHot { get; set; }
        public bool IsNew { get; set; }
        public bool IsBiWan { get; set; }
        public bool IsThisAWeekHot { get; set; }
        public bool IsTuiJian { get; set; }
        public int GameType { get; set; }
        public int GameTeZhen { get; set; }
        public int YunYingState { get; set; }
        public int HotScore { get; set; }
        public DateTime CreateDate { get; set; }
        public bool IsQianLiBao { get; set; }
       
        public bool IsGameType { get; set; }
        public int Sort { get; set; }


    }
}