using System.Collections.Generic;

namespace Application.Interfaces
{
   public interface IBaseApp<T> where T : class
    {
        void Add(T entity);
        T FindById(int id);
        IEnumerable<T> FindAll();
        void Update(T entity);
        void Remove(T entity);
        void Dispose();

    }
}