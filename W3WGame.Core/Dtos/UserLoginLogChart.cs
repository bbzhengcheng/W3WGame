using System;

namespace W3WGame.Core.Dtos
{
    public class UserLoginLogChart
    {
        /// <summary>
        /// 登录时间
        /// </summary>
        public DateTime LoginDate { get; set; }

        /// <summary>
        /// 登录人数
        /// </summary>
        public int Number { get; set; }
    }
}
