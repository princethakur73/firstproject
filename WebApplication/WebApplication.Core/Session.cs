using System;

namespace WebApplication.Core
{
    public class Session
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public bool IsActive { get; set; }

        public int SortId { get; set; }

        public DateTime CreateByDate { get; set; }

        public int CreateByUserId { get; set; }
    }
}
