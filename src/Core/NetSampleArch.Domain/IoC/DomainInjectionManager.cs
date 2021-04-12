using Microsoft.Extensions.DependencyInjection;
using NetSampleArch.Domain.Services;
using NetSampleArch.Domain.Services.Interfaces;

namespace NetSampleArch.Domain.IoC
{
    public static class DomainInjectionManager
    {
        public static void Inject(IServiceCollection services)
        {
            //Services
            services.AddScoped<IPersonService, PersonService>();
        }
    }
}
