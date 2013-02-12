﻿using Domain.DomainObjects;
using MongoDB.Driver;

namespace Repositories.MongoRepository
{
    class UserRepository : BaseMongoRepository<User>, IUserRepository
    {
        public User GetByName(string firstName)
        {
            return Database.GetCollection<User>(TableName).FindOne(new QueryDocument("FirstName", firstName));
        }
    }
}