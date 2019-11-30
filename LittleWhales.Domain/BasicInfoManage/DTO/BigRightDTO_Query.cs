/*----------------------------------------------------------------
// Copyright (C) 小鲸派
// 版权所有。
//
// 文件名：RightDTO_Query.cs
// 功能描述：
// 
// 创建标识：Wuyuchi 2019/11/6 15:58:32
// 
// 修改标识：
// 修改描述：
//
//----------------------------------------------------------------*/

namespace LittleWhales.Domain.BasicInfoManage.DTO
{
    /// <summary>
    /// 大权限 DTO
    /// </summary>
    public class BigRightDTO_Query
    {
        /// <summary>
        /// Identify 名称
        /// </summary>
        public string IdentifyName { set; get; }
        /// <summary>
        /// Identify Code
        /// </summary>
        public int IdentifyCode { set; get; }
    }
}
