using System.Collections.Generic;
using System.Threading.Tasks;
using NetSampleArch.Adapters.MongoDb.Models;

namespace NetSampleArch.Adapters.MongoDb.Repositories.Interfaces
{
    public interface IPersonMongoDbRepository
    {
         Task<List<Person>> GetAll();
         Task<Person> Create(Person person);
    }
}