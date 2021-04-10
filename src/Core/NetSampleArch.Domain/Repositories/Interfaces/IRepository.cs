using NetSampleArch.Domain.Entities.Interfaces;

namespace NetSampleArch.Domain.Repositories.Interfaces
{
    public interface IRepository<TAggregationRoot> where TAggregationRoot : IAggregateRoot
    {
    }
}
