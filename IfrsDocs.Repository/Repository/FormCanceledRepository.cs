using IfrsDocs.Domain;
using Microsoft.EntityFrameworkCore;


namespace IfrsDocs.Repository
{
    public class FormCanceledRepository : BaseRepository<FormCanceled>, IFormCanceledRepository
    {
        private readonly IfrsDocsDbContext _ifrsDocsContext;
        public FormCanceledRepository(IfrsDocsDbContext ifrsDocsContext) : base(ifrsDocsContext)
        {
            _ifrsDocsContext = ifrsDocsContext;
            _ifrsDocsContext.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }
    }
}
