using System;
using System.Linq;

using Simr.Common;
using Simr.DataLayer.DbEntities;
using Simr.Entities;
using Simr.IDataLayer;

namespace Simr.DataLayer
{
    public class BookDataLayer : IBookDataLayer
    {
        private IAuthorDataLayer AuthorDataLayer { get; }

        public BookDataLayer(IAuthorDataLayer authorDataLayer)
        {
            AuthorDataLayer = authorDataLayer;
        }

        public void Add(Book item)
        {
            using (var context = new EntityContext())
            {
                var newDbItem = item.ToDbBook();
                Add(context, newDbItem);
            }
        }

        public void Delete(Guid id)
        {
                using (var context = new EntityContext())
                {
                    var dbItem = context.DbBooks.FirstOrDefault(x => x.Id == id);

                    if (dbItem == null)
                    {
                        throw new NotFoundException($"Can't find item with id {id}");
                    }

                    context.DbBooks.Remove(dbItem);
                }
        }

        public Book[] Filter()
        {
            using (var context = new EntityContext())
            {
                var dbBooks = context.DbBooks.Fetch();

                return dbBooks.Select(x => x.ToBook()).ToArray();
            }
        }

        public Book Get(Guid id)
        {
            using (var context = new EntityContext())
            {
                var dbBook = context.DbBooks.FirstOrDefault(x => x.Id == id);

                if (dbBook == null)
                {
                    throw new NotFoundException($"Can't find book with id {id}");
                }

                return dbBook.ToBook();
            }
        }

        public void ShallowUpdate(Book item)
        {
            using (var context = new EntityContext())
            {
                var dbItem = context.DbBooks.FirstOrDefault(x => x.Id == item.Id);

                if (dbItem == null)
                {
                    throw new NotFoundException($"Can't find SiberiaEnvironment with id {item.Id}");
                }

                UpdateValues(context, dbItem, item);
            }
        }

        public void ShallowUpsert(Book item)
        {
            using (var context = new EntityContext())
            {
                var dbItem = context.DbBooks.FirstOrDefault(x => x.Id == item.Id);

                if (dbItem == default)
                {
                    var newDbItem = item.ToDbBook();
                    Add(context, newDbItem);
                }
                else
                {
                    UpdateValues(context, dbItem, item);
                }
            }
        }

        internal void UpdateValues(EntityContext context, DbBook dbItem, Book item)
        {
            dbItem.AdditionalInfo = item.AdditionalInfo;
            dbItem.Bookshelf = item.Bookshelf;
            dbItem.FlibustaUrl = item.FlibustaUrl;
            dbItem.ImageUrl = item.ImageUrl;
            dbItem.IsSynchronized = item.IsSynchronized;
            dbItem.LibRusEcUrl = item.LibRusEcUrl;
            dbItem.LiveLibUrl = item.LiveLibUrl;
            dbItem.Owner = item.Owner;
            dbItem.PageCount = item.PageCount;
            dbItem.Status = item.Status;
            dbItem.Title = item.Title;
            dbItem.Year = item.Year;

            context.SaveChanges();
        }

        private void Add(EntityContext context, DbBook newDbItem)
        {
            context.DbBooks.Add(newDbItem);
            context.SaveChanges();
        }
    }
}