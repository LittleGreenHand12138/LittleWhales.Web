using System;

namespace LittleWhales.Infrastructure.Interfaces
{
    public interface IModify
    {
        /// <summary>
        /// 修改者
        /// </summary>
        string ModifyId { set; get; }
        /// <summary>
        /// 修改时间
        /// </summary>
        DateTime ModifyTime { set; get; }
    }
}
