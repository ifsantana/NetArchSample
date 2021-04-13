using Microsoft.Extensions.DependencyInjection;
using NetSampleArch.Adapters.EFCore.Models.Factories;
using NetSampleArch.Adapters.EFCore.Models.Factories.Interfaces;
using NetSampleArch.Adapters.EFCore.Repositories;
using NetSampleArch.Adapters.EFCore.Repositories.Interfaces;

namespace NetSampleArch.Adapters.EFCore.IoC
{
    public static class EFCoreInjectionManager
    {
        public static void Inject(IServiceCollection services)
        {
            services.AddScoped<IPersonModelRepository, PersonModelRepository>();

            services.AddScoped<IPersonModelFactory, PersonModelFactory>();
        }
    }
}
