using System.Collections.Generic;
using System.Linq;

using Sibr.Entities;

using Simr.WebApp.Models.User.Read;

namespace Simr.WebApp.Helpers
{
    internal static class UserMapper
    {
        public static IEnumerable<UserGridModel> ToUserGridModels(this User[] users)
        {
            return users.Select(ToUserGridModel);
        }

        public static IEnumerable<User> ToUsers(this UserGridModel[] userGridModels)
        {
            return userGridModels.Select(ToUser);
        }

        public static UserGridModel ToUserGridModel(this User user)
        {
            return new UserGridModel
            {
                Email = user.Email,
                Language = user.Language,
                Roles = user.Roles,
                Username = user.Username,
                Id = user.Id,
            };
        }

        public static User ToUser(this UserGridModel userGridModel)
        {
            return new User(userGridModel.Username)
            {
                Email = userGridModel.Email,
                Language = userGridModel.Language,
                Roles = userGridModel.Roles,
                Id = userGridModel.Id,
            };
        }
    }
}