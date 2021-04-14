using System.Collections.Generic;
using System.Threading.Tasks;
using NetSampleArch.Adapters.MongoDb.Models;
using NetSampleArch.Domain.Repositories.Interfaces;

namespace NetSampleArch.Adapters.MongoDb.Repositories.Interfaces
{
    public interface IPersonMongoDbRepository : IPersonQueryRepository
    {
         Task<List<PersonDataModel>> GetAll();
    }
}