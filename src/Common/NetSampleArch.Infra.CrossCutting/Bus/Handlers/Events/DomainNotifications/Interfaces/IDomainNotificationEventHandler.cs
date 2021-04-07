
using NetSampleArch.Infra.CrossCutting.Bus.Events;
using NetSampleArch.Infra.CrossCutting.Bus.Interfaces.Handlers;

namespace NetSampleArch.Infra.CrossCutting.Bus.Handlers.Events.DomainNotifications.Interfaces
{
    public interface IDomainNotificationEventHandler
        : IEventHandler<DomainNotification>
    {

    }
}
