/*----------------------------------------------------------------
// Copyright (C) 小鲸派
// 版权所有。
//
// 文件名：RolesDTO_Query_Update.cs
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
    public class RolesDTO_Update
    {
        /// <summary>
        /// Id
        /// </summary>
        public string Id { set; get; }
        /// <summary>
        /// 角色名称
        /// </summary>
        public string RoleName { set; get; }
        /// <summary>
        /// 是否启动
        /// </summary>
        public bool IsStartUp { set; get; }
    }
}
