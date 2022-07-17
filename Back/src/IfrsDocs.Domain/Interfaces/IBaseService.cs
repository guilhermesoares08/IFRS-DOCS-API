using System.Collections.Generic;
using System.Threading.Tasks;

namespace IfrsDocs.Domain
{
    public interface IBaseService<TEntity> where TEntity : class
    {
        void Add(TEntity entity);

        void Update(TEntity entity);

        void Delete(TEntity entity);

        void DeleteRange(TEntity[] entity);

        Task<bool> SaveChangesAsync();

        Task<List<TEntity>> GetAllAsync();
    }
}
