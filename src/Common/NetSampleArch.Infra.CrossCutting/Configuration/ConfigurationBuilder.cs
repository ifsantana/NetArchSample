using System;
using System.IO;
using Microsoft.Extensions.Configuration;

namespace NetSampleArch.Infra.CrossCutting.Configuration
{
   public static class ConfigurationBuilder
    {
        public static IConfigurationBuilder GetConfigurationBuilder(string environmentName = null)
        {
            var configurationBuilder = new Microsoft.Extensions.Configuration.ConfigurationBuilder()
                .AddJsonFile(Path.Combine(AppContext.BaseDirectory, "appsettings.json"))
                .AddUserSecrets("NetSampleArch.Ports.Api")
                .AddEnvironmentVariables();

            if (!string.IsNullOrWhiteSpace(environmentName))
                configurationBuilder = configurationBuilder.AddJsonFile(Path.Combine(AppContext.BaseDirectory, $"appsettings.{environmentName}.json"), true);

            return configurationBuilder;
        }
    }
}