using System;

namespace Plutus.Repository.Base
{
    public interface IRepository<T, TId> : IDisposable where T : class
    {
        T GetById(TId id);
        void Insert(T data);
        void Update(T data);
        void Delete(T data);
        void Save();
    }
}
