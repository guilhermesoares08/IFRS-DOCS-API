namespace IfrsDocs.Domain
{
    public interface IUserRepository : IBaseRepository<User>
    {
        User GetUserById(int id);
    }
}
