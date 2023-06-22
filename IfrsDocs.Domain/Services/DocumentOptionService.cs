
using IfrsDocs.Domain;
using System.Collections.Generic;

namespace IfrsDocs.Services
{
    public class DocumentOptionService : BaseService<DocumentOption, IDocumentOptionRepository>, IDocumentOptionService
    {
        public DocumentOptionService(IDocumentOptionRepository documentOptionRepository) : base(documentOptionRepository)
        { }

        public IList<DocumentOption> GetDocumentOptionByDocumentType(int documentTypeId)
        {
            return _repository.GetDocumentOptionByDocumentType(documentTypeId);
        }
    }
}
