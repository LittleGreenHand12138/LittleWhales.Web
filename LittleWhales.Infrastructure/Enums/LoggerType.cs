/*----------------------------------------------------------------
// Copyright (C) 小鲸派
// 版权所有。
//
// 文件名：LoggerType.cs
// 功能描述：
// 
// 创建标识：Wuyuchi 2019/11/8 10:00:06
// 
// 修改标识：
// 修改描述：
//
//----------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.Text;

namespace LittleWhales.Infrastructure.Enums
{
    /// <summary>
    /// 日志操作类型
    /// </summary>
    public enum LoggerType
    {
        /// <summary>
        /// 使用关系型数据库记录日志,例如SQlServer、MySQL、Oracle等
        /// </summary>
        RDBMS,

        /// <summary>
        /// 使用ElasticSearch记录日志
        /// </summary>
        ElasticSearch
    }
}
