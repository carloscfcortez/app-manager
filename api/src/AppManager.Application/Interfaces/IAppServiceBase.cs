using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AppManager.Application.Interfaces
{
  public interface IAppServiceBase<T> where T : class
  {
    Task Add(T entity);

    Task<T> Find(int id);

    Task<IEnumerable<T>> FindAll();

    Task Update(T entity);

    Task Delete(int id);

    void Dispose();
  }
}
