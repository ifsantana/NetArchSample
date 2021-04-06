using System.Collections.Generic;
using System.Threading.Tasks;
using NetSampleArch.Adapters.MongoDb.Models;

namespace NetSampleArch.Adapters.MongoDb.Repositories.Interfaces
{
    public interface IPersonRepository
    {
         Task<List<Person>> GetAll();
    }
}