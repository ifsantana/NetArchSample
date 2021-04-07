using System.Threading.Tasks;
using NetSampleArch.Adapters.SQLServer.Models;

namespace NetSampleArch.Adapters.SQLServer.Repositories.Interfaces
{
    public interface IPersonSqlServerRepository
    {
        Task<Person> AddAsync(Person person);
    }
}