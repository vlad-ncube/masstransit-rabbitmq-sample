using System.Configuration;
using Domain.DomainObjects;
using MongoDB.Bson.Serialization;
using MongoDB.Driver;

namespace Repositories
{
    public class MongoRepository : IRepository
    {
        static MongoDatabase database;

        static MongoRepository()
        {
            string connectionString = ConfigurationManager.AppSettings["MongoDbConnectionString"];
            string databaseName = ConfigurationManager.AppSettings["MongoDbDatabaseName"];

            BsonClassMap.RegisterClassMap<User>(cm =>
            {
                cm.AutoMap();
                cm.GetMemberMap(u => u.UserId).SetElementName("_id");
            });

            database = new MongoClient(connectionString).GetServer().GetDatabase(databaseName);
        }

        public void AddUser (User user)
        {
            database.GetCollection<User>("Users").Insert(user);
        }

        public User GetUserByName(string firstName)
        {
            return database.GetCollection<User>("Users").FindOne(new QueryDocument("FirstName", firstName));
        }

        public void DeleteUsers()
        {
            database.GetCollection<User>("Users").Drop();
        }
    }
}