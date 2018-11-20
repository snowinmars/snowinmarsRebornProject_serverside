using System;

using Simr.Entities;
using Simr.IDataLayer;
using Simr.IServices;

namespace Simr.Services
{
    public class BookService : IBookService
    {
        public BookService(IBookDataLayer bookDataLayer, IAuthorDataLayer authorDataLayer)
        {
            BookDataLayer = bookDataLayer;
            AuthorDataLayer = authorDataLayer;
        }
        public void Delete(Guid id)
        {
            BookDataLayer.Delete(id);
        }

        public IAuthorDataLayer AuthorDataLayer { get; set; }

        private IBookDataLayer BookDataLayer { get; }

        public void Upsert(Book item)
        {
            BookDataLayer.ShallowUpsert(item);

            foreach (var dbAuthor in item.Authors)
            {
                AuthorDataLayer.ShallowUpsert(dbAuthor);
            }
        }

        public Book[] Filter()
        {
            return BookDataLayer.Filter();
        }

        public Book Get(Guid id)
        {
            return BookDataLayer.Get(id);
        }

        public void Update(Book item)
        {
            if (item.Id == default)
            {
                throw new ArgumentException("It's impossible to update item without id");
            }

            BookDataLayer.ShallowUpdate(item);

            foreach (var dbAuthor in item.Authors)
            {
                AuthorDataLayer.ShallowUpsert(dbAuthor);
            }
        }

        public void Add(Book item)
        {
            item.Id = default;

            BookDataLayer.Add(item);

            foreach (var dbAuthor in item.Authors)
            {
                AuthorDataLayer.ShallowUpsert(dbAuthor);
            }
        }
    }
}