using MediatR;
using NetSampleArch.Infra.CrossCutting.Bus.Interfaces.Messages;

namespace NetSampleArch.Infra.CrossCutting.Bus.Interfaces.Handlers
{
    public interface IEventHandler<in TEvent> : IHandler, INotificationHandler<TEvent>
        where TEvent : IEvent
    {
    }
}