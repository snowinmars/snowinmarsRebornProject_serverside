using System;
using System.Linq;

using Simr.Common;
using Simr.DataLayer.DbEntities;
using Simr.Entities;
using Simr.IDataLayer;

namespace Simr.DataLayer
{
    public class AuthorDataLayer : IAuthorDataLayer
    {
        public void Add(Author item)
        {
            using (var context = new EntityContext())
            {
                var newDbItem = item.ToDbAuthor();
                Add(context, newDbItem);
            }
        }

        public void Delete(Guid id)
        {
            using (var context = new EntityContext())
            {
                var dbItem = context.DbAuthors.FirstOrDefault(x => x.Id == id);

                if (dbItem == null)
                {
                    throw new NotFoundException($"Can't find item with id {id}");
                }

                context.DbAuthors.Remove(dbItem);
            }
        }

        public Author[] Filter()
        {
            using (var context = new EntityContext())
            {
                var dbAuthors = context.DbAuthors.Fetch();

                return dbAuthors.Select(x => x.ToAuthor()).ToArray();
            }
        }

        public Author Get(Guid id)
        {
            using (var context = new EntityContext())
            {
                var dbAuthor = context.DbAuthors.FirstOrDefault(x => x.Id == id);

                if (dbAuthor == null)
                {
                    throw new NotFoundException($"Can't find author with id {id}");
                }

                return dbAuthor.ToAuthor();
            }
        }
        public void ShallowUpdate(Author item)
        {
            using (var context = new EntityContext())
            {
                var dbItem = context.DbAuthors.FirstOrDefault(x => x.Id == item.Id);

                if (dbItem == default)
                {
                    throw new ArgumentException($"Can't find DbAuthor with id {item.Id}");
                }

                UpdateValues(context, dbItem, item);
            }
        }

        public void ShallowUpsert(Author item)
        {
            using (var context = new EntityContext())
            {
                var dbItem = context.DbAuthors.FirstOrDefault(x => x.Id == item.Id);

                if (dbItem == default)
                {
                    var newDbItem = item.ToDbAuthor();
                    Add(context, newDbItem);
                }
                else
                {
                    UpdateValues(context, dbItem, item);
                }
            }
        }

        private void Add(EntityContext context, DbAuthor newDbItem)
        {
            context.DbAuthors.Add(newDbItem);
            context.SaveChanges();
        }
        private void UpdateValues(EntityContext context, DbAuthor dbItem, Author item)
        {
            dbItem.Aka = item.Aka;
            dbItem.FamilyName = item.Name.FamilyName;
            dbItem.FullMiddleName = item.Name.FullMiddleName;
            dbItem.GivenName = item.Name.GivenName;
            dbItem.IsSynchronized = item.IsSynchronized;
            dbItem.PseudonymFamilyName = item.Pseudonym.FamilyName;
            dbItem.PseudonymFullMiddleName = item.Pseudonym.FullMiddleName;
            dbItem.PseudonymGivenName = item.Pseudonym.GivenName;

            context.SaveChanges();
        }
    }
}