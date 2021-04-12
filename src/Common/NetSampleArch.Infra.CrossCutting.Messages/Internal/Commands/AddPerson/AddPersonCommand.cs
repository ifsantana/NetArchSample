using NetSampleArch.Infra.CrossCutting.Messages.Internal.Commands.AddPerson.Interfaces;
using NetSampleArch.Infra.CrossCutting.Messages.Internal.Commands.AddPerson.Models;

namespace NetSampleArch.Infra.CrossCutting.Messages.Internal.Commands.AddPerson
{
    public class AddPersonCommand : IAddPersonCommand
    {
        public AddPersonCommandModel Input { get; }

        public AddPersonCommand(AddPersonCommandModel input)
        {
            Input = input;
        }
    }
}
