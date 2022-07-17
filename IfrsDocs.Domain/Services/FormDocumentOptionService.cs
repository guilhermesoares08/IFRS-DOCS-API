
using IfrsDocs.Domain;

namespace IfrsDocs.Services
{
    public class FormDocumentOptionService : BaseService<FormDocumentOption, IFormDocumentOptionRepository>, IFormDocumentOptionService
    {
        public FormDocumentOptionService(IFormDocumentOptionRepository FormDocumentOptionRepository) : base(FormDocumentOptionRepository)
        {
        }
    }
}
