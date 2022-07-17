
using IfrsDocs.Domain;

namespace IfrsDocs.Services
{
    public class FormService : BaseService<Form, IFormRepository>, IFormService
    {
        public FormService(IFormRepository FormRepository) : base(FormRepository)
        {
        }
    }
}
