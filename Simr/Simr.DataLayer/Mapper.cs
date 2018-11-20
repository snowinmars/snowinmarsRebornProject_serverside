using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Simr.Common;
using Simr.DataLayer.DbEntities;
using Simr.Entities;

namespace Simr.DataLayer
{
    internal static class Mapper
    {
        public static User ToUser(this DbUser dbUser)
        {
            return new User(dbUser.Username)
            {
                Email = dbUser.Email,
                Id = dbUser.Id,
                IsSynchronized = dbUser.IsSynchronized,
                Language = dbUser.Language,
                Roles = dbUser.Roles,
            };
        }

        public static DbUser ToDbUser(this User user)
        {
            return new DbUser
            {
                Username = user.Username,
                Email = user.Email,
                Id = user.Id,
                IsSynchronized = user.IsSynchronized,
                Language = user.Language,
                Roles = user.Roles,
            };
        }

        public static Book ToBook(this DbBook dbBook)
        {
            var book = new Book(dbBook.Title, dbBook.PageCount, dbBook.Status)
            {
                AdditionalInfo = dbBook.AdditionalInfo,
                Bookshelf = dbBook.Bookshelf,
                FlibustaUrl = dbBook.FlibustaUrl,
                Id = dbBook.Id,
                ImageUrl = dbBook.ImageUrl,
                IsSynchronized = dbBook.IsSynchronized,
                LibRusEcUrl = dbBook.LibRusEcUrl,
                LiveLibUrl = dbBook.LiveLibUrl,
                Owner = dbBook.Owner,
                Year = dbBook.Year,
            };

            book.Authors.AddRange(dbBook.Authors.Select(x => x.ToAuthor()));

            return book;
        }

        public static DbBook ToDbBook(this Book book)
        {
            return new DbBook
            {
                Title = book.Title,
                PageCount = book.PageCount,
                Status = book.Status,
                AdditionalInfo = book.AdditionalInfo,
                Bookshelf = book.Bookshelf,
                FlibustaUrl = book.FlibustaUrl,
                Id = book.Id,
                ImageUrl = book.ImageUrl,
                IsSynchronized = book.IsSynchronized,
                LibRusEcUrl = book.LibRusEcUrl,
                LiveLibUrl = book.LiveLibUrl,
                Owner = book.Owner,
                Year = book.Year,
                Authors = book.Authors.SelectArray(x => x.ToDbAuthor()),
            };
        }

        public static Author ToAuthor(this DbAuthor dbAuthor)
        {
            return new Author(dbAuthor.Aka)
            {
                Id = dbAuthor.Id,
                IsSynchronized = dbAuthor.IsSynchronized,
                Name = new PersonName
                {
                    FamilyName = dbAuthor.FamilyName,
                    FullMiddleName = dbAuthor.FullMiddleName,
                    GivenName = dbAuthor.GivenName,
                },
                Pseudonym = new PersonName
                {
                    FamilyName = dbAuthor.PseudonymFamilyName,
                    FullMiddleName = dbAuthor.PseudonymFullMiddleName,
                    GivenName = dbAuthor.PseudonymGivenName,
                },
            };
        }

        public static DbAuthor ToDbAuthor(this Author author)
        {
            return new DbAuthor
            {
                Id = author.Id,
                Aka = author.Aka,
                IsSynchronized = author.IsSynchronized,
                    FamilyName = author.Name.FamilyName,
                    FullMiddleName = author.Name.FullMiddleName,
                    GivenName = author.Name.GivenName,

                PseudonymFamilyName = author.Pseudonym.FamilyName,
                PseudonymFullMiddleName = author.Pseudonym.FullMiddleName,
                PseudonymGivenName = author.Pseudonym.GivenName,
                
            };
        }

        public static SiberiaEnvironment ToSiberiaEnvironment(this DbSiberiaEnvironment dbSiberiaEnvironment)
        {
            return new SiberiaEnvironment
            {
                Id = dbSiberiaEnvironment.Id,
                Branch = dbSiberiaEnvironment.Branch,
                Environment = dbSiberiaEnvironment.Name,
            };
        }

        public static DbSiberiaEnvironment ToDbSiberiaEnvironment(this SiberiaEnvironment siberiaEnvironment)
        {
            return new DbSiberiaEnvironment
            {
                Id = siberiaEnvironment.Id,
                Branch = siberiaEnvironment.Branch,
                Name = siberiaEnvironment.Environment,
            };
        }
    }
}
