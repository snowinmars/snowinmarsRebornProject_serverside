using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

using Simr.Common.Enums;

namespace Simr.DataLayer.DbEntities
{
    public class DbBook 
    {
        public DbBook()
        {
            Authors = new DbAuthor[0];
        }

        [Key]
        public Guid Id { get; set; }

        public bool IsSynchronized { get; set; }

        public BookStatus Status { get; set; }

        public string AdditionalInfo { get; set; }

        public DbAuthor[] Authors { get; set; }

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