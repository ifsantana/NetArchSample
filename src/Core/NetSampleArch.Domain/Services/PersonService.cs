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

        public PersonService(ILogger logger, IBus bus, IPersonCommandRepository personCommandRepository)
            : base(logger, bus)
        {
            _personCommandRepository = personCommandRepository;
        }

        public async Task<(bool success, Person)> AddPersonToCommandDb(PersonEntry personEntry, CancellationToken cancellationToken)
        {
            var person = new Person();

            person.UpdateFromAssetEntry(personEntry);

            var result = await _personCommandRepository.AddPersonAsync(person, cancellationToken).ConfigureAwait(false);

            return (result, person);
        }
    }
}
