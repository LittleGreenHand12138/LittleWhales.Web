using System.ComponentModel;

namespace LittleWhales.BasicInfoManage.Enums
{
    /// <summary>
    /// 枚举类型
    /// </summary>
    public enum Category_Base_Dictionary
    {
        /// <summary>
        /// 里程数
        /// </summary>
        [DescriptionAttribute("里程数")]
        Mileage = 1,

        /// <summary>
        /// 维修企业类型
        /// </summary>
        [DescriptionAttribute("维修企业类型")]
        RepairEnterprise = 2,

        /// <summary>
        /// 技能类型
        /// </summary>
        [DescriptionAttribute("技能类型")]
        SkillType = 3,

        /// <summary>
        /// 车辆用途
        /// </summary>
        [DescriptionAttribute("车辆用途")]
        VehicleUse = 4,

        /// <summary>
        /// 驾驶证类型
        /// </summary>
        [DescriptionAttribute("驾驶证类型")]
        DriversLicenseCategory = 5,

        /// <summary>
        /// 车辆品牌
        /// </summary>
        [DescriptionAttribute("车辆品牌")]
        Brand = 6,

        /// <summary>
        /// 故障部位
        /// </summary>
        [DescriptionAttribute("故障部位")]
        FaultPosition = 7,

        /// <summary>
        /// 技师认证级别
        /// </summary>
        [DescriptionAttribute("技师认证级别")]
        ArtificerAuthenticationLevel = 8,

        /// <summary>
        /// 维修厂认证级别
        /// </summary>
        [DescriptionAttribute("维修厂认证级别")]
        RepairFactoryAuthenticationLevel = 9, 

        /// <summary>
        /// 使用性质
        /// </summary>
        [DescriptionAttribute("使用性质")]
        UseProperties = 10,

        /// <summary>
        /// 车辆类型
        /// </summary>
        [DescriptionAttribute("车辆类型")]
        CarCategory = 11,

    }
}
