using IfrsDocs.Domain;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace IfrsDocs.Repository
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        private readonly IfrsDocsDbContext _ifrsDocsContext;
        public UserRepository(IfrsDocsDbContext ifrsDocsContext) : base(ifrsDocsContext)
        {
            _ifrsDocsContext = ifrsDocsContext;
            _ifrsDocsContext.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }

        public User GetUserById(int id)
        {
            IQueryable<User> query = _ifrsDocsContext.User;
            query = query.Include(q => q.Role);
            query = query.AsNoTracking().Where(c => c.Id == id);
            return query.FirstOrDefault();
        }

        public User ValidateUser(string userName, string password)
        {
            IQueryable<User> query = _ifrsDocsContext.User;
            query = query.AsNoTracking().Include(q => q.Role);
            foreach (var item in query)
            {
                if (item.Login.ToLower().Equals(userName.ToLower())
                    //&& GenerateMd5(item.Password).Equals(password))
                    && item.Password.Equals(password))
                {
                    User objRet = item.Clone();
                    objRet.Password = GenerateMd5(objRet.Password);
                    return objRet;
                }              
            }
            return null;
        }

        public User GetUserByLogin(string login)
        {
            IQueryable<User> query = _ifrsDocsContext.User;
            query = query.AsNoTracking().Where(c => c.Login.ToLower().Equals(login.ToLower()));
            query = query.Include(q => q.Role);
            if (query != null && query.First() != null)
            {
                User retObj = query.First().Clone();
                retObj.Password = GenerateMd5(retObj.Password);
                return retObj;
            }

            return query.FirstOrDefault();
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
