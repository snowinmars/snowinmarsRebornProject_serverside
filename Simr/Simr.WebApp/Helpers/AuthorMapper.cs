namespace Simr.WebApp.Helpers
{
    using System.Collections.Generic;
    using System.Linq;

    using Sibr.Entities;

    using Simr.WebApp.Models.Author.Read;

    internal static class AuthorMapper
    {
        public static IEnumerable<AuthorGridModel> ToAuthorGridModels(this Author[] authors)
        {
            return authors.Select(AuthorMapper.ToAuthorGridModel);
        }

        public static IEnumerable<Author> ToAuthors(this AuthorGridModel[] authorGridModels)
        {
            return authorGridModels.Select(AuthorMapper.ToAuthor);
        }

        public static AuthorGridModel ToAuthorGridModel(this Author author)
        {
            return new AuthorGridModel
                       {
                           Name = author.Name.ToPersonNameModel(),
                           Pseudonym = author.Pseudonym.ToPersonNameModel(),
                           Id = author.Id,
                           Aka = author.Aka,
                           Info = author.Info,
                           PhotoUrl = author.PhotoUrl,
                           BirthDate = author.BirthDate,
                           DeathDate = author.DeathDate,
            };
        }

        public static Author ToAuthor(this AuthorGridModel authorGridModel)
        {
            return new Author(authorGridModel.Aka)
                       {
                           Name = authorGridModel.Name.ToPersonName(),
                           Pseudonym = authorGridModel.Pseudonym.ToPersonName(),
                           Id = authorGridModel.Id,
                           Info = authorGridModel.Info,
                           PhotoUrl = authorGridModel.PhotoUrl,
                           BirthDate = authorGridModel.BirthDate,
                           DeathDate = authorGridModel.DeathDate,
            };
        }
    }
}