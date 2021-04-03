using System.Threading;
using System.Threading.Tasks;
using NetSampleArch.Infra.CrossCutting.Bus.Interfaces.Handlers;
using NetSampleArch.Infra.CrossCutting.Bus.Interfaces.Messages;
using Serilog;

namespace NetSampleArch.Infra.CrossCutting.Bus.Handlers
{
    public abstract class BaseQueryHandler<TQuery, TResponse> : BaseHandler, IQueryHandler<TQuery, TResponse>
        where TQuery : IQuery<TResponse>
    {
        protected BaseQueryHandler(ILogger logger)
         : base(logger)
        {
        }

        public abstract Task<TResponse> Handle(TQuery request, CancellationToken cancellationToken);
    }
}