using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace LittleWhales.Infrastructure.Enums
{
    /// <summary>
    /// 权限名称
    /// </summary>
    public enum Right
    {
        [Description("管理员")]
        Admin = 1,
        [Description("物流公司")]
        LogisticsCompany = 2,
        [Description("车队老板")]
        CarTeamBoss = 3,
        [Description("维修厂老板")]
        RepairFactoryBoss = 4,
        [Description("技师")]
        Technician = 5,
        [Description("司机")]
        Driver = 10,
    }
}
