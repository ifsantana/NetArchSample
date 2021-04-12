using Microsoft.Extensions.DependencyInjection;
using NetSampleArch.Application.Handlers.Commands;
using NetSampleArch.Application.Handlers.Commands.Interfaces;
using NetSampleArch.Application.UseCases.AddPerson;
using NetSampleArch.Application.UseCases.AddPerson.Interface;
using NetSampleArch.Application.UseCases.ReplicatePersonToQuerieDb;
using NetSampleArch.Application.UseCases.ReplicatePersonToQuerieDb.Interface;

namespace NetSampleArch.Application.IoC
{
    public static class ApplicationInjectionManager
    {
        public static void Inject(IServiceCollection services)
        {
            //Commands
            services.AddScoped<IReplicateCreatedPersonCommandHandler, ReplicateCreatedPersonCommandHandler>();
            services.AddScoped<IAddPersonCommandHandler, AddPersonCommandHandler>();

            //Use Cases
            services.AddScoped<IReplicatePersonToQuerieDbUseCase, ReplicatePersonToQuerieDbUseCase>();
            services.AddScoped<IAddPersonUseCase, AddPersonUseCase>();
        }
    }
}