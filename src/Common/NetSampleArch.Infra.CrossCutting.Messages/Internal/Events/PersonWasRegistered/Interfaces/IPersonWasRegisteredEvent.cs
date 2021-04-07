using NetSampleArch.Infra.CrossCutting.Bus.Interfaces.Messages;
using NetSampleArch.Infra.CrossCutting.Messages.Internal.Events.PersonWasRegistered.Models;

namespace NetSampleArch.Infra.CrossCutting.Messages.Internal.Events.PersonWasRegistered.Interfaces
{
    public interface IPersonWasRegisteredEvent : IEvent
    {
        PersonWasRegisteredEventDto PersonWasRegisteredEventDto { get; }
    }
}