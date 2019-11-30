/*----------------------------------------------------------------
// Copyright (C) 小鲸派
// 版权所有。
//
// 文件名：TelAttribute.cs
// 功能描述：
// 
// 创建标识：Wuyuchi 2019/11/14 14:20:33
// 
// 修改标识：
// 修改描述：
//
//----------------------------------------------------------------*/
using EntityVerification.Attributes;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace LittleWhales.Infrastructure.ValidateHelper
{
    /// <summary>
    /// 身份证验证
    /// </summary>
    public class IDcardAttribute : BaseAttribute
    {
        public override string error
        {
            get
            {
                if (base.error != null)
                {
                    return base.error;
                }
                return $"身份证号码格式不正确";
            }
            set => base.error = value;
        }
        public string regexText = @"(^\d{18}$)|(^\d{15}$)";
        public override bool Validate(object value)
        {
            var regex = new Regex(regexText);
            return value != null && regex.Match(value.ToString()).Success;
        }
    }
}
