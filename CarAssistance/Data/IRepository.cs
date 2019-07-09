using System;

namespace CarAssistance.Data
{
    interface IRepository<T> : IDisposable
    {
        T Get(int id);
        void Create(T item);
        void Delete(T item);
        void DeleteRange(T[] items);
        void Update(T item);

    }
}
