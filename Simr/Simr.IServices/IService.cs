using System;

namespace Simr.IServices
{
    public interface IService<T>
    {
        T Get(Guid id);

        void Update(T item);

        void Add(T item);

        void Upsert(T item);

        void Delete(Guid id);

        T[] Filter();
    }
}