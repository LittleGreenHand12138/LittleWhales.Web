using System;

namespace LittleWhales.DB
{
    [AttributeUsage(AttributeTargets.Class)]
    public class TableNameAttribute : Attribute
    {
        public TableNameAttribute(string tableName)
        {
            Value = tableName;
        }
        public string Value { get; private set; }
    }
}