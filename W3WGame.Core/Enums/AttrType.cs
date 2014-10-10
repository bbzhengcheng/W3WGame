using System.ComponentModel;

namespace W3WGame.Core.Enums
{
    public enum AttrType
    {
        /// <summary>
        /// 唯一属性
        /// </summary>
        [Description("唯一属性")]
        Unique = 0,

        ///// <summary>
        ///// 单选属性
        ///// </summary>
        //[Description("单选属性")]
        //SingleSelection = 1,

        ///// <summary>
        ///// 复选属性
        ///// </summary>
        //[Description("复选属性")]
        //MultiCheck = 2,

        /// <summary>
        /// 多个属性
        /// </summary>
        [Description("多个属性")]
        Multi = 3,

        /// <summary>
        /// 唯一属性必选
        /// </summary>
        [Description("唯一属性必选")]
        UniqueRequired = 4,

        /// <summary>
        /// 多个属性必选
        /// </summary>
        [Description("多个属性必选")]
        MultiRequired = 5,
    }
}