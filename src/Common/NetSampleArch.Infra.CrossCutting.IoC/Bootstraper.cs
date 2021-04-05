
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace NetSampleArch.Infra.CrossCutting.IoC
{
    public static class Bootstraper
    {
        public static void Inject(this IServiceCollection services, IConfiguration configuration)
        {
            //services.AddMediatR(typeof(Startup));
        }
    }
}
