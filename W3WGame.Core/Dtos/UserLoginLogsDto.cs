using System;

namespace W3WGame.Core.Dtos
{
    public class UserLoginLogsDto
    {
        /// <summary>
        /// Id
        /// </summary>
        public int UserLoginLogId { get; set; }

        /// <summary>
        /// 用户ID
        /// </summary>
        public int UserId { get; set; }

        /// <summary>
        /// 用户名称
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// 登录时间
        /// </summary>
        public DateTime LogOnTime { get; set; }

        /// <summary>
        /// 登录IP
        /// </summary>
        public string IpAddress { get; set; }
    }
}
