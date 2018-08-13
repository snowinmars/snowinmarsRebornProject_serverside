using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simr.Services
{
    using Sibr.Entities;

    using Simr.IServices;
    public class AuthorService : IAuthorService
    {
        public Author Get(Guid id)
        {
            return new Author("Gomer");
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
