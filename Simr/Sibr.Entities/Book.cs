using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sibr.Entities
{
    using Sirb.Common.Enums;

    public class Book : Entity
    {
        public Book(string title, int pageCount, BookStatus bookStatus)
        {
            this.Title = title;
            this.PageCount = pageCount;
            this.Status = bookStatus;

            this.Authors = new List<Author>();
        }

        public BookStatus Status { get; set; }
        public string AdditionalInfo { get; set; }
        public List<Author> Authors { get; }
        public string Bookshelf { get; set; }
        public string FlibustaUrl { get; set; }
        public string LibRusEcUrl { get; set; }
        public string LiveLibUrl { get; set; }
        public string Owner { get; set; }
        public int PageCount { get; set; }
        public string Title { get; set; }
        public int Year { get; set; }
        public string ImageUrl { get; set; }
    }
}
