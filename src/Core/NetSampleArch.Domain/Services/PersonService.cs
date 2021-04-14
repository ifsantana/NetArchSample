using NetSampleArch.Domain.Entities.Person;
using NetSampleArch.Domain.Entities.Person.Entries;
using NetSampleArch.Domain.Repositories.Interfaces;
using NetSampleArch.Domain.Services.Interfaces;
using NetSampleArch.Infra.CrossCutting.Bus.Interfaces;
using Serilog;
using System.Threading;
using System.Threading.Tasks;

namespace NetSampleArch.Domain.Services
{
    public class PersonService : BaseService, IPersonService
    {
        private readonly IPersonCommandRepository _personCommandRepository;
        private readonly IPersonQueryRepository _personQuerieRepository;

        public PersonService(ILogger logger, IBus bus, IPersonCommandRepository personCommandRepository, IPersonQueryRepository personQuerieRepository)
            : base(logger, bus)
        {
            _personCommandRepository = personCommandRepository;
            _personQuerieRepository = personQuerieRepository;
        }

        public async Task<(bool success, Person)> AddPersonToCommandDb(PersonEntry personEntry, CancellationToken cancellationToken)
        {
            var person = new Person();

            person.UpdateFromAssetEntry(personEntry);

            var result = await _personCommandRepository.AddPersonAsync(person, cancellationToken).ConfigureAwait(false);

            return (result, person);
        }

        public async Task<(bool success, Person)> AddPersonToQueryDb(PersonEntry personEntry, CancellationToken cancellationToken)
        {
            var person = new Person();

            person.UpdateFromAssetEntry(personEntry);

            var result = await _personQuerieRepository.AddPersonAsync(person, cancellationToken).ConfigureAwait(false);

            return (result, person);
        }
    }
}
