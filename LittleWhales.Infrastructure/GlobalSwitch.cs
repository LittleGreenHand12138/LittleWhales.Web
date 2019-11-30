/*----------------------------------------------------------------
// Copyright (C) 小鲸派
// 版权所有。
//
// 文件名：GlobalSwitch.cs
// 功能描述：
// 
// 创建标识：Wuyuchi 2019/11/8 9:58:37
// 
// 修改标识：
// 修改描述：
//
//----------------------------------------------------------------*/
using LittleWhales.Infrastructure.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace LittleWhales.Infrastructure
{

    /// <summary>
    /// 全局控制
    /// </summary>
    public class GlobalSwitch
    {
        #region 构造函数



        #endregion

        #region 参数

        /// <summary>
        /// 项目名
        /// </summary>
        public static string ProjectName { get; } = "LittleWhales";

        /// <summary>
        /// 网站根地址
        /// </summary>
        public static string WebRootUrl { get; set; } = "http://localhost:51126";

        #endregion

        #region 运行


        /// <summary>
        /// 网站文件根路径
        /// </summary>
        public static string WebRootPath { get => AppContext.BaseDirectory; }

        public static string CacheVerificationCode { get; set; } = "UpdatePasswordVerificationCode";

        public static string ExcelMouldPath { get; set; } = "\\ExcelModel\\";
        public static string DriverPathName { get; set; } = "司机导入模板.xls";
        public static string VehiclePathName { get; set; } = "车辆导入模板.xls";

        #endregion

        #region 数据库

        /// <summary>
        /// 默认数据库类型
        /// </summary>
        public static DatabaseType DatabaseType { get; } = DatabaseType.MySql;

        /// <summary>
        /// 默认数据库连接名
        /// </summary>
        public static string DefaultDbConName { get; } = "BaseDb";

        #endregion

        #region 缓存

        /// <summary>
        /// 默认缓存
        /// </summary>
        public static CacheType CacheType { get; } = CacheType.SystemCache;

        /// <summary>
        /// Redis配置字符串
        /// </summary>
        public static string RedisConfig { get; } = null /*"localhost:6379,password=123456"*/;

        #endregion

        #region 日志相关

        /// <summary>
        /// 日志记录方式
        /// </summary>
        public static LoggerType LoggerType { get; set; } = LoggerType.RDBMS;

        /// <summary>
        /// ElasticSearch服务器配置
        /// </summary>
        public static Uri[] ElasticSearchNodes { get; set; } = new Uri[] { new Uri("http://localhost:9200/") };

        #endregion
    }
    /// <summary>
    /// 默认缓存类型
    /// </summary>
    public enum CacheType
    {
        /// <summary>
        /// 系统缓存
        /// </summary>
        SystemCache,

        /// <summary>
        /// Redis缓存
        /// </summary>
        RedisCache
    }
}
