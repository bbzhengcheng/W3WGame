using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace W3WGame.Core.Enums
{
    public enum GameTypeEnum
    {
        

        [Description("角色")]
        JiaoSe = 1,

        [Description("系统公告")]
        XiuXian = 2,

        [Description("竞速")]
        JingSu = 3,

        [Description("策略")]
        CeLve = 4,

        [Description("音乐")]
        YingYe = 5,

        [Description("射击")]
        SheJi = 6,

        [Description("模拟")]
        MoNi = 7,

        [Description("其它")]
        QiTa = 8

    }
}
