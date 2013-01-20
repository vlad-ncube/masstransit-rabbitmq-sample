using System.Collections;
using Domain.DomainObjects;
using MongoDB.Bson.Serialization;
using MongoDB.Driver;

namespace Repositories
{
    // TODO: vlad - make it to be used by DI
    public class MongoRepository
    {
        static MongoDatabase database;

        static MongoRepository()
        {
            // TODO: vlad - get it from cfg
            string connectionString = "mongodb://localhost";
            string databaseName = "MasstransitSpike";

            BsonClassMap.RegisterClassMap<User>(cm =>
            {
                cm.AutoMap();
                cm.GetMemberMap(u => u.UserId).SetElementName("_id");
            });

            database = new MongoClient(connectionString).GetServer().GetDatabase(databaseName);
        }

        public static void AddUser (User user)
        {
            database.GetCollection<User>("Users").Insert(user);
        }

        public static User GetUserByName(string firstName)
        {
            return database.GetCollection<User>("Users").FindOne(new QueryDocument("FirstName", firstName));
        }

        public static void DeleteUsers()
        {
            database.GetCollection<User>("Users").Drop();
        }
    }
}