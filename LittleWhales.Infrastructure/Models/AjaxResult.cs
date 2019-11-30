/*----------------------------------------------------------------
// Copyright (C) 小鲸派
// 版权所有。
//
// 文件名：AjaxResult.cs
// 功能描述：
// 
// 创建标识：Wuyuchi 2019/11/11 11:33:21
// 
// 修改标识：
// 修改描述：
//
//----------------------------------------------------------------*/

namespace LittleWhales.Infrastructure.Models
{
    /// <summary>
    /// Ajax请求结果
    /// </summary>
    public class AjaxResult
    {
        /// <summary>
        /// 是否成功
        /// </summary>
        public bool Success { get; set; }

        /// <summary>
        /// 错误代码：
        /// 1：未登录
        /// 其它待定义
        /// </summary>
        public int ErrorCode { get; set; }

        /// <summary>
        /// 返回消息
        /// </summary>
        public string msg { get; set; }

        /// <summary>
        /// 返回数据
        /// </summary>
        public object Data { get; set; }
    }
}
