/*----------------------------------------------------------------
// Copyright (C) 小鲸派
// 版权所有。
//
// 文件名：ITableKey.cs
// 功能描述：
// 
// 创建标识：Wuyuchi 2019/11/6 17:32:27
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
    public interface ITableKey
    {
        /// <summary>
        /// 主键Id
        /// </summary>
        string Id { set; get; }
    }
}
