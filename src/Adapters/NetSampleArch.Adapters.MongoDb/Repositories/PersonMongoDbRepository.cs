using MongoDB.Driver;
using NetSampleArch.Adapters.MongoDb.DataContexts.Interfaces;
using NetSampleArch.Adapters.MongoDb.Models;
using NetSampleArch.Adapters.MongoDb.Models.Factories.Interfaces;
using NetSampleArch.Adapters.MongoDb.Repositories.Interfaces;
using NetSampleArch.Infra.CrossCutting.Configuration;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace NetSampleArch.Adapters.MongoDb.Repositories
{
    public class PersonMongoDbRepository : IPersonMongoDbRepository
    {
        private readonly IMongoCollection<PersonDataModel> _persons;
        private readonly IMongoDbDataContext _mongoDbContext;
        private readonly IPersonModelFactory _personDataModelFactory;

        public PersonMongoDbRepository(IMongoDbDataContext _mongoDbContext, Configuration configuration, IPersonModelFactory personDataModelFactory)
        {
            _personDataModelFactory = personDataModelFactory;
            _persons = _mongoDbContext.GetDatabase().GetCollection<PersonDataModel>("Person");
        }

        public async Task<bool> AddPersonAsync(Domain.Entities.Person.Person person, CancellationToken cancellationToken)
        {
            try
            {
                await _persons.InsertOneAsync(_personDataModelFactory.Create(person)).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
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