using IfrsDocs.Domain;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

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

        public IList<DocumentOption> GetDocumentOptionByDocumentType(int documentTypeId)
        {
            IQueryable<DocumentOption> query = _ifrsDocsContext.DocumentOption;
            query = query
                .AsNoTracking()
                .Where(f => (int)f.DocumentType == documentTypeId);

            return query.ToList();
        }    
    }
}
