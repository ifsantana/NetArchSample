using Microsoft.EntityFrameworkCore;
using NetSampleArch.Adapters.EFCore.DataContexts.Interfaces;
using NetSampleArch.Adapters.EFCore.Models;
using NetSampleArch.Adapters.EFCore.Repositories.Interfaces;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;

namespace NetSampleArch.Adapters.EFCore.Repositories
{
    public class DataModelRepositoryBase<TDataModel> : IDataModelRepository<TDataModel> where TDataModel : BaseModel
    {
        private readonly IDbContext _dbContext;
        protected ILogger Logger { get; }
        protected DbSet<TDataModel> DbSet { get; }

        public DataModelRepositoryBase(ILogger logger, IDbContext dbContext)
		{
			Logger = logger;
			_dbContext = dbContext;
			DbSet = _dbContext.Set<TDataModel>();
		}

        public async Task<TDataModel> AddAsync(TDataModel dataModel, CancellationToken cancellationToken)
        {
            return (await DbSet.AddAsync(dataModel, cancellationToken).ConfigureAwait(false)).Entity;
        }

        public Task<IEnumerable<TDataModel>> FindAsync(Expression<Func<TDataModel, bool>> expression, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<TDataModel>> GetAllAsync(CancellationToken cancellationToken)
        {
            return await DbSet.AsNoTracking().ToListAsync(cancellationToken).ConfigureAwait(false);
        }

        public async Task<TDataModel> GetByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            return await DbSet.AsNoTracking().Where(q => q.Id == id).FirstOrDefaultAsync(cancellationToken).ConfigureAwait(false);
        }

        public Task RemoveAsync(Guid id, CancellationToken cancellationToken)
        {
            var localDataModel = DbSet.Local.FirstOrDefault(q => q.Id == id);
            var dataModel = Activator.CreateInstance<TDataModel>();
            dataModel.Id = id;

            DbSet.Remove(localDataModel ?? dataModel);

            return Task.CompletedTask;
        }

        public Task<TDataModel> UpdateAsync(TDataModel dataModel, CancellationToken cancellationToken)
        {
            var localDataModel = DbSet.Local.FirstOrDefault(q => q.Id == dataModel.Id);

            var entry = _dbContext.Entry(localDataModel ?? dataModel);
            entry.State = EntityState.Modified;

            SetModifiedProperties(entry, dataModel);

            return Task.FromResult(entry.Entity);
        }
    }
}
