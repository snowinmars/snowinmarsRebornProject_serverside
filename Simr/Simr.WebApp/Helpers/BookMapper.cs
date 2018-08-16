namespace Simr.WebApp.Helpers
{
    using System.Collections.Generic;
    using System.Linq;

    using Sibr.Entities;

    using Simr.WebApp.Models.Book.Read;

    internal static class BookMapper
    {
        public static IEnumerable<Book> ToBooks(this BookGridModel[] bookGridModels)
        {
            return bookGridModels.Select(BookMapper.ToBook);
        }

        public static IEnumerable<BookGridModel> ToBookGridModels(this Book[] books)
        {
            return books.Select(BookMapper.ToBookGridModel);
        }

        public static Book ToBook(this BookGridModel bookGridModel)
        {
            var book = new Book(bookGridModel.Title, bookGridModel.PageCount, bookGridModel.Status)
                           {
                               AdditionalInfo =
                                   bookGridModel
                                       .AdditionalInfo,
                               Bookshelf =
                                   bookGridModel
                                       .Bookshelf,
                               FlibustaUrl =
                                   bookGridModel
                                       .FlibustaUrl,
                               LibRusEcUrl =
                                   bookGridModel
                                       .LibRusEcUrl,
                               LiveLibUrl =
                                   bookGridModel
                                       .LiveLibUrl,
                               Owner =
                                   bookGridModel
                                       .Owner,
                               Year =
                                   bookGridModel
                                       .Year,
                               ImageUrl =
                                   bookGridModel
                                       .ImageUrl,
                               Id =
                                   bookGridModel
                                       .Id,
                           };

            foreach (var author in bookGridModel.Authors)
            {
                book.Authors.Add(author.ToAuthor());
            }

            return book;
        }

        public static BookGridModel ToBookGridModel(this Book book)
        {
            var resultBook = new BookGridModel
                                 {
                                     PageCount = book.PageCount,
                                     Title = book.Title,
                                     Status = book.Status,
                                     AdditionalInfo = book.AdditionalInfo,
                                     Bookshelf = book.Bookshelf,
                                     FlibustaUrl = book.FlibustaUrl,
                                     LibRusEcUrl = book.LibRusEcUrl,
                                     LiveLibUrl = book.LiveLibUrl,
                                     Owner = book.Owner,
                                     Year = book.Year,
                                     ImageUrl = book.ImageUrl,
                                     Id = book.Id,
                                 };

            foreach (var author in book.Authors)
            {
                resultBook.Authors.Add(author.ToAuthorGridModel());
            }

            return resultBook;
        }
    }
}