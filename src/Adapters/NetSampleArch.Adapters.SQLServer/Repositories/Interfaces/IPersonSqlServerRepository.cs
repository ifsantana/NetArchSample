using NetSampleArch.Domain.Entities.Person;
using NetSampleArch.Domain.Repositories.Interfaces;

namespace NetSampleArch.Adapters.SQLServer.Repositories.Interfaces
{
    public interface IPersonSqlServerRepository : ISqlServerRepository<Person>, IPersonCommandRepository
    {
    }
}