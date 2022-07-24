
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

        private static string GenerateMd5(string input)
        {
            MD5 md5Hash = MD5.Create();
            byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));
            StringBuilder sBuilder = new StringBuilder();
            //format tostring
            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }

            return sBuilder.ToString();
        }
    }
}
