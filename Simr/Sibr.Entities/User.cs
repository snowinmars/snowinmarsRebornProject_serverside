using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sibr.Entities
{
    using Sirb.Common.Enums;

    public class User : Entity
    {
        public User(string username) : base()
        {
            this.Username = username;
        }

        public string Email { get; set; }
        public Language Language { get; set; }
        public UserRoles Roles { get; set; }
        public string Username { get; set; }
    }
}
