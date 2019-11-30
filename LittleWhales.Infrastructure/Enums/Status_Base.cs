/*----------------------------------------------------------------
// Copyright (C) 小鲸派
// 版权所有。
//
// 文件名：Status_Base.cs
// 功能描述：
// 
// 创建标识：Wuyuchi 2019/11/7 15:34:01
// 
// 修改标识：
// 修改描述：
//
//----------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace LittleWhales.Infrastructure.Enums
{
    public enum Status_Base
    {
        /// <summary>
        /// 启用
        /// </summary>
        [Description("启用")]
        Enabling = 1,

        /// <summary>
        /// 禁用
        /// </summary>
        [Description("禁用")]
        Disabling = 2,
    }
}
