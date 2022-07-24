
using IfrsDocs.Domain;
using System.Security.Cryptography;
using System.Text;

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

        public User GetUserByLogin(string login)
        {
            return this._repository.GetUserByLogin(login);
        }

        public User ValidateUser(string userName, string password)
        {
            return this._repository.ValidateUser(userName, password);
        }
    }
}
