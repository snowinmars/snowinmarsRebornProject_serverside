using System;

namespace Simr.IDataLayer
{
    public interface IDataLayer<T>
    {
        T Get(Guid id);

        void Add(T item);

        void Delete(Guid id);

        void ShallowUpdate(T item);

        void ShallowUpsert(T item);

        T[] Filter();
    }
}