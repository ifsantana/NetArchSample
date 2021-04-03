using System;
using System.Data;
using System.Threading;
using System.Threading.Tasks;

namespace NetSampleArch.Infra.CrossCutting.UnitOfWork
{
    public interface IUnitOfWork
    {
        Task<bool> ExecuteWithTransactionAsync(Func<Task<bool>> handleAsync, CancellationToken cancellationToken, IDbConnection dbConnection = null, IsolationLevel isolationLevel = IsolationLevel.ReadCommitted);
    }
}