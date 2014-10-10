using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace W3WGame.Core.Enums
{
    public enum NewsTypeEnum
    {
        [Description("新闻")]
        News = 1,
        [Description("公告")]
        GongGao = 2,
        [Description("活动")]
        Active = 3,
        [Description("攻略")]
        GongLve = 4
    }
}
