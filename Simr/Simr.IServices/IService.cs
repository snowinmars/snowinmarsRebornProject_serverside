using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simr.IServices
{
    public interface IService<T>
    {
        T Get(Guid id);

        T[] Filter();
    }
}
