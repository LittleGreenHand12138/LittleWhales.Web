using LittleWhales.Infrastructure;
using System;

namespace LittleWhales.Extensions.Infrastructure
{
    /// <summary>
    /// GUID帮助类
    /// </summary>
    public static class GuidHelper
    {
        /// <summary>
        /// 生成主键
        /// </summary>
        /// <returns></returns>
        public static string GenerateKey()
        {
            return Guid.NewGuid().ToSequentialGuid().ToUpper();
        }
    }
}