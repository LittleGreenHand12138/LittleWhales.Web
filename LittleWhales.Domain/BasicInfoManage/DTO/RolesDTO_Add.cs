/*----------------------------------------------------------------
// Copyright (C) 小鲸派
// 版权所有。
//
// 文件名：RolesDTO_Add.cs
// 功能描述：
// 
// 创建标识：Wuyuchi 2019/11/6 18:27:02
// 
// 修改标识：
// 修改描述：
//
//----------------------------------------------------------------*/
using EntityVerification.Attributes;
using LittleWhales.Infrastructure.Enums;

namespace LittleWhales.Domain.BasicInfoManage.DTO
{
    /// <summary>
    /// 添加角色
    /// </summary>
    public class RolesDTO_Add
    {
        /// <summary>
        /// 角色名称
        /// </summary>
        [Name("角色名称")]
        [StringRange(min = 2, max = 10)]
        public string RoleName { set; get; }
        /// <summary>
        /// 权限角色
        /// </summary>
        [Name("权限角色")]
        [Required]
        public Right Right { set; get; }
    }
}
