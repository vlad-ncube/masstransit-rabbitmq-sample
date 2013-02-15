using Domain.DomainObjects;

namespace MasstransitSpike.Core.Repositories
{
    public interface IUserRepository : IRepository<User>
    {
        User GetByName(string firstName);
    }
}