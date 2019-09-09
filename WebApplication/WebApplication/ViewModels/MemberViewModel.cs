using System.Collections.Generic;
using WebApplication.Core.Common;
using WebApplication.Models;

namespace WebApplication.ViewModels
{
    public class MemberViewModel
    {
        public List<MemberModel> MemberModels { get; set; }

        public Pager Pager { get; set; }
    }
}