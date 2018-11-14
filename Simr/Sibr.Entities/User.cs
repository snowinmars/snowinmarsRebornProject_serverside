using Sirb.Common.Enums;

namespace Sibr.Entities
{
    public class User : Entity
    {
        public User(string username)
        {
            Username = username;
        }

        public string Email { get; set; }

        public Language Language { get; set; }

        public UserRoles Roles { get; set; }

        public string Username { get; }
    }
}