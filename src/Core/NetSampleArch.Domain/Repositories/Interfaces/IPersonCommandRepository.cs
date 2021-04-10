using NetSampleArch.Domain.Entities.Person;
using System.Threading;
using System.Threading.Tasks;

namespace NetSampleArch.Domain.Repositories.Interfaces
{
    public interface IPersonCommandRepository : IRepository<Person>
    {
        Task<bool> AddPersonAsync(Person person, CancellationToken cancellationToken);
    }
}
