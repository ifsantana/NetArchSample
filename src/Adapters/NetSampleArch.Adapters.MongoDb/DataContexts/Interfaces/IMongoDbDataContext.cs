using MongoDB.Driver;

namespace NetSampleArch.Adapters.MongoDb.DataContexts.Interfaces
{
    public interface IMongoDbDataContext
    {
        MongoClient GetClient();
        IMongoDatabase   GetDatabase();
    }
}