using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simr.IDataLayer
{
    public interface IDataLayer<T>
    {
        T Get(Guid id);

        T[] Filter();
    }
}
