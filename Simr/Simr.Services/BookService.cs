using System;
using System.Collections.Generic;
using System.Linq;

using SandS.Algorithm.Library.GeneratorNamespace;

using Sibr.Entities;

using Simr.IServices;

using Sirb.Common;
using Sirb.Common.Enums;

namespace Simr.Services
{
    public class BookService : IBookService
    {
        private static TextGenerator textGenerator = new TextGenerator();

        public Book Get(Guid id)
        {
            return new Book("Bible", 1025, BookStatus.Existing);
        }

        public Book[] Filter()
        {
            IList<Book> books = new List<Book>();

            for (int i = 0; i < 32; i++)
            {
                var book = new Book(textGenerator.GetNewWord(3, 12, true), Config.Random.Next(), BookStatus.Existing);
                books.Add(book);
            }

            return books.ToArray();
        }
    }
}