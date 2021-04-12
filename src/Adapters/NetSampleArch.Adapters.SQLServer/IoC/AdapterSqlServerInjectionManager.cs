using Microsoft.Extensions.DependencyInjection;
using NetSampleArch.Adapters.EFCore.DataContexts.Interfaces;
using NetSampleArch.Adapters.EFCore.Models.Factories;
using NetSampleArch.Adapters.EFCore.Models.Factories.Interfaces;
using NetSampleArch.Adapters.EFCore.Repositories;
using NetSampleArch.Adapters.EFCore.Repositories.Interfaces;
using NetSampleArch.Adapters.SQLServer.DataContexts;
using NetSampleArch.Adapters.SQLServer.Repositories;
using NetSampleArch.Adapters.SQLServer.Repositories.Interfaces;
using NetSampleArch.Adapters.SQLServer.UnitOfWork;
using NetSampleArch.Adapters.SQLServer.UnitOfWork.Interfaces;

namespace NetSampleArch.Adapters.SQLServer.IoC
{
    public static class AdapterSqlServerInjectionManager
    {
        public static void Inject(IServiceCollection services) 
        {
            services.AddScoped<ISqlServerUnitOfWork, SqlServerUnitOfWork>();
            services.AddScoped<IPersonSqlServerRepository, PersonSqlServerRepository>();

            services.AddDbContext<IDbContext, SqlServerDataContext>();
            services.AddScoped<IPersonModelRepository, PersonModelRepository>();

            //Factories
            services.AddScoped<IPersonModelFactory, PersonModelFactory>();
        }
    }
}