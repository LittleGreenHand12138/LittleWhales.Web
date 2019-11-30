/*----------------------------------------------------------------
// Copyright (C) 小鲸派
// 版权所有。
//
// 文件名：RolesDTO_Query.cs
// 功能描述：
// 
// 创建标识：Wuyuchi 2019/11/12 10:02:57
// 
// 修改标识：
// 修改描述：
//
//----------------------------------------------------------------*/
using LittleWhales.Infrastructure.Enums;

namespace LittleWhales.Domain.BasicInfoManage.DTO
{
    /// <summary>
    /// 角色查询的dto
    /// </summary>
    public class RolesDTO_Query : RolesDTO_Update
    {
        /// <summary>
        /// 权限角色
        /// </summary>
        public string PowerRight { set; get; }
        /// <summary>
        /// 是否启动
        /// </summary>
        public new string IsStartUp { set; get; }
    }
}
