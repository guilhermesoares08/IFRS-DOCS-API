using IfrsDocs.Domain.Entities.Pagination;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IfrsDocs.Domain
{
    public interface IFormService : IBaseService<Form>
    {
        public Form GetFormById(int id);

        public bool DeleteForm(int id);

        PageList<Form> GetForms(PageParams pageParams);
    }
}
