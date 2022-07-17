
using IfrsDocs.Domain;

namespace IfrsDocs.Services
{
    public class RoleService : BaseService<Role, IRoleRepository>, IRoleService
    {
        public RoleService(IRoleRepository RoleRepository) : base(RoleRepository)
        {
        }
    }
}
