using IfrsDocs.Domain.Entities.Pagination;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IfrsDocs.Domain
{
    public interface IFormService : IBaseService<Form>
    {
        public List<Form> GetAllForms();

        public PageList<Form> GetFormsByUser(PageParams pageParams);

        public List<Form> GetPendingForms(int userId);

        public Form GetFormById(int id);

        public bool DeleteForm(int id);

        PageList<Form> GetForms(PageParams pageParams);
    }
}
