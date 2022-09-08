using IfrsDocs.Domain.Entities.Pagination;

namespace IfrsDocs.Domain
{
    public interface IFormRepository : IBaseRepository<Form>
    {
        Form GetFormById(int id);
        PageList<Form> GetForms(PageParams pageParams);
    }
}
