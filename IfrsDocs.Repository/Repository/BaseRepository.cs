using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using IfrsDocs.Domain;

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
    }
}
