namespace Simr.IServices
{
    using System;

    public interface IService<T>
    {
        T Get(Guid id);

        T[] Filter();
    }
}