namespace WebApplication.Core.Common
{
    public class Menu
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int ParentMenuId { get; set; }

        public string Controller { get; set; }

        public string Action { get; set; }

        public string Icon { get; set; }

        public int SortId { get; set; }

        public bool IsActive { get; set; }

    }
}
