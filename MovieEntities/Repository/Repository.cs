using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace MovieEntities.Repository
{
    public class Repository : IDisposable, IRepository
    {
        private readonly MovieContext _movieContext;

        public Repository(MovieContext movieContext)
        {
            _movieContext = movieContext;
        }

        public IEnumerable<T> Set<T>()
            where T : class
        {
            return _movieContext.Set<T>();
        }

        public T Find<T>(params object[] keys)
            where T : class
        {
            return _movieContext.Find<T>(keys);
        }

        public Task<T> FindAsync<T>(params object[] keys)
            where T : class
        {
            return _movieContext.FindAsync<T>(keys);
        }

        public EntityEntry<T> Add<T>(T entity)
            where T : class
        {
            return _movieContext.Add(entity);
        }

        public Task<EntityEntry<T>> AddAsync<T>(T entity)
            where T : class
        {
            return _movieContext.AddAsync(entity);
        }

        public void AddRange<T>(IEnumerable<T> entities)
            where T : class
        {
            _movieContext.AddRange(entities);
        }

        public Task AddRangeAsync<T>(IEnumerable<T> entities)
            where T : class
        {
            return _movieContext.AddRangeAsync(entities);
        }

        public void UpdateRange<T>(IEnumerable<T> entities)
            where T : class
        {
            _movieContext.UpdateRange(entities);
        }

        public void Remove<T>(T entity)
            where T : class
        {
            _movieContext.Remove(entity);
        }

        public void RemoveRange<T>(IEnumerable<T> entities)
            where T : class
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

        public DbQuery<T> Query<T>()
            where T : class
        {
            return _movieContext.Query<T>();
        }

        public void Dispose()
        {

        }
    }
}