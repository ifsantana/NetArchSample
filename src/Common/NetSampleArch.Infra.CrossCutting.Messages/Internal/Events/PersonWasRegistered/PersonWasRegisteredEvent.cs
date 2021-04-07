using NetSampleArch.Infra.CrossCutting.Messages.Internal.Events.PersonWasRegistered.Interfaces;
using NetSampleArch.Infra.CrossCutting.Messages.Internal.Events.PersonWasRegistered.Models;

namespace NetSampleArch.Infra.CrossCutting.Messages.Internal.Events.PersonWasRegistered
{
    public class PersonWasRegisteredEvent : IPersonWasRegisteredEvent
    {
        public PersonWasRegisteredEventDto PersonWasRegisteredEventDto {get;}

        public PersonWasRegisteredEvent(PersonWasRegisteredEventDto personWasRegisteredEventDto)
        {
            PersonWasRegisteredEventDto = personWasRegisteredEventDto;
        }
    }
}