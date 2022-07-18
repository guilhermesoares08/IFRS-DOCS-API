using System.Collections.Generic;
using System.Threading.Tasks;

namespace IfrsDocs.Domain
{
    public interface IFormService : IBaseService<Form>
    {
        public Task<List<Form>> GetAllFormsAsync();
    }
}
