using System;

namespace WebApplicationExtensions
{
    public static class DataTypeExtension
    {

        public static string UrlToPath(this string value)
        {
            var uri = new Uri(value);
            return System.IO.Path.GetFileName(uri.AbsolutePath);
        }
    }
}