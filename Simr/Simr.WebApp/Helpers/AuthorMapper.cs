using System.Collections.Generic;
    using System.Linq;

using Simr.Entities;
    using Simr.WebApp.Models.Author.Read;

namespace Simr.WebApp.Helpers
{
    internal static class AuthorMapper
    {
        public static IEnumerable<AuthorGridModel> ToAuthorGridModels(this Author[] authors)
        {
            return authors.Select(ToAuthorGridModel);
        }

        public static IEnumerable<Author> ToAuthors(this AuthorGridModel[] authorGridModels)
        {
            return authorGridModels.Select(ToAuthor);
        }

        public static AuthorGridModel ToAuthorGridModel(this Author author)
        {
            return new AuthorGridModel
                       {
                           Name = author.Name.ToPersonNameModel(),
                           Pseudonym = author.Pseudonym.ToPersonNameModel(),
                           Id = author.Id,
                           Aka = author.Aka,
                       };
        }

        public static Author ToAuthor(this AuthorGridModel authorGridModel)
        {
            return new Author(authorGridModel.Aka)
                       {
                           Name = authorGridModel.Name.ToPersonName(),
                           Pseudonym = authorGridModel.Pseudonym.ToPersonName(),
                           Id = authorGridModel.Id,
                       };
        }
    }
}