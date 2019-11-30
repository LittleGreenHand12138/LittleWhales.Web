using System;
using System.Collections.Generic;
using System.Text;

namespace LittleWhales.Domain.BasicInfoManage.DTO
{
    /// <summary>
    /// 添加版本
    /// </summary>
    public class Base_EditionItemDTO_Query
    {
        /// <summary>
        /// 主键id
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// 版本Id
        /// </summary>
        public string EditionId { get; set; }


        /// <summary>
        /// 当前版本号
        /// </summary>
        public string VersionNumber { get; set; }


        /// <summary>
        /// 是否强制更新
        /// </summary>
        public bool IsCompelUpdate { get; set; }

        /// <summary>
        /// 更新内容
        /// </summary>
        public string UpdateContent { get; set; }

     
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreaterTime { get; set; }

        /// <summary>
        /// 版本名称
        /// </summary> 
        public string EditionName { get; set; }
    }
}
