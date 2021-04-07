using NetSampleArch.Infra.CrossCutting.Bus.Interfaces.Handlers;
using NetSampleArch.Infra.CrossCutting.Messages.Internal.Commands.ReplicatePersonCreated;

namespace NetSampleArch.Application.Handlers.Commands.Interfaces
{
    public interface ReplicateCreatedPersonCommandHandler : ICommandHandler<ReplicatePersonCreatedCommand, bool>
    {
         
    }
}