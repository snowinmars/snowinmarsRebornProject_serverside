using System;
using System.Linq;

using Simr.Common;
using Simr.Entities;
using Simr.IDataLayer;

namespace Simr.DataLayer
{
    public class AuthorDataLayer : IAuthorDataLayer
    {
        public Author Get(Guid id)
        {
            using (var context = new EntityContext())
            {
                var dbAuthor = context.DbAuthors.FirstOrDefault(x => x.Id == id);

                if (dbAuthor == null)
                {
                    throw new NotFoundException($"Can't find author with id {id}");
                }

                return dbAuthor.ToAuthor();
            }
        }

        public Author[] Filter()
        {
            using (var context = new EntityContext())
            {
                var dbAuthors = context.DbAuthors.Fetch();

                return dbAuthors.Select(x => x.ToAuthor()).ToArray();
            }
        }
    }
}