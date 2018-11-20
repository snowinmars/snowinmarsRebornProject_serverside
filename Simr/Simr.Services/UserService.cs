using System;

using Simr.Entities;
using Simr.IDataLayer;
using Simr.IServices;

namespace Simr.Services
{
    public class UserService : IUserService
    {
        public UserService(IUserDataLayer userDataLayer)
        {
            UserDataLayer = userDataLayer;
        }

        private IUserDataLayer UserDataLayer { get; }

        public User Get(Guid id)
        {
            return UserDataLayer.Get(id);
        }
        public void Delete(Guid id)
        {
            UserDataLayer.Delete(id);
        }
        public void Update(User item)
        {
            if (item.Id == default)
            {
                throw new ArgumentException("It's impossible to update item without id");
            }

            UserDataLayer.ShallowUpdate(item);
        }

        public void Add(User item)
        {
            item.Id = default;

            UserDataLayer.Add(item);
        }

        public void Upsert(User item)
        {
            UserDataLayer.ShallowUpsert(item);
        }

        public User[] Filter()
        {
            return UserDataLayer.Filter();
        }
    }
}