using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace W3WGame.Core.Dtos.Web
{
   public  class SearchGameKaDto
    {
       public string GameName { get; set; }

       /// <summary>
       /// 
       /// </summary>
       public int GameID { get; set; }


        /// <summary>
        /// 卡id
        /// </summary>
        public int ID { get; set; }

      
     

        public int ServerID { get; set; }

        public string KaTitle { get; set; }

        public string ImgPath { get; set; }

        public int Shengyu { get; set; }

        public int UseNum { get; set; }

        public string KaContent { get; set; }
    }
}
