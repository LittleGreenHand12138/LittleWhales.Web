/*----------------------------------------------------------------
// Copyright (C) 小鲸派
// 版权所有。
//
// 文件名：Category_Sex.cs
// 功能描述：
// 
// 创建标识：Wuyuchi 2019/11/7 17:32:17
// 
// 修改标识：
// 修改描述：
//
//----------------------------------------------------------------*/
using System.ComponentModel;

namespace LittleWhales.Domain.BasicInfoManage.Enums
{
    /// <summary>
    /// 性别枚举
    /// </summary>
    public enum Category_Sex
    {
        /// <summary>
        /// 男
        /// </summary>
        [Description("男")]
        Man = 1,

        /// <summary>
        /// 女
        /// </summary>
        [Description("女")]
        Woman = 2,
    }
}
