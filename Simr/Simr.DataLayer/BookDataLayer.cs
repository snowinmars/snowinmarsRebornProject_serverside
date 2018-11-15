using System;

using Simr.Entities;
using Simr.IDataLayer;

namespace Simr.DataLayer
{
    public class BookDataLayer : IBookDataLayer
    {
        public Book Get(Guid id)
        {
            throw new NotImplementedException();
        }

        public Book[] Filter()
        {
            throw new NotImplementedException();
        }
    }
}