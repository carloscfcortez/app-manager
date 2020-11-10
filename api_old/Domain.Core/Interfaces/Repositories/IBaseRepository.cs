using System.Collections.Generic;

namespace Domain.Core.Interfaces.Repositories
{
    public interface IBaseRepository<T> where T : class
    {
        void Add(T entity);
        T FindById(int id);
        IEnumerable<T> FindAll();
        void Update(T entity);
        void Remove(T entity);
        void Dispose();

    }
}