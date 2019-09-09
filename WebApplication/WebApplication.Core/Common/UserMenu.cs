using System;

namespace WebApplication.Core.Common
{
    public class UserMenu
    {
        public int Id { get; set; }

        public int MenuId { get; set; }
        public Menu Menu { get; set; }

        public int UserId { get; set; }

        public int RoleId { get; set; }
        public Role Role { get; set; }

        public bool IsDelete { get; set; }

        public bool IsUpdate { get; set; }

        public bool IsView { get; set; }

        public bool IsAccess { get; set; }

        public DateTime CreateByDate { get; set; }

        public int CreateByUserId { get; set; }

        public DateTime ModifyByDate { get; set; }

        public int ModifyByUserId { get; set; }

    }
}
