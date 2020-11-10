using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AppManager.Domain.Interfaces;
using AppManager.Infrastructure.Data.Context;

namespace AppManager.Infrastructure.Data.Repositories
{
  public class RepositoryBase<T> : IDisposable, IRepositoryBase<T> where T : class
  {
    protected DataContext Db = new DataContext();
    protected DbSet<T> DbSet { get; set; }

    public RepositoryBase()
    {
      DbSet = Db.Set<T>();
    }

    public async Task Add(T entity)
    {
      await DbSet.AddAsync(entity);
      await Db.SaveChangesAsync();
    }

    public async Task Delete(int id)
    {
      DbSet.Remove(await Find(id));
      await Db.SaveChangesAsync();
    }

    public void Dispose()
    {
      Db.Dispose();
    }

    public async Task<T> Find(int id)
    {
      return await DbSet.FindAsync(id);
    }

    public async Task<IEnumerable<T>> FindAll()
    {
      return await DbSet.ToListAsync();
    }

    public async Task Update(T entity)
    {
      Db.Entry(entity).State = EntityState.Modified;
      await Db.SaveChangesAsync();
    }
  }
}
