using IfrsDocs.Domain;
using Microsoft.EntityFrameworkCore;


namespace IfrsDocs.Repository
{
    public class DocumentOptionRepository : BaseRepository<DocumentOption>, IDocumentOptionRepository
    {
        private readonly IfrsDocsDbContext _ifrsDocsContext;
        public DocumentOptionRepository(IfrsDocsDbContext ifrsDocsContext) : base(ifrsDocsContext)
        {
            _ifrsDocsContext = ifrsDocsContext;
            _ifrsDocsContext.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }
    }
}
