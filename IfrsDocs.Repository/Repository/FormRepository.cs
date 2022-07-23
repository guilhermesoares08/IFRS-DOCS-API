using IfrsDocs.Domain;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IfrsDocs.Repository
{
    public class FormRepository : BaseRepository<Form>, IFormRepository
    {
        private readonly IfrsDocsDbContext _ifrsDocsContext;
        public FormRepository(IfrsDocsDbContext ifrsDocsContext) : base(ifrsDocsContext)
        {
            _ifrsDocsContext = ifrsDocsContext;
            _ifrsDocsContext.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }

        public async Task<List<Form>> GetAllFormsAsync()
        {
            IQueryable<Form> query = _ifrsDocsContext.Form;
            query = query.Include(d => d.Course);
            query = query.AsNoTracking().OrderByDescending(p => p.CreateDate);
            return await query.ToListAsync();
        }
    }
}
