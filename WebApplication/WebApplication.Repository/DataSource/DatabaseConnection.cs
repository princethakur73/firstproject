using System.Configuration;

namespace WebApplication.Repository
{
    public static class DatabaseConnection
    {
        public static string ConnectionString = ConfigurationManager.ConnectionStrings["HvmSchool"].ConnectionString;
    }
}
