using MongoDB.Driver;

namespace NetSampleArch.Adapters.SQLServer.DataContexts.Interfaces
{
    public interface IMongoDbDataContext
    {
        MongoClient GetClient();
        IMongoDatabase   GetDatabase();
    }
}