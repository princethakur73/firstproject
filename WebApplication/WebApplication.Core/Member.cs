﻿namespace WebApplication.Core
{
    public class Member : Base
    {
        public string Name { get; set; }

        public string Desigination { get; set; }

        public string Image { get; set; }
        public string Message { get; set; }
        public string MessageLink { get; set; }

        public bool IsActive { get; set; }

        public int SortId { get; set; }
    }
}
