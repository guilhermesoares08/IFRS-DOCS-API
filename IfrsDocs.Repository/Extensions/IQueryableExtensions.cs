using IfrsDocs.Domain;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace IfrsDocs.Repository.Extensions
{
    public static class IQueryableExtensions
    {
        public static IQueryable<Form> ApplyFormIncludes(this IQueryable<Form> forms)
        {
            return forms.Include(q => q.Course)
                .Include(q => q.FormDocumentOptions).ThenInclude(c => c.DocumentOption)
                .Include(q => q.User).ThenInclude(u => u.Role);
        }
    }
}
