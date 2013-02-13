using System.Configuration;
using Domain.DomainObjects;
using MongoDB.Bson.Serialization;
using MongoDB.Driver;

namespace Repositories.MongoRepository
{
    public abstract class BaseMongoRepository<TEntity> : IRepository<TEntity> where TEntity : IEntity
    {
        private static MongoDatabase database;

        protected MongoDatabase Database
        {
            get { return database; }
        }

        protected virtual string TableName
        {
            get { return typeof(TEntity).Name; }
        }

        static BaseMongoRepository()
        {
            string connectionString = ConfigurationManager.AppSettings["MongoDbConnectionString"];
            string databaseName = ConfigurationManager.AppSettings["MongoDbDatabaseName"];

            database = new MongoClient(connectionString).GetServer().GetDatabase(databaseName);

            BsonClassMap.RegisterClassMap<BaseEntity>(cm =>
            {
                cm.AutoMap();
                cm.GetMemberMap(u => u.Id).SetElementName("_id");
            });
        }

        public void Add(TEntity entity)
        {
            Database.GetCollection<TEntity>(TableName).Insert(entity);
        }

        public void DeleteAll()
        {
            database.GetCollection<TEntity>(TableName).Drop();
        }
    }
}