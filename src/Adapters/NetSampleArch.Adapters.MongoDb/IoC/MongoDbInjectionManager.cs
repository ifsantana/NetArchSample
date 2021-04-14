using Microsoft.Extensions.DependencyInjection;
using NetSampleArch.Adapters.MongoDb.DataContexts.Interfaces;
using NetSampleArch.Adapters.MongoDb.Models.Factories;
using NetSampleArch.Adapters.MongoDb.Models.Factories.Interfaces;
using NetSampleArch.Adapters.MongoDb.Repositories;
using NetSampleArch.Adapters.MongoDb.Repositories.Interfaces;
using NetSampleArch.Adapters.SQLServer.DataContexts;

namespace NetSampleArch.Adapters.MongoDb.IoC
{
    public static class MongoDbInjectionManager
    {
        public static void Inject(IServiceCollection services)
        {
            services.AddScoped<IMongoDbDataContext, MongoDbDataContext>();
            services.AddScoped<IPersonMongoDbRepository, PersonMongoDbRepository>();
            services.AddScoped<IPersonModelFactory, PersonModelFactory>();
        }
    }
}
