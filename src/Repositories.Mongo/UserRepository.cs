using Domain.DomainObjects;
using MongoDB.Driver;
using MasstransitSpike.Core.Repositories;

namespace Repositories.Mongo
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public User GetByName(string firstName)
        {
            return Database.GetCollection<User>(TableName).FindOne(new QueryDocument("FirstName", firstName));
        }
    }
}