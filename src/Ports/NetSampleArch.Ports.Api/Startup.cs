using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using NetSampleArch.Infra.CrossCutting.Configuration;
using NetSampleArch.Infra.CrossCutting.IoC;
using NetSampleArch.Ports.Consumers.Consumers.Commands;
using NetSampleArch.Ports.Consumers.Interfaces.Commands;
using NetSampleArch.Ports.Consumers.Workers;
using Serilog;
using System;

namespace NetSampleArch.Ports.Api
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            ConfigureKafkaConsumersAndWorker(services);
            services.Inject(Configuration);
            services.AddControllers();
            services.AddHealthChecks();
            services.AddApiVersioning(
                options =>
                {
                    options.ReportApiVersions = true;
                    options.AssumeDefaultVersionWhenUnspecified = true;
                });
            services.AddRouting(options => options.LowercaseUrls = true);
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "NetSampleArch", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "NetSampleArch v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapHealthChecks("/health");
            });
        }

        private void ConfigureKafkaConsumersAndWorker(IServiceCollection services)
        {
            services.AddScoped<IReplicateCreatedPersonCommandConsumer, ReplicateCreatedPersonCommandConsumer>();

            services.AddHostedService(serviceProvider =>
            {
                return new KafkaWorker(
                    serviceProvider.GetService<ILogger>(),
                    serviceProvider,
                    serviceProvider.GetService<Configuration>(),
                    new KafkaWorkerConfig(new (string ConsumerGroupId, string TopicName, Type Type)[] {
                        ("Person", "dbserver1.dbo.Person", typeof(IReplicateCreatedPersonCommandConsumer)),
                    })
                );
            });

        }
    }
}
