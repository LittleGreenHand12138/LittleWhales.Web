using System;

namespace LittleWhales.DB
{
    [AttributeUsage(AttributeTargets.Class)]
    public class PrimaryKeyAttribute : Attribute
    {
        public PrimaryKeyAttribute(string primaryKey)
        {
            Value = primaryKey;
            AutoIncrement = false;
        }

        public string Value { get; private set; }
        public string SequenceName { get; set; }
        public bool AutoIncrement { get; set; }
    }
}