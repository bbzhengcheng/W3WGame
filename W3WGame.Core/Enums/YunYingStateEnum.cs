using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace W3WGame.Core.Enums
{
    public enum YunYingStateEnum
    {
        [Description("封测")]
        FengCe = 1,
        [Description("公测")]
        GongCe = 2,
        [Description("新服")]
        XinFu = 3
    }
}
