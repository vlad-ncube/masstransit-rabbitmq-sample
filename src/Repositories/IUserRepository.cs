using Domain.DomainObjects;

namespace Repositories
{
    public interface IUserRepository : IRepository<User>
    {
        User GetByName(string firstName);
    }
}