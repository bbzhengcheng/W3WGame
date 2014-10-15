using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace W3WGame.Core.Enums
{
    public enum KaTypeEnum
    {
        [Description("新手卡")]
        NewCard = 1,
        [Description("公会卡")]
        GuildCard = 2,
        [Description("特权卡")]
        SpecialCard = 3,
        [Description("激活码")]
        JiHuo = 3

    }
}
