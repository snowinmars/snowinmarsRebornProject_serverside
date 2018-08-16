using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Sibr.Entities;

using Simr.IServices;

namespace Simr.Services
{
    public class UserService : IUserService
    {
        public User Get(Guid id)
        {
            return new User("Alex");
        }

        public User[] Filter()
        {
            return new[]
            {
                new User("Alex"), new User("Alex"), new User("Alex"), new User("Alex"), new User("Alex"),
                new User("Alex"), new User("Alex"), new User("Alex"), new User("Alex"), new User("Alex"),
                new User("Alex"), new User("Alex"), new User("Alex"), new User("Alex"), new User("Alex"),
            };
        }
    }
}
