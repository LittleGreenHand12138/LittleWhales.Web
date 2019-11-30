/*----------------------------------------------------------------
// Copyright (C) 小鲸派
// 版权所有。
//
// 文件名：PowerNodeDTO_Query.cs
// 功能描述：
// 
// 创建标识：Wuyuchi 2019/11/6 14:00:16
// 
// 修改标识：
// 修改描述：
//
//----------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.Text;

namespace LittleWhales.Domain.BasicInfoManage.DTO
{
    /// <summary>
    /// 权限功能DTO
    /// </summary>
    public class PowerNodeDTO_Query
    {
        /// <summary>
        /// Id
        /// </summary>
        public string id { set; get; }
        /// <summary>
        /// 节点名称
        /// </summary>
        public string label { set; get; }
        /// <summary>
        /// 字体图标
        /// </summary>
        public string Icon { set; get; }
        /// <summary>
        /// 地址
        /// </summary>
        public string Path { set; get; }
        /// <summary>
        /// 是否是节点
        /// </summary>
        public bool IsNode { set; get; }
        /// <summary>
        /// 子节点
        /// </summary>
        public IEnumerable<PowerNodeDTO_Query> children { set; get; }
    }
}
