namespace WebApplication.Service.Services
{
    public static class Utility
    {
        public static string ToSlug(this string value)
        {
            return value.Trim().ToLower().Replace(" ", "-");
        }
    }
}
