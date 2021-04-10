using NetSampleArch.Domain.Entities.Person.Entries;
using System.Threading;
using System.Threading.Tasks;

namespace NetSampleArch.Domain.Services.Interfaces
{
    public interface IPersonService : IService<Person>
    { 
    
        Task<(bool success, Person)> AddPersonToCommandDb(PersonEntry personEntry, CancellationToken cancellationToken);
        Task<(bool success, Person)> AddPersonToQuerieDb(PersonEntry personEntry, CancellationToken cancellationToken);
    }
}
