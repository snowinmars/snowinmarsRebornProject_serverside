using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Sirb.Common.Enums;

namespace Sibr.Entities
{
    public class User : Entity
    {
        public User(string username)
        {
            this.Username = username;
        }

        public string Email { get; set; }
        public Language Language { get; set; }
        public UserRoles Roles { get; set; }
        public string Username { get; }
    }
}
