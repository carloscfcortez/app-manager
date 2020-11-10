using System.Collections.Generic;

namespace Domain.Core.Interfaces.Services
{
    public interface IBaseService<T> where T : class
    {
        void Add(T entity);
        T FindById(int id);
        IEnumerable<T> FindAll();
        void Update(T entity);
        void Remove(T entity);
        void Dispose();

    }
}