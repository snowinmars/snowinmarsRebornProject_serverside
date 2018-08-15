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
                               BookStatus.Existing)
                {
                    AdditionalInfo = string.Join(" ", textGenerator.GetWords(100)),
                    Bookshelf = $"Grey bookshelf #{Config.Random.Next(1, 200)}",
                    FlibustaUrl = "http://ya.ru",
                    LibRusEcUrl = "http://ya.ru",
                    LiveLibUrl = "http://ya.ru",
                    IsSynchronized = true,
                    Owner = "snowinmars",
                    Year = Config.Random.Next(1860, 2018),
                    ImageUrl = "https://pp.userapi.com/c845417/v845417378/c9115/xmJRnAHnsfo.jpg",
                };

                SetAuthors(book, 1, 12);

                books.Add(book);
            }

            return books.ToArray();
        }

        private static void SetAuthors(Book book, int min, int max)
        {
            for (var j = 0; j < Config.Random.Next(min, max); j++)
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
        }

        public Book Get(Guid id)
        {
            var book = new Book("Bible", 1025, BookStatus.Existing)
            {
                AdditionalInfo = string.Join(" ", textGenerator.GetWords(100)),
                Bookshelf = "Grey bookshelf #2",
                FlibustaUrl = "http://ya.ru",
                LibRusEcUrl = "http://ya.ru",
                LiveLibUrl  = "http://ya.ru",
                IsSynchronized = true,
                Owner = "snowinmars",
                Year = 1894,
                Id = id,
                ImageUrl = "https://pp.userapi.com/c845417/v845417378/c9115/xmJRnAHnsfo.jpg",
            };

            SetAuthors(book, 1, 12);

            return book;
        }
    }
}