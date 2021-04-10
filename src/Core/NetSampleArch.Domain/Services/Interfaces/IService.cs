using NetSampleArch.Domain.Entities.Interfaces;

namespace NetSampleArch.Domain.Services.Interfaces
{
    public interface IService<TAggregationRoot>
        where TAggregationRoot : IAggregateRoot
    {
    }
}
