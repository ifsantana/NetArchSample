using NetSampleArch.Infra.CrossCutting.Bus.Interfaces.Handlers;
using NetSampleArch.Infra.CrossCutting.Messages.Internal.Commands.AddPerson;

namespace NetSampleArch.Application.Handlers.Commands.Interfaces
{
    public interface IAddPersonCommandHandler : ICommandHandler<AddPersonCommand, bool>
    {
    }
}
