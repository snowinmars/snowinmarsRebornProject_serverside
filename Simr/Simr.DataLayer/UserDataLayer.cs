using System;

using Simr.Entities;
using Simr.IDataLayer;

namespace Simr.DataLayer
{
    public class UserDataLayer : IUserDataLayer
    {
        public User Get(Guid id)
        {
            throw new NotImplementedException();
        }

        public User[] Filter()
        {
            throw new NotImplementedException();
        }
    }
}