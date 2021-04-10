using NetSampleArch.Adapters.SQLServer.Repositories.Interfaces;
using NetSampleArch.Domain.Entities.Interfaces;
using NetSampleArch.Infra.CrossCutting.Bus.Interfaces;
using Serilog;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace NetSampleArch.Adapters.SQLServer.Repositories
{
    public abstract class BaseRepository<TEntity> : ISqlServerRepository<TEntity>
        where TEntity : IEntity
    {
        
        protected ILogger Logger { get; }
        protected IBus Bus { get; }

        protected BaseRepository(ILogger logger, IBus bus)
        {
            Logger = logger;
            Bus = bus;
        }

        public abstract Task<TEntity> AddInternalAsync(TEntity entity, CancellationToken cancellationToken);
        public abstract Task<TEntity> UpdateInternalAsync(TEntity entity, CancellationToken cancellationToken);
        public abstract Task RemoveInternalAsync(Guid id, CancellationToken cancellationToken);
        public abstract Task<TEntity> GetByIdInternalAsync(Guid id, CancellationToken cancellationToken);
        public abstract Task<IEnumerable<TEntity>> GetAllInternalAsync(CancellationToken cancellationToken);
    }
}
