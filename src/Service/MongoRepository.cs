using Domain.DomainObjects;
using MongoDB.Driver;

namespace Service
{
    class MongoRepository
    {
        static MongoDatabase database;

        static MongoRepository()
        {
            // TODO: vlad - get it from cfg
            string connectionString = "mongodb://localhost";
            string databaseName = "MasstransitSpike";

            var client = new MongoClient(connectionString);
            var server = client.GetServer();

            // TODO: vlad - get it from cfg
            database = server.GetDatabase(databaseName);
        }

        public static void AddUser (User user)
        {
            var collection = database.GetCollection<User>("Users"); // Users - is the name of the collection

            collection.Insert(user);
        }
    }
}