using NetSampleArch.Infra.CrossCutting.Bus.Interfaces.Messages;
using NetSampleArch.Infra.CrossCutting.Messages.Internal.Commands.ReplicatePersonCreated.Models;

namespace NetSampleArch.Infra.CrossCutting.Messages.Internal.Commands.Interfaces
{
    public interface IReplicatePersonCreatedCommand : ICommand<bool>
    {
         AddPersonCommandModel Entry {get;}
    }
}