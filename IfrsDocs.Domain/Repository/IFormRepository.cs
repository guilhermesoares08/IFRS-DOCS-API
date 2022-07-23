using System.Collections.Generic;
using System.Threading.Tasks;

namespace IfrsDocs.Domain
{
    public interface IFormRepository : IBaseRepository<Form>
    {
        List<Form> GetAllForms();

        List<Form> GetFormsByUser(int userId);

        List<Form> GetPendingForms();

        List<Form> GetPendingFormsByUser(int userId);

        Form GetFormById(int id);
    }
}
