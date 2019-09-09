using System;

namespace WebApplication.Core
{
    public class Downloads : Base
    {
        public int ClassMasterId { get; set; }
        public string ClassName { get; set; }

        public DateTime Date { get; set; }

        public string Title { get; set; }

        public string FileName { get; set; }

        public int SortId { get; set; }

        public bool IsPublish { get; set; }
    }
}
