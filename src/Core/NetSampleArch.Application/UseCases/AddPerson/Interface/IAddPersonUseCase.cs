using NetSampleArch.Application.UseCases.AddPerson.Models;
using NetSampleArch.Application.UseCases.Interfaces;
using System.Threading;
using System.Threading.Tasks;

namespace NetSampleArch.Application.UseCases.AddPerson.Interface
{
    public interface IAddPersonUseCase : IUseCase
    {
        Task<bool> ExecuteAsync(AddPersonUseCaseModel input, CancellationToken cancellationToken);
    }
}