using NetSampleArch.Infra.CrossCutting.Bus.Events;
using NetSampleArch.Infra.CrossCutting.Bus.Handlers.Events.DomainNotifications.Interfaces;
using Serilog;
using System.Threading;
using System.Threading.Tasks;

namespace NetSampleArch.Infra.CrossCutting.Bus.Handlers.Events.DomainNotifications
{
    public class DomainNotificationEventHandler
        : BaseEventHandler<DomainNotification>,
        IDomainNotificationEventHandler
    {
        private readonly IRaisedDomainNotifications _raisedNotifications;

        public DomainNotificationEventHandler(
            ILogger logger,
            IRaisedDomainNotifications raisedNotifications
        ) : base(logger)
        {
            _raisedNotifications = raisedNotifications;
        }

        public override Task Handle(DomainNotification notification, CancellationToken cancellationToken)
        {
            _raisedNotifications.AddValidationMessage(
                messageType: notification.NotificationTypeCode,
                source: notification.Source,
                code: notification.Code
            );

            return Task.CompletedTask;
        }
    }
}
