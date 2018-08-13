using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Simr.WebApp.Models.User
{
    using Sirb.Common.Enums;

    public class UserBase_ReadModel
    {
        public string Email { get; set; }
        public Language Language { get; set; }
        public UserRoles Roles { get; set; }
        public string Username { get; set; }
    }
}