using System;
using System.Linq;

using Simr.Common;
using Simr.Entities;
using Simr.IDataLayer;

namespace Simr.DataLayer
{
    public class UserDataLayer : IUserDataLayer
    {
        public User Get(Guid id)
        {
            using (var context = new EntityContext())
            {
                var dbUser = context.DbUsers.FirstOrDefault(x => x.Id == id);

                if (dbUser == null)
                {
                    throw new NotFoundException($"Can't find user with id {id}");
                }

                return dbUser.ToUser();
            }
        }

        public User[] Filter()
        {
            using (var context = new EntityContext())
            {
                var dbUsers = context.DbUsers.Fetch();

                return dbUsers.Select(x => x.ToUser()).ToArray();
            }
        }
    }
}