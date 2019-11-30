using System;
using System.Collections.Generic;
using System.Text;

namespace LittleWhales.Domain.BasicInfoManage.DTO
{
    /// <summary>
    /// 添加版本
    /// </summary>
    public class Base_EditionDTO_Query
    {
        /// <summary>
        /// 主键Id
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// 系统名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 当前版本号
        /// </summary>
        public string VersionNumber { get; set; }

        /// <summary>
        /// 是否强制更新
        /// </summary>
        public bool IsCompelUpdate { get; set; }
    }
}
