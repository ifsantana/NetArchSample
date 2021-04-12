using NetSampleArch.Infra.CrossCutting.Bus.Interfaces.Messages;
using NetSampleArch.Infra.CrossCutting.Messages.Internal.Commands.AddPerson.Models;

namespace NetSampleArch.Infra.CrossCutting.Messages.Internal.Commands.AddPerson.Interfaces
{
    public interface IAddPersonCommand : ICommand<bool>
    {
        AddPersonCommandModel Input { get; }
    }
}
