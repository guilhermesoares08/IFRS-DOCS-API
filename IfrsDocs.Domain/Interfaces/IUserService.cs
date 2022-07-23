namespace IfrsDocs.Domain
{
    public interface IUserService : IBaseService<User>
    {
        User GetUserById(int id);
    }
}
