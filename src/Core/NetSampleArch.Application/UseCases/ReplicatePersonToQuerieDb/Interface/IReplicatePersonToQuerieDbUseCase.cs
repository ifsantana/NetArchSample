using System.Threading;
using System.Threading.Tasks;
using NetSampleArch.Application.UseCases.Interfaces;
using NetSampleArch.Application.UseCases.ReplicatePersonToQuerieDb.Models;

namespace NetSampleArch.Application.UseCases.ReplicatePersonToQuerieDb.Interface
{
    public interface IReplicatePersonToQuerieDbUseCase : IUseCase
    {
         Task<bool> ExecuteAsync(AddedPersonUseCaseModel input, CancellationToken cancellationToken);
    }
}