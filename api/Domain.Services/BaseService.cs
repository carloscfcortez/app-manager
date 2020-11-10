
using System;
using Domain.Core;
using Domain.Core.Interfaces.Repositories;
using Domain.Core.Interfaces.Services;

namespace Domain.Services
{
    public class BaseService<T> : IDisposable, IBaseService<T> where T : class
    {
        private readonly IBaseRepository<T> _repository;

        public BaseService(IBaseRepository<T> repository)
        {
            _repository = repository;
        }

        public void Add(T entity)
        {
            _repository.Add(entity);
        }

        public void Dispose()
        {
            _repository.Dispose();
        }

        public System.Collections.Generic.IEnumerable<T> FindAll()
        {
            return _repository.FindAll();
        }

        public T FindById(int id)
        {
            return _repository.FindById(id);
        }

        public void Remove(T entity)
        {
            _repository.Remove(entity);
        }

        public void Update(T entity)
        {
            _repository.Update(entity);
        }
    }
}