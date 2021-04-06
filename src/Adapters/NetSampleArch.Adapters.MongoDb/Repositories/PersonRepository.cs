using System.Collections.Generic;
using System.Threading.Tasks;
using MongoDB.Driver;
using NetSampleArch.Adapters.MongoDb.Models;
using NetSampleArch.Adapters.MongoDb.Repositories.Interfaces;
using NetSampleArch.Adapters.SQLServer.DataContexts.Interfaces;
using NetSampleArch.Infra.CrossCutting.Configuration;

namespace NetSampleArch.Adapters.MongoDb.Repositories
{
    public class PersonRepository : IPersonRepository
    {
        private readonly IMongoCollection<Person> _persons;
        private readonly IMongoDbDataContext _mongoDbContext;

        public PersonRepository(IMongoDbDataContext _mongoDbContext, Configuration configuration)
        {
            _persons = _mongoDbContext.GetDatabase().GetCollection<Person>(nameof(Person));
        }

        public async Task<Person> Create(Person person)
        {
            await _persons.InsertOneAsync(person).ConfigureAwait(false);

            return person;
        }

        public async Task<List<Person>> GetAll()
        {
            var result = await _persons.FindAsync(person => true).ConfigureAwait(false);
            
            return result.ToList();
        }
    }
}