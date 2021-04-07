
using System.Collections.Generic;
using System.Reflection;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NetSampleArch.Adapters.Kafka.IoC;
using NetSampleArch.Adapters.SQLServer.IoC;
using NetSampleArch.Adapters.SQLServer.Repositories;
using NetSampleArch.Adapters.SQLServer.Repositories.Interfaces;
using NetSampleArch.Adapters.SQLServer.UnitOfWork.Interfaces;
using NetSampleArch.Application.IoC;
using NetSampleArch.Infra.CrossCutting.Bus.Handlers.Events.DomainNotifications.Interfaces;
using NetSampleArch.Infra.CrossCutting.UnitOfWork;

namespace NetSampleArch.Infra.CrossCutting.IoC
{
    public static class InjectionManager
    {
        public static void Inject(this IServiceCollection services, IConfiguration configuration)
        {
            ConfigureCommomLayer(services, configuration);
            ConfigureApplicationCoreLayer(services);
            ConfigureAdaptersLayer(services, configuration);
            ConfigureMessageHandlerLayer(services, configuration);
            
        }

        private static void ConfigureCommomLayer(IServiceCollection services, IConfiguration configuration)
        {
            CommonInjectionManager.Inject(services, configuration);
            //CrossCutting.Messages.External.V1.IoC.CrossCuttingExternalMessagesBootstrapper.ConfigureCrossCuttingExternalMessages(services);
        }

        private static void ConfigureApplicationCoreLayer(IServiceCollection services)
        {
            ApplicationInjectionManager.Inject(services);
            //DomainBootstrapper.ConfigureDomainLayer(services);
        }

        private static void ConfigureAdaptersLayer(IServiceCollection services, IConfiguration config)
        {
            AdapterSqlServerInjectionManager.Inject(services);
            AdapterKafkaInjectionManager.Inject(services);

            services.AddScoped<IUnitOfWork>(serviceProvider => serviceProvider.GetService<ISqlServerUnitOfWork>());
            services.AddScoped<IPersonSqlServerRepository, PersonSqlServerRepository>();
        }

        private static void ConfigureMessageHandlerLayer(IServiceCollection services, IConfiguration config)
        {
            var assemblyCollection = new List<Assembly> {
                // Commom
                typeof(IDomainNotificationEventHandler).Assembly,
                // Kafka Layer
                //typeof(IAssetKafkaRepository).Assembly,

                //typeof(IPersonSqlServerRepository)
            };

            services.AddMediatR(config =>
                {
                    config.AsTransient();
                },
                assemblyCollection.ToArray()
            );
        }
    }
}
