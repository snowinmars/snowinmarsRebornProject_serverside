using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using Sirb.Common.Enums;

namespace Simr.WebApp.Models.User.Read
{
    public class UserGridModel : Model
    {
        public string Email { get; set; }
        public Language Language { get; set; }
        public UserRoles Roles { get; set; }
        public string Username { get; set; }
    }
}