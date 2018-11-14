using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Sibr.Entities;

using Simr.IDataLayer;

namespace Simr.DataLayer
{
    public class AuthorDataLayer : IAuthorDataLayer
    {
        public Author Get(Guid id)
        {
            throw new NotImplementedException();
        }

        public Author[] Filter()
        {
            throw new NotImplementedException();
        }
    }
}
