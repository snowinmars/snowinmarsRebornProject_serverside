using System;
using System.Linq;

using Simr.Common;
using Simr.Entities;
using Simr.IDataLayer;

namespace Simr.DataLayer
{
    public class BookDataLayer : IBookDataLayer
    {
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

        public Book[] Filter()
        {
            throw new NotImplementedException();
        }
    }
}