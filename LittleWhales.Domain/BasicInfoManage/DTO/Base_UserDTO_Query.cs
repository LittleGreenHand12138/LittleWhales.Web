using LittleWhales.Domain.BasicInfoManage.Enums;
using LittleWhales.Infrastructure;
using LittleWhales.Infrastructure.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace LittleWhales.Domain.BasicInfoManage.DTO
{
    public class Base_UserDTO_Query
    {
        /// <summary>
        /// 主键Id
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// 账号
        /// </summary>
        public string Account { get; set; }

        /// <summary>
        /// 密码
        /// </summary>
        public string Password { get; set; }

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

        /// <summary>
        /// 状态
        /// </summary>
        public int Status { get; set; }
        
        /// <summary>
        /// 创建人
        /// </summary>
        public string CreaterName { get; set; }

        /// <summary>
        /// 性别
        /// </summary> 
        public string SexName
        {
            get { return EnumUtil.GetDescription<Category_Sex, int>(Sex); }
            set { if (value == null) throw new ArgumentNullException("value"); }
        }


        /// <summary>
        /// 状态
        /// </summary>  
        public string StatusName
        {
            get { return EnumUtil.GetDescription<Status_Base, int>(Status); }
            set { if (value == null) throw new ArgumentNullException("value"); }
        } 
        public string IsSuperAdminName
        {
            get { return IsSuperAdmin ? "是" : "否"; }
            set { if (value == null) throw new ArgumentNullException("value"); }
        }
    }
}
