using NetSampleArch.Adapters.EFCore.Models.Factories.Interfaces;
using NetSampleArch.Adapters.EFCore.Repositories.Interfaces;
using NetSampleArch.Adapters.SQLServer.Repositories.Interfaces;
using NetSampleArch.Domain.Entities.Person;
using NetSampleArch.Infra.CrossCutting.Bus.Interfaces;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace NetSampleArch.Adapters.SQLServer.Repositories
{
    public class PersonSqlServerRepository : BaseRepository<Person>, IPersonSqlServerRepository
    {
        private readonly IPersonModelRepository _personModelRepository;
        private readonly IPersonModelFactory _personModelFactory;

        public PersonSqlServerRepository(ILogger logger, IBus bus, IPersonModelRepository personModelRepository, IPersonModelFactory personModelFactory) 
            : base(logger, bus)
        {
            _personModelRepository = personModelRepository;
            _personModelFactory = personModelFactory;
        }

        public async override Task<Person> AddInternalAsync(Person entity, CancellationToken cancellationToken)
        {
            await _personModelRepository.AddAsync(_personModelFactory.Create(entity), cancellationToken).ConfigureAwait(false);

            return entity;
        }

        public async Task<bool> AddPersonAsync(Person person, CancellationToken cancellationToken)
        {
            await _personModelRepository.AddAsync(_personModelFactory.Create(person), cancellationToken).ConfigureAwait(false);

            return await Task.FromResult(true);
        }

        public async override Task<IEnumerable<Person>> GetAllInternalAsync(CancellationToken cancellationToken)
        {
            return (await _personModelRepository.GetAllAsync(cancellationToken).ConfigureAwait(false)).Cast<Person>();
        }

        public override Task<Person> GetByIdInternalAsync(Guid id, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public override Task RemoveInternalAsync(Guid id, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public override Task<Person> UpdateInternalAsync(Person entity, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}