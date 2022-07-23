using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace IfrsDocs.Domain
{
    public interface IBaseRepository<TEntity> where TEntity : class
    {
        void Add<T>(TEntity entity);

        void Update<T>(TEntity entity);

        void Delete<T>(TEntity entity);

        void DeleteRange<T>(TEntity[] entity);

        Task<bool> SaveChangesAsync();

        Task<List<TEntity>> GetAllAsync();

        //TEntity GetById<TEntity>(params Expression<Func<TEntity, bool>>[] keys) where TEntity : class;
    }
}
