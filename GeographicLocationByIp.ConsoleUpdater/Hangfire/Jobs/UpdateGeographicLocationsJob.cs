using System;
using System.Threading;
using System.Threading.Tasks;
using GeographicLocationByIp.ConsoleUpdater.Hangfire.Interfaces;
using GeographicLocationByIp.ConsoleUpdater.Services;

namespace GeographicLocationByIp.ConsoleUpdater.Hangfire.Jobs
{
    public class UpdateGeographicLocationsJob : IUpdateGeographicLocationsJob
    {
        public UpdateGeographicLocationsJob(IUpdateService updateService)
        {
            this.updateService = updateService;
        }

        private readonly IUpdateService updateService;

        public async Task Run(CancellationToken cancellationToken)
        {
            Console.WriteLine("Server started");
            await updateService.UpdateGeoData();
            Console.WriteLine("Server finished");
        }
    }
}