using System;
using System.Collections.Generic;
using System.Text;

namespace LittleWhales.Domain.BasicInfoManage.DTO
{
    public class SysConfigDTO_Update_Query
    {
        /// <summary>
        /// 代理主键
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// 名称
        /// </summary>
        public string SysName { get; set; }

        /// <summary>
        /// 值
        /// </summary>
        public string SysValue { get; set; }
    }
}
