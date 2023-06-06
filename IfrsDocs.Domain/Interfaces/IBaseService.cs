using System.Collections.Generic;
using System.Threading.Tasks;

namespace IfrsDocs.Domain
{
    public interface IBaseService<TEntity, R>
        where TEntity : class
        where R : IBaseRepository<TEntity>
    {
        void Add(TEntity entity);

        void Update(TEntity entity);

        void Delete(TEntity entity);

        void DeleteRange(TEntity[] entity);

        Task<bool> SaveChangesAsync();

        Task<List<TEntity>> GetAllAsync();
    }
}
