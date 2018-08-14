namespace Simr.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using SandS.Algorithm.Library.GeneratorNamespace;

    using Sibr.Entities;

    using Simr.IServices;

    using Sirb.Common;
    using Sirb.Common.Enums;

    public class BookService : IBookService
    {
        private static readonly TextGenerator textGenerator = new TextGenerator();

        public Book[] Filter()
        {
            IList<Book> books = new List<Book>();

            for (var i = 0; i < 256; i++)
            {
                var book = new Book(
                               BookService.textGenerator.GetNewWord(3, 12, true),
                               Config.Random.Next(),
                               BookStatus.Existing) {
                                                       Year = Config.Random.Next(1860, 2018) 
                                                    };

                for (var j = 0; j < Config.Random.Next(1, 4); j++)
                {
                    var author =
                        new Author(BookService.textGenerator.GetNewWord(4, 8, true))
                            {
                                GivenName =
                                    BookService.textGenerator
                                        .GetNewWord(
                                            4,
                                            8,
                                            true),
                                FullMiddleName =
                                    BookService.textGenerator
                                        .GetNewWord(
                                            4,
                                            8,
                                            true),
                                FamilyName =
                                    BookService.textGenerator
                                        .GetNewWord(4, 8, true)
                            };

                    book.Authors.Add(author);
                }

                books.Add(book);
            }

            return books.ToArray();
        }

        public Book Get(Guid id)
        {
            return new Book("Bible", 1025, BookStatus.Existing);
        }
    }
}