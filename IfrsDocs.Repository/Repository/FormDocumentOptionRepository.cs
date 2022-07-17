using IfrsDocs.Domain;
using Microsoft.EntityFrameworkCore;


namespace IfrsDocs.Repository
{
    public class FormDocumentOptionRepository : BaseRepository<FormDocumentOption>, IFormDocumentOptionRepository
    {
        private readonly IfrsDocsDbContext _ifrsDocsContext;
        public FormDocumentOptionRepository(IfrsDocsDbContext ifrsDocsContext) : base(ifrsDocsContext)
        {
            _ifrsDocsContext = ifrsDocsContext;
            _ifrsDocsContext.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }
    }
}
