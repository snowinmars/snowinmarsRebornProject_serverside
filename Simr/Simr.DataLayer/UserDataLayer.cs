using System;
using System.Linq;

using Simr.Common;
using Simr.DataLayer.DbEntities;
using Simr.Entities;
using Simr.IDataLayer;

namespace Simr.DataLayer
{
    public class UserDataLayer : IUserDataLayer
    {
        public void Add(User item)
        {
            using (var context = new EntityContext())
            {
                var newDbItem = item.ToDbUser();
                Add(context, newDbItem);
            }
        }

        public void Delete(Guid id)
        {
            using (var context = new EntityContext())
            {
                var dbItem = context.DbUsers.FirstOrDefault(x => x.Id == id);

                if (dbItem == null)
                {
                    throw new NotFoundException($"Can't find item with id {id}");
                }

                context.DbUsers.Remove(dbItem);
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

        public void ShallowUpdate(User item)
        {
            using (var context = new EntityContext())
            {
                var dbItem = context.DbUsers.FirstOrDefault(x => x.Id == item.Id);

                if (dbItem == null)
                {
                    throw new NotFoundException($"Can't find SiberiaEnvironment with id {item.Id}");
                }

                UpdateValues(context, dbItem, item);
            }
        }

        public void ShallowUpsert(User item)
        {
            using (var context = new EntityContext())
            {
                var dbItem = context.DbUsers.FirstOrDefault(x => x.Id == item.Id);

                if (dbItem == default)
                {
                    var newDbItem = item.ToDbUser();
                    Add(context, newDbItem);
                }
                else
                {
                    UpdateValues(context, dbItem, item);
                }
            }
        }

        private void Add(EntityContext context, DbUser newDbItem)
        {
            context.DbUsers.Add(newDbItem);
            context.SaveChanges();
        }
        private void UpdateValues(EntityContext context, DbUser dbItem, User item)
        {
            dbItem.Email = item.Email;
            dbItem.IsSynchronized = item.IsSynchronized;
            dbItem.Language = item.Language;
            dbItem.Roles = item.Roles;
            dbItem.Username = item.Username;

            context.SaveChanges();
        }
    }
}