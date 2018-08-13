using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simr.Services
{
    using Sibr.Entities;

    using Simr.IServices;

    using Sirb.Common.Enums;

    public class BookService : IBookService
    {
        public Book Get(Guid id)
        {
            return new Book("Bible", 1025, BookStatus.Existing);
        }

        public Book[] Filter()
        {
            return new[]
                       {
                           new Book("Bible", 1025, BookStatus.Existing), new Book("Bible", 1025, BookStatus.Existing),
                           new Book("Bible", 1025, BookStatus.Existing), new Book("Bible", 1025, BookStatus.Existing),
                           new Book("Bible", 1025, BookStatus.Existing), new Book("Bible", 1025, BookStatus.Existing),
                           new Book("Bible", 1025, BookStatus.Existing), new Book("Bible", 1025, BookStatus.Existing),
                           new Book("Bible", 1025, BookStatus.Existing), new Book("Bible", 1025, BookStatus.Existing),
                           new Book("Bible", 1025, BookStatus.Existing), new Book("Bible", 1025, BookStatus.Existing),
                           new Book("Bible", 1025, BookStatus.Existing), new Book("Bible", 1025, BookStatus.Existing),
                           new Book("Bible", 1025, BookStatus.Existing), new Book("Bible", 1025, BookStatus.Existing),
                       };
        }
    }
}
