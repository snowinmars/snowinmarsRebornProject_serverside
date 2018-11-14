using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Sibr.Entities;

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
