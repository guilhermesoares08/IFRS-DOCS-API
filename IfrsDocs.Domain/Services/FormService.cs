
using IfrsDocs.Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IfrsDocs.Services
{
    public class FormService : BaseService<Form, IFormRepository>, IFormService
    {
        public FormService(IFormRepository FormRepository) : base(FormRepository)
        {
        }

        public Task<List<Form>> GetAllFormsAsync()
        {
            return _repository.GetAllFormsAsync();
        }
    }
}
