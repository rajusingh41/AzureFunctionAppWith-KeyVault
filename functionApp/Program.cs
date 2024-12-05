using Azure.Identity;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Windows.Forms.Design;

namespace functionApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            FunctionsDebugger.Enable();

            var host = new HostBuilder()
                 .ConfigureAppConfiguration((context, config) =>
                 {
                     // Get Key Vault URL
                     config.SetBasePath(Environment.CurrentDirectory)
                                    .AddJsonFile("local.settings.json", optional: true, reloadOnChange: true)
                                    .AddEnvironmentVariables();
                     string keyVaultName = "devKeyVaultDemo";
                     var keyVaultEndpoint = $"https://{keyVaultName}.vault.azure.net/";
                     config.AddAzureKeyVault(new Uri(keyVaultEndpoint),
                        new DefaultAzureCredential());
                 })
                .ConfigureFunctionsWorkerDefaults()
                .ConfigureServices((context, services) =>
                {
                    // Register your services

                    var apiConfig = context.Configuration.GetSection(nameof(ApiConfig)).Get<ApiConfig>();
                    services.AddSingleton(apiConfig);
                })
                //.ConfigureServices(DependencyRegistration.ConfigureStaticDependencies)
                //.ConfigureServices(DependencyRegistration.ConfigureProductionDependencies)

                .Build();

            host.Run();
        }
    }
}
