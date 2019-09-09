using System.Collections.Generic;
using WebApplication.Core;
using WebApplication.Core.Common;

namespace WebApplication.Infrastructure
{
    public interface ICurrentUser
    {
        User User { get; }

        List<UserMenu> UserMenu { get; }
    }
}
