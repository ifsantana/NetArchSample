using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NetSampleArch.Infra.CrossCutting.Bus.Handlers.Events.DomainNotifications.Interfaces;
using NetSampleArch.Infra.CrossCutting.Bus.Handlers.Events.DomainNotifications.Models;
using NetSampleArch.Infra.CrossCutting.Bus.Interfaces;
using Serilog;
using Serilog.Events;
using Serilog.Exceptions;
using Serilog.Formatting.Compact;
using ConfigurationBuilder = NetSampleArch.Infra.CrossCutting.Configuration.ConfigurationBuilder;

namespace NetSampleArch.Infra.CrossCutting.IoC
{
    public static class CommonInjectionManager
    {
        private static string ELK_APPLICATION_PROPERTY_NAME = "NetArchSample";

        public static void Inject(IServiceCollection services, IConfiguration existingConfiguration) 
        {
            var configuration = existingConfiguration;

            if (configuration is null)
            {
                configuration = ConfigurationBuilder.GetConfigurationBuilder().Build();
                services.AddSingleton(configuration);
            }

            var config = configuration.Get<NetSampleArch.Infra.CrossCutting.Configuration.Configuration>();

            services.AddSingleton(config);

            Log.Logger = new LoggerConfiguration()
                      .Enrich.WithMachineName()
                      .Enrich.WithProcessId()
                      .Enrich.WithThreadId()
                      .Enrich.FromLogContext()
                      .Enrich.WithProperty(ELK_APPLICATION_PROPERTY_NAME, config.ElasticConfiguration.ApplicationName)
                      .Enrich.WithExceptionDetails()
                      .MinimumLevel.Is(LogEventLevel.Debug)
                      .WriteTo.Console(new RenderedCompactJsonFormatter())
                      .WriteTo.Seq($"http://{config.ElasticConfiguration.Uri}:{config.ElasticConfiguration.Port}/")
                      .CreateLogger();

            services.AddSingleton(Log.Logger);
            
            services.AddTransient<IRaisedDomainNotifications, RaisedDomainNotifications>();
            services.AddTransient<IBus, Bus.Bus>();
        }
    }
}