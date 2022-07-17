using IfrsDocs.Domain;
using IfrsDocs.Repository;
using Microsoft.EntityFrameworkCore;


namespace ifrsDocs.Repository
{
    public class CourseRepository : BaseRepository<Course>, ICourseRepository
    {
        private readonly IfrsDocsDbContext _ifrsDocsContext;
        public CourseRepository(IfrsDocsDbContext ifrsDocsContext) : base(ifrsDocsContext)
        {
            _ifrsDocsContext = ifrsDocsContext;
            _ifrsDocsContext.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }
    }
}
