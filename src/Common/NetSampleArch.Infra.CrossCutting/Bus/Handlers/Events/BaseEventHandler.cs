using System.Threading;
using System.Threading.Tasks;
using NetSampleArch.Infra.CrossCutting.Bus.Interfaces.Handlers;
using NetSampleArch.Infra.CrossCutting.Bus.Interfaces.Messages;
using Serilog;

namespace NetSampleArch.Infra.CrossCutting.Bus.Handlers
{
    public abstract class BaseEventHandler<TEvent> :  BaseHandler, IEventHandler<TEvent>
        where TEvent : IEvent
    {
        protected BaseEventHandler(ILogger logger) : base(logger)
        {
        }

        public abstract Task Handle(TEvent notification, CancellationToken cancellationToken);
    }
}