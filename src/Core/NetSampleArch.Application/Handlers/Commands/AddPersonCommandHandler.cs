using NetSampleArch.Application.Handlers.Commands.Interfaces;
using NetSampleArch.Application.UseCases.AddPerson.Interface;
using NetSampleArch.Infra.CrossCutting.Bus.Handlers;
using NetSampleArch.Infra.CrossCutting.Bus.Interfaces;
using NetSampleArch.Infra.CrossCutting.Messages.Internal.Commands.AddPerson;
using Serilog;
using System.Threading;
using System.Threading.Tasks;

namespace NetSampleArch.Application.Handlers.Commands
{
    public class AddPersonCommandHandler : BaseCommandHandler<AddPersonCommand, bool>, IAddPersonCommandHandler
    {
        private readonly IAddPersonUseCase _addPersonUseCase;

        public AddPersonCommandHandler(ILogger logger, IBus bus, IAddPersonUseCase addPersonUseCase)
            : base(logger, bus)
        {
            _addPersonUseCase = addPersonUseCase;
        }

        public override async Task<bool> Handle(AddPersonCommand request, CancellationToken cancellationToken)
        {
            return await _addPersonUseCase.ExecuteAsync(
                new UseCases.AddPerson.Models.AddPersonUseCaseModel(
                    executionUser: request.Input.ExecutionUser,
                    createdBy: request.Input.CreatedBy,
                    name: request.Input.Name,
                    address: request.Input.Address,
                    phone: request.Input.Phone
                ),
                cancellationToken
            ).ConfigureAwait(false);
        }
    }
}
