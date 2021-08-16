using System.Threading;
using System.Threading.Tasks;
using GeographicLocationByIp.ConsoleUpdater.Services;
using Microsoft.Extensions.Hosting;

namespace GeographicLocationByIp.ConsoleUpdater.Worker
{
    public sealed class UpdateLocationWorker : BackgroundService
    {
        public UpdateLocationWorker(IUpdateService updateService)
        {
            this.updateService = updateService;
        }

        private readonly IUpdateService updateService;

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            do
            {
                await updateService.UpdateGeoData();
                await Task.Delay(60000, stoppingToken);
            } while (!stoppingToken.IsCancellationRequested);
        }
    }
}