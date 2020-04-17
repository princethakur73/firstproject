using System;

namespace WebApplication.Core
{
    public class Circulars : Base
    {
        public string Title { get; set; }
        public string FileName { get; set; }
        public string Extenstion { get; set; }
        public bool IsActive { get; set; }
        public int SortId { get; set; }
    }
}
