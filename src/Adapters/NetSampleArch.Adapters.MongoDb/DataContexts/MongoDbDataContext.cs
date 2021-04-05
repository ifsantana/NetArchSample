using MongoDB.Driver;
using NetSampleArch.Infra.CrossCutting.Configuration;

namespace NetSampleArch.Adapters.SQLServer.DataContexts
{
    public class MongoDataContext
    {
        public readonly MongoClient _mongoClient;
        public MongoDataContext(Configuration configuration)
        {
            _mongoClient = new MongoClient(configuration.MongoConfiguration.ConnectionString);
        }

        public MongoClient GetClient() 
        {
            return _mongoClient;
        }
    }
}