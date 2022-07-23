using System.Collections.Generic;
using System.Threading.Tasks;

namespace IfrsDocs.Domain
{
    public interface IFormService : IBaseService<Form>
    {
        public List<Form> GetAllForms();

        public List<Form> GetFormsByUser(int userId);

        public List<Form> GetPendingForms(int userId);

        public Form GetFormById(int id);
    }
}
