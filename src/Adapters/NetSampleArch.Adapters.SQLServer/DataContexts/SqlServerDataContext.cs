using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using NetSampleArch.Adapters.EFCore.DataContexts;
using NetSampleArch.Adapters.EFCore.DataContexts.Interfaces;
using NetSampleArch.Infra.CrossCutting.Configuration;
using ConfigurationBuilder = NetSampleArch.Infra.CrossCutting.Configuration.ConfigurationBuilder;

namespace NetSampleArch.Adapters.SQLServer.DataContexts
{
    public class SqlServerDataContext : DefaultContext, IDbContext
    {
        public SqlServerDataContext(Configuration configuration)
            : base(configuration)
        {

        }

        protected override void OnConfiguringInternal(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(Configuration.SqlConfiguration.ConnectionString);
        }

        public class SqlServerDataContextDesignTimeDbContextFactory :
            IDesignTimeDbContextFactory<SqlServerDataContext>
        {
            public SqlServerDataContext CreateDbContext(string[] args)
            {
                return new SqlServerDataContext(
                   ConfigurationBuilder.GetConfigurationBuilder(null).Build().Get<Configuration>()
                );
            }
        }
    }
}