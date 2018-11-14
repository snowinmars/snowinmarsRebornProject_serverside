using System;

namespace Simr.IDataLayer
{
    public interface IDataLayer<T>
    {
        T Get(Guid id);

        T[] Filter();
    }
}