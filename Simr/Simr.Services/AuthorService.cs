    using System;

using Simr.Entities;
using Simr.IDataLayer;
    using Simr.IServices;

namespace Simr.Services
{
    public class AuthorService : IAuthorService
    {
        public AuthorService(IAuthorDataLayer authorDataLayer)
        {
            AuthorDataLayer = authorDataLayer;
        }

        private IAuthorDataLayer AuthorDataLayer { get; }

        public Author Get(Guid id)
        {
            return AuthorDataLayer.Get(id);
        }

        public void Update(Author item)
        {
            if (item.Id == default)
            {
                throw new ArgumentException("It's impossible to update item without id");
            }

            AuthorDataLayer.ShallowUpdate(item);
        }

        public void Add(Author item)
        {
            item.Id = default;

            AuthorDataLayer.Add(item);
        }

        public void Upsert(Author item)
        {
            AuthorDataLayer.ShallowUpsert(item);
        }

        public void Delete(Guid id)
        {
            AuthorDataLayer.Delete(id);
        }

        public Author[] Filter()
        {
            return AuthorDataLayer.Filter();
        }
    }
}