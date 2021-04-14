using MongoDB.Driver;
using NetSampleArch.Adapters.MongoDb.DataContexts.Interfaces;
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
            _mongoDatabase = _mongoClient.GetDatabase("CDC_QUERY_DB");
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