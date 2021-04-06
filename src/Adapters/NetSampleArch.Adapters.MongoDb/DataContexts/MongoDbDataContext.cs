using MongoDB.Driver;
using NetSampleArch.Adapters.SQLServer.DataContexts.Interfaces;
using NetSampleArch.Infra.CrossCutting.Configuration;

namespace NetSampleArch.Adapters.SQLServer.DataContexts
{
    public class MongoDbDataContext : IMongoDbDataContext
    {
        public readonly MongoClient _mongoClient;
        public readonly IMongoDatabase _mongoDatabase;
        public MongoDbDataContext(Configuration configuration)
        {
            _mongoClient = new MongoClient(configuration.MongoConfiguration.ConnectionString);
            _mongoDatabase = _mongoClient.GetDatabase(configuration.MongoConfiguration.DatabaseName);
        }

        public MongoClient GetClient() 
        {
            return _mongoClient;
        }

        public IMongoDatabase GetDatabase()
        {
            return _mongoDatabase;
        }
    }
}