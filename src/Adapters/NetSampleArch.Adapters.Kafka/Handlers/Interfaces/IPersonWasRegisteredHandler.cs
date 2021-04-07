using NetSampleArch.Infra.CrossCutting.Bus.Interfaces.Handlers;
using NetSampleArch.Infra.CrossCutting.Messages.Internal.Events.PersonWasRegistered;

namespace NetSampleArch.Adapters.Kafka.Handlers.Interfaces
{
    public interface IPersonWasRegisteredHandler : IEventHandler<PersonWasRegisteredEvent>
    {
         
    }
}