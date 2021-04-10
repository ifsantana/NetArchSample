using NetSampleArch.Domain.Entities.Person.Entries;
using NetSampleArch.Domain.Services.Interfaces;
using System.Threading;
using System.Threading.Tasks;

namespace NetSampleArch.Domain.Services
{
    public class PersonService : BaseService, IPersonService
    {
        
        public PersonService()
        {

        }

        public Task<(bool success, Person)> AddPersonToCommandDb(PersonEntry personEntry, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }

        public Task<(bool success, Person)> AddPersonToQuerieDb(PersonEntry personEntry, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }
    }
}
