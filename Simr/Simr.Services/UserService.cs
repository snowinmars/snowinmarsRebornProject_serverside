using System;

using Simr.Entities;
using Simr.IDataLayer;
using Simr.IServices;

namespace Simr.Services
{
    public class UserService : IUserService
    {
        public UserService(IUserDataLayer dataLayer)
        {
            DataLayer = dataLayer;
        }

        private IUserDataLayer DataLayer { get; }

        public User Get(Guid id)
        {
            return DataLayer.Get(id);
        }

        public User[] Filter()
        {
            return DataLayer.Filter();
        }
    }
}