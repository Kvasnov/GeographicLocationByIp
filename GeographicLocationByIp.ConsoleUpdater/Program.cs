using System.IO;
using GeographicLocationByIp.Application;
using GeographicLocationByIp.ConsoleUpdater.Worker;
using GeographicLocationByIp.Infrastructure;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace GeographicLocationByIp.ConsoleUpdater
{
    internal class Program
    {
        private static IConfigurationRoot configuration;

        private static void Main(string[] args)
        {
            var host = CreateHostBuilder();
            host.Build().Run();
        }

        private static IHostBuilder CreateHostBuilder()
        {
            return Host.CreateDefaultBuilder().
                        ConfigureAppConfiguration((contex, builder) =>
                                                  {
                                                      builder.SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", false, true);
                                                      configuration = builder.Build();
                                                  }).
                        ConfigureServices((hostContext, services) =>
                                          {
                                              services.AddInfrastructure(configuration);
                                              services.AddApplication(configuration);
                                              services.AddHostedService<UpdateLocationWorker>();
                                          });
        }

        private static void BuildConfig(IConfigurationBuilder builder)
        {
            builder.SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", false, true);
        }
    }
}