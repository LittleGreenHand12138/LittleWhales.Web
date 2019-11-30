/*----------------------------------------------------------------
// Copyright (C) 小鲸派
// 版权所有。
//
// 文件名：IDelete.cs
// 功能描述：
// 
// 创建标识：Wuyuchi 2019/11/13 9:04:07
// 
// 修改标识：
// 修改描述：
//
//----------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.Text;

namespace LittleWhales.Infrastructure.Interfaces
{
    public interface IDelete
    {
        /// <summary>
        /// 是否删除
        /// </summary>
        bool IsDelete { get; set; }
    }
}
