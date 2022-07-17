
using IfrsDocs.Domain;

namespace IfrsDocs.Services
{
    public class DocumentOptionService : BaseService<DocumentOption, IDocumentOptionRepository>, IDocumentOptionService
    {
        public DocumentOptionService(IDocumentOptionRepository DocumentOptionRepository) : base(DocumentOptionRepository)
        {
        }
    }
}
