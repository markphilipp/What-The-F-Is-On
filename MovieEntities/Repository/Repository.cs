using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace MovieEntities.Repository
{
    public class Repository<T> : IDisposable, IRepository where T : class
    {
        private readonly MovieContext _movieContext;

        public Repository(MovieContext movieContext)
        {
            _movieContext = movieContext;
        }

        public IEnumerable<T> Set()
        {
            return _movieContext.Set<T>();
        }

        public T Find(params object[] keys)
        {
            return _movieContext.Find<T>(keys);
        }

        public Task<T> FindAsync(params object[] keys)
        {
            return _movieContext.FindAsync<T>(keys);
        }

        public EntityEntry<T> Add(T entity)
        {
            return _movieContext.Add(entity);
        }

        public Task<EntityEntry<T>> AddAsync(T entity)
        {
            return _movieContext.AddAsync(entity);
        }

        public void AddRange(IEnumerable<T> entities)
        {
            _movieContext.AddRange(entities);
        }

        public Task AddRangeAsync(IEnumerable<T> entities)
        {
            return _movieContext.AddRangeAsync(entities);
        }

        public void UpdateRange(IEnumerable<T> entities)
        {
            _movieContext.UpdateRange(entities);
        }

        public void Remove(T entity)
        {
            _movieContext.Remove(entity);
        }

        public void RemoveRange(IEnumerable<T> entities)
        {
            _movieContext.RemoveRange(entities);
        }

        public void Save()
        {
            _movieContext.SaveChanges();
        }

        public void SaveAsync()
        {
            _movieContext.SaveChangesAsync();
        }

        public DbQuery<T> Query()
        {
            return _movieContext.Query<T>();
        }

        public void Dispose()
        {

        }
    }
}