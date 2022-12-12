using System;

namespace WebApplication.Core
{
    public class File : Base
    {
        public DateTime  Session { get; set; }
        public string FileName { get; set; }
        public bool IsActive { get; set; }
        public int Type { get; set; }
    }
}
