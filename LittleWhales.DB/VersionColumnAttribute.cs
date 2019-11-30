using System;

namespace LittleWhales.DB
{
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field)]
    public class VersionColumnAttribute : ColumnAttribute
    {
        public VersionColumnAttribute() {}
        public VersionColumnAttribute(string name) : base(name) { }
    }
}