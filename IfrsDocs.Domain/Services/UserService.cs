
using IfrsDocs.Domain;

namespace IfrsDocs.Services
{
    public class UserService : BaseService<User, IUserRepository>, IUserService
    {
        public UserService(IUserRepository userRepository) : base(userRepository)
        { }
        public User GetUserById(int id)
        {
            return this._repository.GetUserById(id);
        }
    }
}
