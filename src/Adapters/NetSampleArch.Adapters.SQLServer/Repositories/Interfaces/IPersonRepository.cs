using System.Threading.Tasks;
using NetSampleArch.Adapters.SQLServer.Models;

namespace NetSampleArch.Adapters.SQLServer.Repositories.Interfaces
{
    public interface IPersonRepository
    {
        Task<Person> AddAsync(Person person);
    }
}