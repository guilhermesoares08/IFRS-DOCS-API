namespace IfrsDocs.Domain
{
    public interface IUserService : IBaseService<User>
    {
        User GetUserById(int id);
        bool ValidateUser(string userName, string password);
        User GetUserByLogin(string login);
    }
}
