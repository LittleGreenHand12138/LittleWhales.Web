/*----------------------------------------------------------------
// Copyright (C) 小鲸派
// 版权所有。
//
// 文件名：BaseModel.cs
// 功能描述：
// 
// 创建标识：Wuyuchi 2019/11/7 11:38:51
// 
// 修改标识：
// 修改描述：
//
//----------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.Text;

namespace LittleWhales.Infrastructure.Models
{
    public class BaseModel
    {
        /// <summary>
        /// 创建人
        /// </summary>
        public string CreaterId { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreaterTime { get; set; }

        /// <summary>
        /// 是否删除
        /// </summary>
        public bool IsDelete { get; set; }
    }
}
