using System;

namespace Simr.IServices
{
    public interface IService<T>
    {
        T Get(Guid id);

        T[] Filter();
    }
}