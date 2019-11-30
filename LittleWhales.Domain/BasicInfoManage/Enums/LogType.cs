/*----------------------------------------------------------------
// Copyright (C) 小鲸派
// 版权所有。
//
// 文件名：LogType.cs
// 功能描述：
// 
// 创建标识：Wuyuchi 2019/11/7 16:42:56
// 
// 修改标识：
// 修改描述：
//
//----------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.Text;

namespace LittleWhales.Domain.BasicInfoManage.Enums
{
    /// <summary>
    /// 系统日志 操作枚举
    /// </summary>
    public enum LogType
    {
        增加 = 1,
        删除 = 2,
        修改 = 3,
        查询 = 4,
    }
}
