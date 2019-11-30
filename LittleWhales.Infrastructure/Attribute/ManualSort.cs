using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace LittleWhales.Infrastructure
{
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field)]
    public class ManualSort: ColumnAttribute
    {
     public ManualSort(string name) : base(name) { }
        
    }
}
