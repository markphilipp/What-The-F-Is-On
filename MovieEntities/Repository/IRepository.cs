using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace MovieEntities.Repository
{
    public interface IRepository
    {
        IEnumerable<T> Set<T>()
            where T : class;

        T Find<T>(params object[] keys)
            where T : class;

        Task<T> FindAsync<T>(params object[] keys)
            where T : class;

        EntityEntry<T> Add<T>(T entity)
            where T : class;

        Task<EntityEntry<T>> AddAsync<T>(T entity)
            where T : class;

        void AddRange<T>(IEnumerable<T> entities)
            where T : class;

        Task AddRangeAsync<T>(IEnumerable<T> entities)
            where T : class;

        void UpdateRange<T>(IEnumerable<T> entities)
            where T : class;

        void Remove<T>(T entity)
            where T : class;

        void RemoveRange<T>(IEnumerable<T> entities)
            where T : class;

        void Save();

        void SaveAsync();

        DbQuery<T> Query<T>()
            where T : class;
    }
}
