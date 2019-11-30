using System;
using System.Collections.Generic;
using System.Text;

namespace LittleWhales.Infrastructure
{
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field)] 
    public class FilepathAttribute: Attribute
    {
        string _path;
        public FilepathAttribute(string path)
        {
            _path = path;
        }
    }
}
