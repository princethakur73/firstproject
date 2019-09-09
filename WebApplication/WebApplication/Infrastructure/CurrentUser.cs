using Microsoft.AspNet.Identity;
using System.Collections.Generic;
using System.Security.Principal;
using System.Web;
using WebApplication.Core;
using WebApplication.Core.Common;
using WebApplication.Service;
using WebApplication.Service.Services;

namespace WebApplication.Infrastructure
{
    public class CurrentUser : ICurrentUser
    {
        private readonly IIdentity _identity;
        private readonly IUserService _userService;
        private ICommonService _commonService;

        private string MenuList = "MenuList";
        private string UserDetail = "UserDetail";

        public CurrentUser(IIdentity identity,
            IUserService userService,
            ICommonService commonService)
        {
            _identity = identity;
            _userService = userService;
            _commonService = commonService;
            MenuList += "-" + _identity.GetUserId<int>().ToString();
            UserDetail += "-" + _identity.GetUserId<int>().ToString();
        }
        public User User
        {
            get
            {
                if (HttpContext.Current.Session[UserDetail] == null)
                {
                    var user = _userService.GetById(_identity.GetUserId<int>(), 0);
                    HttpContext.Current.Session[UserDetail] = user;

                }
                return (User)HttpContext.Current.Session[UserDetail];

            }
        }

        public List<UserMenu> UserMenu
        {
            get
            {
                if (HttpContext.Current.Session[MenuList] == null)
                {
                    var menuList = _commonService.GetUserMenuByUserId((int)User.Id);
                    HttpContext.Current.Session[MenuList] = menuList;

                }
                return (List<UserMenu>)HttpContext.Current.Session[MenuList];
            }
        }
    }
}
