using System;

namespace WebApplication.Core
{
    public class Datesheet : Base
    {
        public DateTime  Session { get; set; }
        public string FileName { get; set; }
        public bool IsActive { get; set; }
    }
}
