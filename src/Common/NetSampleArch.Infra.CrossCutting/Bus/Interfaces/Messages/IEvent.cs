using MediatR;

namespace NetSampleArch.Infra.CrossCutting.Bus.Interfaces.Messages
{
    public interface IEvent : IMessage, INotification
    {
    }
}