using Microsoft.EntityFrameworkCore;
using NetSampleArch.Adapters.SQLServer.DataContexts.Interfaces;
using NetSampleArch.Infra.CrossCutting.Configuration;

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
            optionsBuilder.UseSqlServer(Configuration.SqlConfiguration.ConnectionString); ;
        }
    }
}