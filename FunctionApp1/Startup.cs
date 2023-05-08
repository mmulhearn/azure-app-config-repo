using Azure.Identity;
using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.AzureAppConfiguration;
using System;

[assembly: FunctionsStartup(typeof(FunctionApp1.Startup))]

namespace FunctionApp1
{
    internal class Startup : FunctionsStartup
    {
        public static IConfiguration Config { get; private set; }

        public override void ConfigureAppConfiguration(IFunctionsConfigurationBuilder builder)
        {
            var config = builder.ConfigurationBuilder.Build();

            var azureConfigUri = config["azureConfigUri"];

            builder.ConfigurationBuilder
                .AddAzureAppConfiguration(options =>
                {
                    options
                        .Select("common/", LabelFilter.Null)
                        .ConfigureRefresh(refresh =>
                        {
                            refresh.Register("sentinel");
                        })
                        .Connect(new Uri(azureConfigUri), new DefaultAzureCredential());
                });

            Config = builder.ConfigurationBuilder.Build();
        }

        public override void Configure(IFunctionsHostBuilder builder)
        {
            
        }
    }
}
