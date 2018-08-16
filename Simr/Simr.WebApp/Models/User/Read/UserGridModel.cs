namespace Simr.WebApp.Models.User.Read
{
    using Sirb.Common.Enums;

    public class UserGridModel : Model
    {
        public string Email { get; set; }

        public Language Language { get; set; }

        public UserRoles Roles { get; set; }

        public string Username { get; set; }
    }
}