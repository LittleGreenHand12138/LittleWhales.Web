using System;
using System.Collections.Generic;
using System.Text;

namespace LittleWhales.Domain.BasicInfoManage.DTO
{
    public class Base_UserDTO_Add
    {
        /// <summary>
        /// 账号
        /// </summary>
        public string Account { get; set; }
         

        /// <summary>
        /// 姓名
        /// </summary>
        public string TrueName { get; set; }

        /// <summary>
        /// 性别
        /// </summary>
        public int Sex { get; set; }

        /// <summary>
        /// 联系电话
        /// </summary>
        public string Tel { get; set; }

        /// <summary>
        /// 工号
        /// </summary>
        /// <returns></returns>
        public string JobNumber { get; set; }


        /// <summary>
        /// 是否是超级管理员
        /// </summary>
        public bool IsSuperAdmin { get; set; }
    }
}
