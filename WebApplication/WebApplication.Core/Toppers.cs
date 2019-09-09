namespace WebApplication.Core
{
    public class Toppers : Base
    {
        public string Name { get; set; }

        public string CGPA { get; set; }

        public int ClassMasterId { get; set; }
        public string ClassName { get; set; }

        public string Image { get; set; }

        public bool IsActive { get; set; }

        public int SortId { get; set; }
    }
}
