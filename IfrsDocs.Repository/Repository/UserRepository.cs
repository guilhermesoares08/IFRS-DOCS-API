using IfrsDocs.Domain;
using Microsoft.EntityFrameworkCore;


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
    }
}
