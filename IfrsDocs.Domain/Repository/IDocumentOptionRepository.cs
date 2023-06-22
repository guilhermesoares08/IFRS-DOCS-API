using System.Collections.Generic;

namespace IfrsDocs.Domain
{
    public interface IDocumentOptionRepository : IBaseRepository<DocumentOption>
    {
        public IList<DocumentOption> GetDocumentOptionByDocumentType(int documentTypeId);
    }
}
