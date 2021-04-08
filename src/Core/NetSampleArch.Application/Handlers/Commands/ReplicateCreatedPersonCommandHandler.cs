using System.Threading;
using System.Threading.Tasks;
using NetSampleArch.Application.UseCases.ReplicatePersonToQuerieDb.Interface;
using NetSampleArch.Infra.CrossCutting.Bus.Handlers;
using NetSampleArch.Infra.CrossCutting.Bus.Interfaces;
using NetSampleArch.Infra.CrossCutting.Messages.Internal.Commands.ReplicatePersonCreated;
using Serilog;

namespace NetSampleArch.Application.Handlers.Commands.Interfaces
{
    public class ReplicateCreatedPersonCommandHandler : BaseCommandHandler<ReplicatePersonCreatedCommand, bool>,
        IReplicateCreatedPersonCommandHandler
    {
        public readonly IReplicatePersonToQuerieDbUseCase _replicatePersonToQuerieDbUseCase;

        public ReplicateCreatedPersonCommandHandler(IReplicatePersonToQuerieDbUseCase replicatePersonToQuerieDbUseCase, ILogger logger, IBus bus) 
            : base(logger, bus)
        {
            _replicatePersonToQuerieDbUseCase = replicatePersonToQuerieDbUseCase;
        }

        public override async Task<bool> Handle(ReplicatePersonCreatedCommand request, CancellationToken cancellationToken)
        {
            return await Task.FromResult(true);
        }
    }
}