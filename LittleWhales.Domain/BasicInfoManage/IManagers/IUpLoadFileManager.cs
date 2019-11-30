/*----------------------------------------------------------------
// Copyright (C) 小鲸派
// 版权所有。
//
// 文件名：IUpLoadFileManager.cs
// 功能描述：
// 
// 创建标识：Wuyuchi 2019/11/8 16:38:06
// 
// 修改标识：
// 修改描述：
//
//----------------------------------------------------------------*/
using LittleWhales.Infrastructure.LeftStyle;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace LittleWhales.Domain.BasicInfoManage.IManagers
{
    /// <summary>
    /// 文件上传逻辑处理
    /// </summary>
    public interface IUpLoadFileManager : ITransientDependency
    {
        /// <summary>
        /// 文件上传
        /// </summary>
        /// <param name="fileBase64"></param>
        /// <param name="fileName"></param>
        /// <returns></returns>
        string UploadFile(IFormFile files);
    }
}
