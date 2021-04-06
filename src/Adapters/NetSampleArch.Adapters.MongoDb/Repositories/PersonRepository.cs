using System.Collections.Generic;
using System.Threading.Tasks;
using MongoDB.Driver;
using NetSampleArch.Adapters.MongoDb.Models;
using NetSampleArch.Adapters.MongoDb.Repositories.Interfaces;
using NetSampleArch.Infra.CrossCutting.Configuration;

namespace NetSampleArch.Adapters.MongoDb.Repositories
{
    public class PersonRepository : IPersonRepository
    {
        private readonly IMongoCollection<Person> _persons;

        public PersonRepository(Configuration configuration)
        {
            var client = new MongoClient(configuration.MongoConfiguration.ConnectionString);
            var database = client.GetDatabase(configuration.MongoConfiguration.DatabaseName);
            _persons = database.GetCollection<Person>(nameof(Person));
        }

        public async Task<List<Person>> GetAll()
        {
            var result = await _persons.FindAsync(person => true).ConfigureAwait(false);
            
            return result.ToList();
        }
    }
}