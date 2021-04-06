using System;
using System.Data;
using System.Threading;
using System.Threading.Tasks;
using NetSampleArch.Adapters.SQLServer.DataContexts.Interfaces;
using NetSampleArch.Adapters.SQLServer.UnitOfWork.Interfaces;

namespace NetSampleArch.Adapters.SQLServer.UnitOfWork
{
    public class SqlServerUnitOfWork
        : ISqlServerUnitOfWork
    {
        private readonly IDbContext _dbContext;

        public SqlServerUnitOfWork(IDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<bool> ExecuteWithTransactionAsync(Func<Task<bool>> handleAsync, CancellationToken cancellationToken, IDbConnection dbConnection = null, IsolationLevel isolationLevel = IsolationLevel.ReadCommitted)
        {
            try
            {
                if (await handleAsync())
                {
                    await _dbContext.SaveChangesAsync(cancellationToken);
                    return true;
                }

                return false;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}