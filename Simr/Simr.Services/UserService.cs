namespace Simr.Services
{
    using System;

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