using NetSampleArch.Application.UseCases.ReplicatePersonToQuerieDb.Interface;
using NetSampleArch.Application.UseCases.ReplicatePersonToQuerieDb.Models;
using NetSampleArch.Domain.Entities.Person.Entries;
using NetSampleArch.Domain.Services.Interfaces;
using NetSampleArch.Infra.CrossCutting.Bus.Interfaces;
using NetSampleArch.Infra.CrossCutting.UnitOfWork;
using Serilog;
using System.Threading;
using System.Threading.Tasks;

namespace NetSampleArch.Application.UseCases.ReplicatePersonToQuerieDb
{
    public class ReplicatePersonToQuerieDbUseCase : BaseUseCase, IReplicatePersonToQuerieDbUseCase
    {
        private readonly IPersonService _personService;
        public ReplicatePersonToQuerieDbUseCase(ILogger logger, IBus bus, IUnitOfWork unitOfWork, IPersonService personService)
                : base(logger, bus, unitOfWork)
        {
            _personService = personService;
        }

        public async Task<bool> ExecuteAsync(AddedPersonUseCaseModel input, CancellationToken cancellationToken)
        {
            var processResult = false;
            var personEntry = default(PersonEntry);

            processResult = await UnitOfWork.ExecuteWithTransactionAsync(async () =>
            {
                var addPerson = RegisterPersonStep(input);

                if (!addPerson.success)
                    return false;

                personEntry = addPerson.addedPersonEntry;

                var addPersonToCommandDbResult = await _personService.AddPersonToQueryDb(personEntry, cancellationToken).ConfigureAwait(false);

                if (!addPersonToCommandDbResult.success)
                    return false;

                return true;

            },
               cancellationToken
            ).ConfigureAwait(false);

            return processResult;
        }

        private (bool success, PersonEntry addedPersonEntry) RegisterPersonStep(AddedPersonUseCaseModel input)
        {
            var personEntry = new PersonEntry();

            personEntry.RegisterNewPersonEntry(
                input.Name,
                input.Address,
                input.Phone,
                input.CreatedBy
            );

            return (true, personEntry);
        }
    }
}