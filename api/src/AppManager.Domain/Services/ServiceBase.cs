using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AppManager.Domain.Interfaces;
using AppManager.Domain.Interfaces.Services;

namespace AppManager.Domain.Services
{
  public class ServiceBase<T> : IDisposable, IServiceBase<T> where T : class
  {
    private readonly IRepositoryBase<T> _repository;

    public ServiceBase(IRepositoryBase<T> repository)
    {
      _repository = repository;
    }

    public async Task Add(T entity)
    {
      await _repository.Add(entity);
    }

    public async Task Delete(int id)
    {
      await _repository.Delete(id);
    }

    public void Dispose()
    {
      _repository.Dispose();
    }

    public async Task<T> Find(int id)
    {
      return await _repository.Find(id);
    }

    public async Task<IEnumerable<T>> FindAll()
    {
      return await _repository.FindAll();
    }

    public async Task Update(T entity)
    {
      await _repository.Update(entity);
    }
  }
}
