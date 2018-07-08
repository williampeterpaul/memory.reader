using System;
using System.Collections.Generic;
using System.Linq;

namespace memory.reader.Extensions
{
    public static class EnumExtension
    {
        public static IEnumerable<T> GetValues<T>()
        {
            return Enum.GetValues(typeof(T)).Cast<T>();
        }

        public static object TryParseDefault<T>(string valueToParse, bool ignoreCase = true)
        {
            object returnValue = default(T);

            if (Enum.IsDefined(typeof(T), valueToParse))
            {
                returnValue = Enum.Parse(typeof(T), valueToParse, ignoreCase);
            }

            return returnValue;
        }
    }
}
