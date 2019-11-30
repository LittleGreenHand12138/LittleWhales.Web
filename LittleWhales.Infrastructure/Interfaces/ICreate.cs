using System;

namespace LittleWhales.Infrastructure.Interfaces
{
    public interface ICreate
    {
        /// <summary>
        /// 创建人
        /// </summary>
        string CreaterId { set; get; }
        /// <summary>
        /// 创建时间
        /// </summary>
        DateTime CreaterTime { set; get; }
    }
}
