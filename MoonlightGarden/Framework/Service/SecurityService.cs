using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity;

namespace MoonlightGarden.Framework.Service
{
    public class SecurityService
    {
        public string GetCurrentUser()
        {
            return HttpContext.Current.User.Identity.GetUserName();
        }
    }
}