using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public static SiberiaBranch ToSiberiaBranch(this DbSiberiaBranch dbSiberiaBranch)
        {
            return new SiberiaBranch
            {
                Id = dbSiberiaBranch.Id,
                Enviroment = dbSiberiaBranch.Enviroment,
                Name = dbSiberiaBranch.Name,
            };
        }
    }
}
