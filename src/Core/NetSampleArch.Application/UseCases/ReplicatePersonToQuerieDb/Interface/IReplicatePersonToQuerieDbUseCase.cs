using System.Threading.Tasks;
using NetSampleArch.Application.UseCases.Interfaces;

namespace NetSampleArch.Application.UseCases.ReplicatePersonToQuerieDb.Interface
{
    public interface IReplicatePersonToQuerieDbUseCase : IUseCase
    {
         Task<bool> ExecuteAsync();
    }
}