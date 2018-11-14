using System;

using Sibr.Entities;

using Simr.IDataLayer;
using Simr.IServices;

namespace Simr.Services
{
    public class BookService : IBookService
    {
        public BookService(IBookDataLayer dataLayer)
        {
            DataLayer = dataLayer;
        }

        private IBookDataLayer DataLayer { get; }

        public Book[] Filter()
        {
            return DataLayer.Filter();
        }

        public Book Get(Guid id)
        {
            return DataLayer.Get(id);
        }
    }
}