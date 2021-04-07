using System.Threading;
using System.Threading.Tasks;
using NetSampleArch.Adapters.SQLServer.DataContexts.Interfaces;

namespace NetSampleArch.Adapters.SQLServer.DataContexts
{
    public class SqlServerDataContext : IDbContext
    {
        public Task<int> SaveChangesAsync(CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }
    }
}