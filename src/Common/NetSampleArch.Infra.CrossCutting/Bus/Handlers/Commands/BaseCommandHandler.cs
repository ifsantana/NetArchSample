using System.Threading;
using System.Threading.Tasks;
using NetSampleArch.Infra.CrossCutting.Bus.Events;
using NetSampleArch.Infra.CrossCutting.Bus.Interfaces;
using NetSampleArch.Infra.CrossCutting.Bus.Interfaces.Handlers;
using NetSampleArch.Infra.CrossCutting.Bus.Interfaces.Messages;
using Serilog;

namespace NetSampleArch.Infra.CrossCutting.Bus.Handlers
{
    public abstract class BaseCommandHandler<TCommand, TResponse> : BaseHandler, ICommandHandler<TCommand, TResponse>
        where TCommand : ICommand<TResponse>
    {
        private readonly IBus _bus;

        protected BaseCommandHandler(ILogger logger, IBus bus) 
        : base(logger)
        {
            _bus = bus;
        }

        public abstract Task<TResponse> Handle(TCommand request, CancellationToken cancellationToken);

        protected async Task SendDomainNotificationAsync(NotificationType notificationMessageType, string source, string code, CancellationToken cancellationToken)
        {
            await _bus.SendEventAsync(
                new DomainNotification(
                    notificationMessageType,
                    source,
                    code
                ),
                cancellationToken
            ).ConfigureAwait(false);
        }
    }
}