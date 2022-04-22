using System;

namespace WebApplication.Core
{
    public class Ptm : Base
    {
        public DateTime Month { get; set; }
        public string Title { get; set; }
        public string Class { get; set; }
        public string Time { get; set; }
        public int SortId { get; set; }
        public bool IsActive { get; set; }
        public int TotalRecords { get; set; }
    }
}
