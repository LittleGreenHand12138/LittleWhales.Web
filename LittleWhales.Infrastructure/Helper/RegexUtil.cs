using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
namespace LittleWhales.Extensions.Infrastructure
{
    public class RegexUtil
    {
        public static Regex New(string regex)
        {
            System.Text.RegularExpressions.RegexOptions options = ((System.Text.RegularExpressions.RegexOptions.IgnorePatternWhitespace | System.Text.RegularExpressions.RegexOptions.Multiline)
                        | System.Text.RegularExpressions.RegexOptions.IgnoreCase);
            System.Text.RegularExpressions.Regex reg = new System.Text.RegularExpressions.Regex(regex, options);
            return reg;
        }
    }
}
