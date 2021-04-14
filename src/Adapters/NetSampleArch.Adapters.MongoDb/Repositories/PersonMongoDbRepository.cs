using MongoDB.Driver;
using NetSampleArch.Adapters.MongoDb.DataContexts.Interfaces;
using NetSampleArch.Adapters.MongoDb.Models;
using NetSampleArch.Adapters.MongoDb.Models.Factories.Interfaces;
using NetSampleArch.Adapters.MongoDb.Repositories.Interfaces;
using NetSampleArch.Infra.CrossCutting.Configuration;
using Serilog;
using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace NetSampleArch.Adapters.MongoDb.Repositories
{
    public class PersonMongoDbRepository : IPersonMongoDbRepository
    {
        private readonly ILogger _logger;
        private readonly IMongoCollection<PersonDataModel> _persons;
        private readonly IPersonModelFactory _personDataModelFactory;

        public PersonMongoDbRepository(ILogger logger, IMongoDbDataContext mongoDbContext, Configuration configuration, IPersonModelFactory personDataModelFactory)
        {
            _logger = logger;
            _personDataModelFactory = personDataModelFactory;
            _persons = mongoDbContext.GetDatabase().GetCollection<PersonDataModel>(configuration.MongoConfiguration.CollectionName);
        }

        public async Task<bool> AddPersonAsync(Domain.Entities.Person.Person person, CancellationToken cancellationToken)
        {
            try
            {
                await _persons.InsertOneAsync(_personDataModelFactory.Create(person)).ConfigureAwait(false);

                _logger.Information($"User replicated on Query Database. {JsonSerializer.Serialize(person)}");
            }
            catch (Exception ex)
            {
                _logger.Error($"Error during query database persistence... {ex.Message}");
                return false;
                throw;
            }

            return true;
        }

        public async Task<List<PersonDataModel>> GetAll()
        {
            var result = await _persons.FindAsync(person => true).ConfigureAwait(false);
            
            return result.ToList();
        }
    }
}