using NetSampleArch.Infra.CrossCutting.Messages.Internal.Commands.Interfaces;
using NetSampleArch.Infra.CrossCutting.Messages.Internal.Commands.ReplicatePersonCreated.Models;

namespace NetSampleArch.Infra.CrossCutting.Messages.Internal.Commands.ReplicatePersonCreated
{
    public class ReplicatePersonCreatedCommand : IReplicatePersonCreatedCommand
    {
        public PersonCreatedEntry Entry {get;}

        public ReplicatePersonCreatedCommand(PersonCreatedEntry entry)
        {
            Entry  =  entry;
        }
    }
}