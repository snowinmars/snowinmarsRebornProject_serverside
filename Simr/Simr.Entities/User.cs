using Simr.Common.Enums;

namespace Simr.Entities
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