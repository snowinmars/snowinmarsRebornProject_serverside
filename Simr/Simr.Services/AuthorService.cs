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
            return GetNewAuthor();
        }

        public Author[] Filter()
        {
            return new[]
                       {
                           GetNewAuthor(),GetNewAuthor(),GetNewAuthor(),
                           GetNewAuthor(),GetNewAuthor(),GetNewAuthor(),
                           GetNewAuthor(),GetNewAuthor(),GetNewAuthor(),
                       };
        }

        private static Author GetNewAuthor()
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
                Info = string.Join(" ", textGenerator.GetWords(500)),
                PhotoUrl = "http://i41-cdn.woman.ru/womanru/images/gallery/c/7/g_c7abcd1cb65d89122ff8dde384995885_8_800x600.jpg?02",
                BirthDate = DateTime.Now.AddYears(-40),
                DeathDate = DateTime.Now.AddYears(-10),
                Id = Guid.NewGuid(),
            };
        }
    }
}