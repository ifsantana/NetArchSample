using NetSampleArch.Adapters.EFCore.Models;
using System.Threading;
using System.Threading.Tasks;

namespace NetSampleArch.Adapters.EFCore.Repositories.Interfaces
{
    public interface IPersonModelRepository : IDataModelRepository<PersonDataModel>
    {
        Task<PersonDataModel> AddPersonAsync(PersonDataModel dataModel, CancellationToken cancellationToken);
    }
}
