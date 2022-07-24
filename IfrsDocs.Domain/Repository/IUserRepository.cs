namespace IfrsDocs.Domain
{
    public interface IUserRepository : IBaseRepository<User>
    {
        User GetUserById(int id);
        User ValidateUser(string email, string password);
        User GetUserByLogin(string login);
    }
}
