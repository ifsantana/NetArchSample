using Microsoft.Extensions.DependencyInjection;
using NetSampleArch.Adapters.SQLServer.DataContexts;
using NetSampleArch.Adapters.SQLServer.DataContexts.Interfaces;
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
            services.AddScoped<IDbContext, SqlServerDataContext>();
        }
    }
}