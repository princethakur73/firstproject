using System.Collections.Generic;
using System.Linq;

namespace WebApplication
{
    public static class Utility
    {
        public static string ToSingleString(this IList<string> values)
        {
            string result = string.Empty;
            if (values.Count > 0)
            {
                foreach (var item in values)
                {
                    if (string.IsNullOrEmpty(result))
                    {
                        result += item;
                    }
                    else
                    {
                        result += string.Concat(", ", item);
                    }
                }
            }
            return result;
        }

        public static IList<string> ToListString(this string value)
        {
            IList<string> result = null;
            if (!string.IsNullOrEmpty(value))
            {
                result = value.Split(',').ToList();
            }
            return result;
        }
    }
}