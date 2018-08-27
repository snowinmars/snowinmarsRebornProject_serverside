using SandS.Algorithm.Library.GeneratorNamespace;

namespace Simr.Services
{
    using System;

    using Sibr.Entities;

    using Simr.IServices;

    public class AuthorService : IAuthorService
    {
        private static readonly TextGenerator textGenerator = new TextGenerator();
        public Author Get(Guid id)
        {
            return new Author("Gomer")
            {
                Name = new PersonName
                {
                    FamilyName = textGenerator.GetNewWord(2, 17, true),
                    FullMiddleName = textGenerator.GetNewWord(2, 17, true),
                    GivenName = textGenerator.GetNewWord(2, 17, true),
                },
                Pseudonym = new PersonName
                {
                    FamilyName = textGenerator.GetNewWord(2, 17, true),
                    FullMiddleName = textGenerator.GetNewWord(2, 17, true),
                    GivenName = textGenerator.GetNewWord(2, 17, true),
                },
            };
        }

        public Author[] Filter()
        {
            return new[]
                       {
                           new Author("Gomer"), new Author("Gomer"), new Author("Gomer"), new Author("Gomer"),
                           new Author("Gomer"), new Author("Gomer"), new Author("Gomer"), new Author("Gomer"),
                           new Author("Gomer"), new Author("Gomer"), new Author("Gomer"), new Author("Gomer"),
                       };
        }
    }
}