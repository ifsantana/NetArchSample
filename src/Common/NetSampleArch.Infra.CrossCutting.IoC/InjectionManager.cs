using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NetSampleArch.Adapters.EFCore.IoC;
using NetSampleArch.Adapters.MongoDb.IoC;
using NetSampleArch.Adapters.MongoDb.Repositories.Interfaces;
using NetSampleArch.Adapters.SQLServer.IoC;
using NetSampleArch.Adapters.SQLServer.Repositories.Interfaces;
using NetSampleArch.Adapters.SQLServer.UnitOfWork.Interfaces;
using NetSampleArch.Application.Handlers.Commands.Interfaces;
using NetSampleArch.Application.IoC;
using NetSampleArch.Domain.IoC;
using NetSampleArch.Domain.Repositories.Interfaces;
using NetSampleArch.Infra.CrossCutting.Bus.Handlers.Events.DomainNotifications.Interfaces;
using NetSampleArch.Infra.CrossCutting.UnitOfWork;
using System.Collections.Generic;
using System.Reflection;

namespace NetSampleArch.Infra.CrossCutting.IoC
{
    public static class InjectionManager
    {
        public static void Inject(this IServiceCollection services, IConfiguration configuration)
        { 

            var config = configuration.Get<NetSampleArch.Infra.CrossCutting.Configuration.Configuration>();

            services.AddSingleton(config);

            ConfigureCommomLayer(services, configuration);
            ConfigureApplicationCoreLayer(services);
            ConfigureAdaptersLayer(services, configuration);
            ConfigureMessageHandlerLayer(services);
        }

        private static void ConfigureCommomLayer(IServiceCollection services, IConfiguration configuration)
        {
            CommonInjectionManager.Inject(services, configuration);
            //CrossCutting.Messages.External.V1.IoC.CrossCuttingExternalMessagesBootstrapper.ConfigureCrossCuttingExternalMessages(services);
        }

        private static void ConfigureApplicationCoreLayer(IServiceCollection services)
        {
            ApplicationInjectionManager.Inject(services);
            DomainInjectionManager.Inject(services);
        }

        private static void ConfigureAdaptersLayer(IServiceCollection services, IConfiguration config)
        {
            EFCoreInjectionManager.Inject(services);
            AdapterSqlServerInjectionManager.Inject(services);
            //AdapterKafkaInjectionManager.Inject(services);
            MongoDbInjectionManager.Inject(services);

            services.AddScoped<IUnitOfWork>(serviceProvider => serviceProvider.GetService<ISqlServerUnitOfWork>());
            services.AddScoped<IPersonCommandRepository>(servicePRovider => servicePRovider.GetService<IPersonSqlServerRepository>());

            services.AddScoped<IPersonQueryRepository>(servicePRovider => servicePRovider.GetService<IPersonMongoDbRepository>());
        }

        private static void ConfigureMessageHandlerLayer(IServiceCollection services)
        {
            var assemblyCollection = new List<Assembly> {
                // Commom
                typeof(IDomainNotificationEventHandler).Assembly,
                
                // Application Layer
                typeof(IAddPersonCommandHandler).Assembly,

                // Kafka Layer
                //typeof(IAssetKafkaRepository).Assembly,

                typeof(IPersonSqlServerRepository).Assembly
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
