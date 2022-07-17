using System.Collections.Generic;
using System.Threading.Tasks;

namespace IfrsDocs.Domain
{
    public class BaseService<TEntity, R> : IBaseService<TEntity> where TEntity : class where R : IBaseRepository<TEntity>
    {
        protected readonly R _repository;

        public BaseService(R repository)
        {
            _repository = repository;
        }

        public void Add(TEntity entity)
        {
            _repository.Add<TEntity>(entity);
        }

        public void Delete(TEntity entity)
        {
            _repository.Delete<TEntity>(entity);
        }

        public void DeleteRange(TEntity[] entity)
        {
            _repository.DeleteRange<TEntity>(entity);
        }

        public async Task<List<TEntity>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public Task<bool> SaveChangesAsync()
        {
            return _repository.SaveChangesAsync();
        }

        public void Update(TEntity entity)
        {
            _repository.Update<TEntity>(entity);
        }
    }
}
