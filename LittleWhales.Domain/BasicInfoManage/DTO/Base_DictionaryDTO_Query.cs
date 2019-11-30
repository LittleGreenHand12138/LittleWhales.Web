using System;
using System.Collections.Generic;
using System.Text;

namespace LittleWhales.Domain.BasicInfoManage.DTO
{
    public class Base_DictionaryDTO_Query
    {
        /// <summary>
        /// 主键Id
        /// </summary>
        public string Id { get; set; }


        /// <summary>
        /// 父级Id
        /// </summary>
        public string ParentId { get; set; }



        /// <summary>
        /// 名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        ///序号
        /// </summary>
        public int SerialNumber { get; set; }

        /// <summary>
        /// 类别
        /// </summary>
        public int Category { get; set; }

        
        public List<objData> objData { get; set; }
    }

    public class objData
    {
        /// <summary>
        /// Id
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// 名称
        /// </summary>
        public string Name { get; set; }
    }
}
