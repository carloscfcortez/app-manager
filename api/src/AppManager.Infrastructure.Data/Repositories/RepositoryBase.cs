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
        private readonly DataContext _context;// = new DataContext();
        protected DbSet<T> DbSet { get; set; }

        public RepositoryBase(DataContext cotext)
        {
            _context = cotext;
            DbSet = cotext.Set<T>();
        }

        public async Task Add(T entity)
        {
            await DbSet.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            DbSet.Remove(await Find(id));
            await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
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
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}
