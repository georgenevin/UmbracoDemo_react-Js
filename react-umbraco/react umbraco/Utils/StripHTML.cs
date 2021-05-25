using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace react_test.Utils
{
    public class StripHTML
    {
        public static string StripHTMLS(string input)
        {
            return Regex.Replace(input, "<.*?>", String.Empty);
        }



    }
}