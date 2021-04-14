using NetSampleArch.Adapters.SQLServer.UnitOfWork.Interfaces;
using NetSampleArch.Infra.CrossCutting.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace NetSampleArch.Adapters.SQLServer.UnitOfWork
{
    public class DbSession : IDbSession
    {
        public IDbConnection Connection { get; }
        public IDbTransaction Transaction { get; set; }
        protected Configuration Configuration { get; }

        public DbSession(Configuration configuration)
        {
            Connection = new SqlConnection(configuration.SqlConfiguration.ConnectionString);
            Connection.Open();
        }

        public void Dispose() => Connection?.Dispose();
    }
}
