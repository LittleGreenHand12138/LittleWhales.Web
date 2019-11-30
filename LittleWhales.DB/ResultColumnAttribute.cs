using System;

namespace LittleWhales.DB
{
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field)]
    public class ResultColumnAttribute : ColumnAttribute
    {
        public ResultColumnAttribute() { }
        public ResultColumnAttribute(string name) : base(name) { }
    }
}