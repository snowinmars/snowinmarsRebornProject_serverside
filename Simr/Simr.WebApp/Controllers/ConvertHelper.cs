using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Simr.WebApp.Controllers
{
    using Sibr.Entities;

    using Simr.WebApp.Models.Author;
    using Simr.WebApp.Models.Book;
    using Simr.WebApp.Models.Pseudonym;
    using Simr.WebApp.Models.User;

    internal static class ConvertHelper
    {
        public static TOut[] ConvertArray<TIn, TOut>(this TIn[] input, Func<TIn, TOut> action)
        {
            return input.Select(action).ToArray();
        }

        public static User ToUser(this UserBase_ReadModel model)
        {
            return new User(model.Username)
                       {
                           Email = model.Email,
                           Language = model.Language,
                           Roles = model.Roles,
                           Username = model.Username,
                       };
        }
        public static UserBase_ReadModel ToUserBase_ReadModel(this User entity)
        {
            if (entity == null)
            {
                return null;
            }

            return new UserBase_ReadModel()
                       {
                           Email = entity.Email,
                           Language = entity.Language,
                           Roles = entity.Roles,
                           Username = entity.Username,
                       };
        }

        public static Author ToAuthor(this AuthorBase_ReadModel model)
        {
            if (model == null)
            {
                return null;
            }

            return new Author(model.Aka)
                       {
                           GivenName = model.GivenName,
                           FullMiddleName = model.FullMiddleName,
                           FamilyName = model.FamilyName,
                           Pseudonym = ToPseudonym(model.Pseudonym),
            };
        }

        public static AuthorBase_ReadModel ToAuthorBase_ReadModel(this Author entity)
        {
             if (entity == null)
            {
                return null;
            }

            return new AuthorBase_ReadModel()
                       {
                           Aka = entity.Aka,
                           GivenName = $"{entity.GivenName[0]}.",
                           FullMiddleName = $"{entity.FullMiddleName[0]}.",
                           FamilyName = entity.FamilyName,
                           Pseudonym = ToPseudonymBase_ReadModel(entity.Pseudonym),
                       };
        }

        public static Pseudonym ToPseudonym(this PseudonymBase_ReadModel model)
        {
             if (model == null)
            {
                return null;
            }

            return new Pseudonym
                       {
                           GivenName = model.GivenName,
                           FullMiddleName = model.FullMiddleName,
                           FamilyName = model.FamilyName,
                       };
        }

        public static PseudonymBase_ReadModel ToPseudonymBase_ReadModel(this Pseudonym entity)
        {
            if (entity == null)
            {
                return null;
            }

            return new PseudonymBase_ReadModel
            {
                GivenName = $"{(string.IsNullOrWhiteSpace(entity.GivenName) ? string.Empty : entity.GivenName[0].ToString())}.",
                FullMiddleName = $"{(string.IsNullOrWhiteSpace(entity.FullMiddleName) ? string.Empty : entity.FullMiddleName[0].ToString())}.",
                FamilyName = entity.FamilyName,
            };
        }

        public static Book ToBook(this BookBase_ReadModel model)
        {
            if (model == null)
            {
                return null;
            }

            var book = new Book(model.Title, model.PageCount, model.Status)
                           {
                               AdditionalInfo = model.AdditionalInfo,
                               Bookshelf = model.Bookshelf,
                               FlibustaUrl = model.FlibustaUrl,
                               LibRusEcUrl = model.LibRusEcUrl,
                               LiveLibUrl = model.LiveLibUrl,
                               Owner = model.Owner,
                               Year = model.Year,
                               ImageUrl = model.ImageUrl,
                               Id = model.Id,
            };

            foreach (var author in model.Authors)
            {
                book.Authors.Add(author.ToAuthor());
            }

            return book;
        }

        public static BookBase_ReadModel ToBookBase_ReadModel(this Book entity)
        {
            if (entity == null)
            {
                return null;
            }

            var model = new BookBase_ReadModel()
                                        {
                                            AdditionalInfo = entity.AdditionalInfo,
                                            Bookshelf = entity.Bookshelf,
                                            FlibustaUrl = entity.FlibustaUrl,
                                            LibRusEcUrl = entity.LibRusEcUrl,
                                            LiveLibUrl = entity.LiveLibUrl,
                                            Owner = entity.Owner,
                                            Year = entity.Year,
                                            PageCount = entity.PageCount,
                                            Title = entity.Title,
                                            Status = entity.Status,
                                            Id = entity.Id,
                                            ImageUrl = entity.ImageUrl,
            };

            foreach (var author in entity.Authors)
            {
                model.Authors.Add(author.ToAuthorBase_ReadModel());
            }

            return model;
        }
    }
}