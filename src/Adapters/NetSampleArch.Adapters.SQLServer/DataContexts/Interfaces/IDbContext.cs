using System.Threading;
using System.Threading.Tasks;

namespace NetSampleArch.Adapters.SQLServer.DataContexts.Interfaces
{
    public interface IDbContext
    {
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}