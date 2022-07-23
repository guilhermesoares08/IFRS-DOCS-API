using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using IfrsDocs.Domain;
using System;
using Microsoft.EntityFrameworkCore.Metadata;
using System.Linq.Expressions;
using System.Linq;

namespace IfrsDocs.Repository
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class
    {
        private readonly IfrsDocsDbContext _ifrsDocsContext;

        public BaseRepository(IfrsDocsDbContext IfrsDocsContext)
        {
            _ifrsDocsContext = IfrsDocsContext;
            _ifrsDocsContext.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }

        public void Add<T>(TEntity entity)
        {
            _ifrsDocsContext.Add(entity);
        }

        public void Delete<T>(TEntity entity)
        {
            _ifrsDocsContext.Remove(entity);
        }

        public void Update<T>(TEntity entity)
        {
            _ifrsDocsContext.Update(entity);
        }
        public async Task<bool> SaveChangesAsync()
        {
            // retorno maior que 0 adicionou no bd
            return (await _ifrsDocsContext.SaveChangesAsync()) > 0;
        }

        public void DeleteRange<T>(TEntity[] entityArray)
        {
            _ifrsDocsContext.RemoveRange(entityArray);
        }

        public async Task<List<TEntity>> GetAllAsync()
        {
            return await _ifrsDocsContext.Set<TEntity>().ToListAsync();
        }

        //public TEntity GetById<TEntity>(params Expression<Func<TEntity, bool>>[] keys) where TEntity : class
        //{
        //    if (keys == null)
        //        return default(TEntity);

        //    var table = _ifrsDocsContext.Set<TEntity>();
        //    IQueryable<TEntity> query = null;
        //    foreach (var item in keys)
        //    {
        //        if (query == null)
        //            query = table.Where(item);
        //        else
        //            query = query.Where(item);
        //    }
        //    return query.FirstOrDefault<TEntity>();
        //}
    }
}
