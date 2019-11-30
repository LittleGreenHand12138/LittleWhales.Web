/*----------------------------------------------------------------
// Copyright (C) 小鲸派
// 版权所有。
//
// 文件名：RightDTO_Update.cs
// 功能描述：
// 
// 创建标识：Wuyuchi 2019/11/12 10:03:42
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
    /// 修改角色权限
    /// </summary>
    public class Right_RoleDTO_Update
    {
        /// <summary>
        /// Id
        /// </summary>
        public string Id { set; get; }
        /// <summary>
        /// 节点Json
        /// </summary>
        public IEnumerable<PowerNodeDTO_Query> NodesJson { set; get; }
    }
}
