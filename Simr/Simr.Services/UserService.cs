using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simr.Services
{
    using Sibr.Entities;

    using Simr.IServices;

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
