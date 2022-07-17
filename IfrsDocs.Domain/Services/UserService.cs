
using IfrsDocs.Domain;

namespace IfrsDocs.Services
{
    public class UserService : BaseService<User, IUserRepository>, IUserService
    {
        public UserService(IUserRepository UserRepository) : base(UserRepository)
        {
        }
    }
}
