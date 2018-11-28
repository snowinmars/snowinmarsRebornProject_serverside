using Simr.Common;
using Simr.DataLayer.DbEntities;
using Simr.Entities;
using Simr.IDataLayer;
using System;
using System.Linq;

namespace Simr.DataLayer
{
    public class SiberiaDataLayer : ISiberiaDataLayer
    {
        public void Add(SiberiaEnvironment item)
        {
            using (var context = new EntityContext())
            {
                var newDbItem = item.ToDbSiberiaEnvironment();
                Add(context, newDbItem);
            }
        }

        public void Delete(Guid id)
        {
            using (var context = new EntityContext())
            {
                var dbItem = context.DbSiberiaEnvironments.FirstOrDefault(x => x.Id == id);

                if (dbItem == null)
                {
                    throw new NotFoundException($"Can't find item with id {id}");
                }

                context.DbSiberiaEnvironments.Remove(dbItem);
                context.SaveChanges();
            }
        }

        public SiberiaEnvironment[] Filter()
        {
            using (var context = new EntityContext())
            {
                var branches = context.DbSiberiaEnvironments.Fetch();

                return branches.Select(x => x.ToSiberiaEnvironment()).ToArray();
            }
        }

        public SiberiaEnvironment Get(Guid id)
        {
            using (var context = new EntityContext())
            {
                var dbSiberiaBranch = context.DbSiberiaEnvironments.FirstOrDefault(x => x.Id == id);

                if (dbSiberiaBranch == null)
                {
                    throw new NotFoundException($"Can't find siberia branch with id {id}");
                }

                return dbSiberiaBranch.ToSiberiaEnvironment();
            }
        }

        public void ShallowUpdate(SiberiaEnvironment item)
        {
            using (var context = new EntityContext())
            {
                var dbItem = context.DbSiberiaEnvironments.FirstOrDefault(x => x.Id == item.Id);

                if (dbItem == null)
                {
                    throw new NotFoundException($"Can't find SiberiaEnvironment with id {item.Id}");
                }

                UpdateValues(context, dbItem, item);
            }
        }

        public void ShallowUpsert(SiberiaEnvironment item)
        {
            using (var context = new EntityContext())
            {
                var dbItem = context.DbSiberiaEnvironments.FirstOrDefault(x => x.Id == item.Id);

                if (dbItem == default)
                {
                    var newDbItem = item.ToDbSiberiaEnvironment();
                    Add(context, newDbItem);
                }
                else
                {
                    UpdateValues(context, dbItem, item);
                }
            }
        }

        private void Add(EntityContext context, DbSiberiaEnvironment item)
        {
            context.DbSiberiaEnvironments.Add(item);
            context.SaveChanges();
        }

        private void UpdateValues(EntityContext context, DbSiberiaEnvironment oldItem, SiberiaEnvironment newItem)
        {
            oldItem.Branch = newItem.Branch;
            oldItem.Environment = newItem.Environment;

            context.SaveChanges();
        }
    }
}