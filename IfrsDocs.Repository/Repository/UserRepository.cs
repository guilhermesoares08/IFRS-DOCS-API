using IfrsDocs.Domain;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace IfrsDocs.Repository
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        private readonly IfrsDocsDbContext _ifrsDocsContext;
        public UserRepository(IfrsDocsDbContext ifrsDocsContext) : base(ifrsDocsContext)
        {
            _ifrsDocsContext = ifrsDocsContext;
            _ifrsDocsContext.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }

        public User GetUserById(int id)
        {
            IQueryable<User> query = _ifrsDocsContext.User;
            query = query.Include(q => q.Role);
            query = query.AsNoTracking().Where(c => c.Id == id);
            return query.FirstOrDefault();
        }
    }
}
