using System;

namespace WebApplication.Core
{
    public class LogAction : Base
    {
        public string Description { get; set; }

        public string Controller { get; set; }

        public string Action { get; set; }

        public DateTime PerformedAt { get; set; }

        public long PerformedBy { get; set; }

    }
}
