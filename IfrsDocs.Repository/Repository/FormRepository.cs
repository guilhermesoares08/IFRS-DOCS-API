using IfrsDocs.Domain;
using IfrsDocs.Domain.Entities.Pagination;
using IfrsDocs.Repository.Extensions;
using Microsoft.EntityFrameworkCore;
using System.Linq;

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

        public PageList<Form> GetForms(PageParams pageParams)
        {
            IQueryable<Form> query = _ifrsDocsContext.Form;
            query = query
                .ApplyFormIncludes()
                .AsNoTracking();
                //.Where(f => f.UserId.Value.ToString() == pageParams.Term);

            return PageList<Form>.Create(query, pageParams.PageNumber, pageParams.pageSize);
        }

        public Form GetFormById(int id)
        {
            IQueryable<Form> query = _ifrsDocsContext.Form;
            query = query.ApplyFormIncludes()
                .AsNoTracking()
                .Where(f => f.Id.Equals(id));

            return query.FirstOrDefault();
        }
    }
}
