
using IfrsDocs.Domain;

namespace IfrsDocs.Services
{
    public class FormCanceledService : BaseService<FormCanceled, IFormCanceledRepository>, IFormCanceledService
    {
        public FormCanceledService(IFormCanceledRepository FormCanceledRepository) : base(FormCanceledRepository)
        {
        }
    }
}
