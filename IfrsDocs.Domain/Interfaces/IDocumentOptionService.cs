using System.Collections.Generic;

namespace IfrsDocs.Domain
{
    public interface IDocumentOptionService : IBaseService<DocumentOption, IDocumentOptionRepository>
    {
        public IList<DocumentOption> GetDocumentOptionByDocumentType(int documentType);
    }
}
