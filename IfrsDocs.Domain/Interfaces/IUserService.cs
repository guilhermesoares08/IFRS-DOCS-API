namespace IfrsDocs.Domain
{
    public interface IUserService : IBaseService<User, IUserRepository>
    {
        User GetUserById(int id);
        User ValidateUser(string userName, string password);
        User GetUserByLogin(string login);
    }
}
