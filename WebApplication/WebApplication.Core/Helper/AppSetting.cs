using System.Configuration;

namespace WebApplication.Core.Helper
{
    public static class AppSetting
    {
        public static string Host = ConfigurationManager.AppSettings["Host"];
        public static int Port = int.Parse(ConfigurationManager.AppSettings["Port"]);
        public static string From = ConfigurationManager.AppSettings["From"];
        public static string Password = ConfigurationManager.AppSettings["Password"];
        public static string SchoolEmail = ConfigurationManager.AppSettings["SchoolEmail"];
    }
}
