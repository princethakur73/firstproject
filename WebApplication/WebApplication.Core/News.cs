using System;

namespace WebApplication.Core
{
    public class News : Base
    {
        public DateTime Date { get; set; }

        public string Title { get; set; }

        public string FileName { get; set; }

        public string ShortDescription { get; set; }

        public string Description { get; set; }

        public bool IsActive { get; set; }

        public int Views { get; set; }

        public int SortId { get; set; }
    }
}
