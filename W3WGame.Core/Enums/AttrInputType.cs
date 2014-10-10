using System.ComponentModel;

namespace W3WGame.Core.Enums
{
    public enum AttrInputType
    {
        /// <summary>
        /// 手工录入
        /// </summary>
        [Description("手工录入")]
        TextBox = 0,

         /// <summary>
        /// 从下面的列表中选择
        /// </summary>
        [Description("从下面的列表中选择")]
        DropDownList = 1,

         /// <summary>
        /// 多行文本框
        /// </summary>
        [Description("多行文本框")]
        TextArea = 2, 
    }
}