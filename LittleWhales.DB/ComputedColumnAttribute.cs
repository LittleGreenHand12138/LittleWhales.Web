using System;

namespace LittleWhales.DB
{
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field)]
    public class ComputedColumnAttribute : ColumnAttribute
    {
        public ComputedColumnAttribute() { }
        public ComputedColumnAttribute(string name) : base(name) { }
    }
}