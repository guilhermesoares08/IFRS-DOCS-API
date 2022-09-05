using IfrsDocs.Domain.Entities.Pagination;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IfrsDocs.Domain
{
    public interface IFormRepository : IBaseRepository<Form>
    {
        List<Form> GetAllForms();

        PageList<Form> GetFormsByUser(PageParams pageParams);

        List<Form> GetPendingForms();

        List<Form> GetPendingFormsByUser(int userId);

        Form GetFormById(int id);
        PageList<Form> GetForms(PageParams pageParams);
    }
}
