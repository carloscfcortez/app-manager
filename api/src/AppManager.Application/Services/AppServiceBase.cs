using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AppManager.Application.Interfaces;
using AppManager.Domain.Interfaces.Services;

namespace AppManager.Application.Services
{
  public class AppServiceBase<T> : IDisposable, IAppServiceBase<T> where T : class
  {
    private readonly IServiceBase<T> _service;

    public AppServiceBase(IServiceBase<T> service)
    {
      _service = service;
    }

    public async Task Add(T entity)
    {
      await _service.Add(entity);
    }

    public async Task Delete(int id)
    {
      await _service.Delete(id);
    }

    public void Dispose()
    {
      _service.Dispose();
    }

    public async Task<T> Find(int id)
    {
      return await _service.Find(id);
    }

    public async Task<IEnumerable<T>> FindAll()
    {
      return await _service.FindAll();
    }

    public async Task Update(T entity)
    {
      await _service.Update(entity);
    }
  }
}
