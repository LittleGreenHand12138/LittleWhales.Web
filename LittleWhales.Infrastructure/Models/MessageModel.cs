using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LittleWhales.Infrastructure.Models
{
    /// <summary>
    /// 通用返回信息类
    /// </summary>
    public class MessageModel<T>
    {
        /// <summary>
        /// 操作是否成功
        /// </summary>
        public bool success { get; set; } = true;
        /// <summary>
        /// 返回信息
        /// </summary>
        public string msg { get; set; } = "操作成功";
        /// <summary>
        /// 返回数据集合
        /// </summary>
        public T response { get; set; }
        /// <summary>
        /// 错误代码：
        /// 1：未登录
        /// 其它待定义
        /// </summary>
        public int ErrorCode { get; set; } = 200;
    }
}
