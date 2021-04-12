using System.Threading;
using System.Threading.Tasks;
using NetSampleArch.Infra.CrossCutting.Bus.Events;
using NetSampleArch.Infra.CrossCutting.Bus.Interfaces;
using NetSampleArch.Infra.CrossCutting.UnitOfWork;
using Serilog;

namespace NetSampleArch.Application.UseCases
{
    public abstract class BaseUseCase
    {
        protected ILogger Logger { get; }
        protected IBus Bus { get; }
        protected IUnitOfWork UnitOfWork { get; }

        protected BaseUseCase(ILogger logger, IBus bus, IUnitOfWork unitOfWork)
        {
            Logger = logger;
            Bus = bus;
            UnitOfWork = unitOfWork;
        }

        protected async Task SendDomainNotificationAsync(NotificationType notificationMessageType, string source, string code, CancellationToken cancellationToken)
        {
            await Bus.SendEventAsync(
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