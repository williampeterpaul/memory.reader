using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace memory.reader.Extensions
{
    public static class StringExtension
    {
        public static string RemoveAllExtensions(this string value)
        {
            var index = value.IndexOf('.');
            if (index < 0) return value;
            return value.Remove(index);
        }
    }
}
