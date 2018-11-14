using System.Collections.Generic;

using Sirb.Common.Enums;

namespace Sibr.Entities
{
    public class Book : Entity
    {
        public Book(string title, int pageCount, BookStatus bookStatus)
        {
            Title = title;
            PageCount = pageCount;
            Status = bookStatus;

            Authors = new List<Author>();
        }

        public BookStatus Status { get; }

        public string AdditionalInfo { get; set; }

        public List<Author> Authors { get; }

        public string Bookshelf { get; set; }

        public string FlibustaUrl { get; set; }

        public string LibRusEcUrl { get; set; }

        public string LiveLibUrl { get; set; }

        public string Owner { get; set; }

        public int PageCount { get; }

        public string Title { get; }

        public int Year { get; set; }

        public string ImageUrl { get; set; }
    }
}