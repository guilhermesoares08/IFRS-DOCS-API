using System.Collections.Generic;
using System.Threading.Tasks;

namespace IfrsDocs.Domain
{
    public interface IFormRepository : IBaseRepository<Form>
    {
        public Task<List<Form>> GetAllFormsAsync();
    }
}
