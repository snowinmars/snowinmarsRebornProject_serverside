using System;

using Sibr.Entities;

using Simr.IDataLayer;
using Simr.IServices;

namespace Simr.Services
{
    public class AuthorService : IAuthorService
    {
        public AuthorService(IAuthorDataLayer dataLayer)
        {
            DataLayer = dataLayer;
        }

        private IAuthorDataLayer DataLayer { get; }

        public Author Get(Guid id)
        {
            return DataLayer.Get(id);
        }

        public Author[] Filter()
        {
            return DataLayer.Filter();
        }
    }
}