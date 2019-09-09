using System;

namespace WebApplication.Core
{
    public class Base
    {
        public int Id { get; set; }

        public string Key { get; set; }

        public int UserId { get; set; }

        public DateTime CreateByDate { get; set; }

        public int CreateByUserId { get; set; }

        public DateTime ModifyByDate { get; set; }

        public int ModifyByUserId { get; set; }
    }
}