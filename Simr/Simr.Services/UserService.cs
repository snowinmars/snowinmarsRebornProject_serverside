namespace Simr.Services
{
    using System;

    using Sibr.Entities;
    using Simr.IDataLayer;
    using Simr.IServices;

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