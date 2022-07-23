using IfrsDocs.Domain;
using IfrsDocs.Repository.Extensions;
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

        public List<Form> GetAllForms()
        {
            IQueryable<Form> query = _ifrsDocsContext.Form;
            
            query = query
                .ApplyFormIncludes()
                .AsNoTracking()
                .OrderByDescending(p => p.CreateDate);
            return query.ToList();
        }

        public List<Form> GetFormsByUser(int userId)
        {
            IQueryable<Form> query = _ifrsDocsContext.Form;
            query = query
                .ApplyFormIncludes()
                .AsNoTracking()
                .Where(f => f.UserId == userId);

            return query.ToList();
        }

        public List<Form> GetPendingForms()
        {
            IQueryable<Form> query = _ifrsDocsContext.Form;
            query = query.ApplyFormIncludes()
                .AsNoTracking()
                .Where(f => !f.Status.HasValue || f.Status == Domain.Entities.Enums.FormStatus.Pendente);

            return query.ToList();
        }

        public List<Form> GetPendingFormsByUser(int userId)
        {
            IQueryable<Form> query = _ifrsDocsContext.Form;
            query = query.ApplyFormIncludes()                
                .AsNoTracking()
                .Where(f => f.Status == Domain.Entities.Enums.FormStatus.Pendente && f.UserId.Equals(userId));

            return query.ToList();
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
