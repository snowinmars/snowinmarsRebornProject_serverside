using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Sibr.Entities;

using Simr.IDataLayer;

namespace Simr.DataLayer
{
    public class BookDataLayer : IBookDataLayer
    {
        public Book Get(Guid id)
        {
            throw new NotImplementedException();
        }

        public Book[] Filter()
        {
            throw new NotImplementedException();
        }
    }
}
