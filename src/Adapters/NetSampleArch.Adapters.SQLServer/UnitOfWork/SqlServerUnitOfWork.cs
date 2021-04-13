using NetSampleArch.Adapters.EFCore.DataContexts.Interfaces;
using NetSampleArch.Adapters.SQLServer.UnitOfWork.Interfaces;
using Serilog;
using System;
using System.Data;
using System.Threading;
using System.Threading.Tasks;

namespace NetSampleArch.Adapters.SQLServer.UnitOfWork
{
    public class SqlServerUnitOfWork
        : ISqlServerUnitOfWork
    {
        private readonly ILogger _logger;
        private readonly IDbContext _dbContext;

        public SqlServerUnitOfWork(ILogger logger, IDbContext dbContext)
        {
            _logger = logger;
            _dbContext = dbContext;
        }

        public async Task<bool> ExecuteWithTransactionAsync(Func<Task<bool>> handleAsync, CancellationToken cancellationToken, IDbConnection dbConnection = null, IsolationLevel isolationLevel = IsolationLevel.ReadCommitted)
        {
            try
            {
                if (await handleAsync())
                {
                    //await _dbContext.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
                    return true;
                }

                return false;
            }
            catch (Exception ex)
            {
                _logger.Error(ex.Message);
                throw;
            }
        }
    }
}