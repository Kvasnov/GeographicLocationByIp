using System.Linq;
using System.Threading.Tasks;
using GeographicLocationByIp.Application.Common.Interfaces.Repositories;
using GeographicLocationByIp.Application.MaxMindGeoLite.Interfaces;
using GeographicLocationByIp.ConsoleUpdater.Services;

namespace GeographicLocationByIp.Infrastructure.Services
{
    public class UpdateService : IUpdateService
    {
        public UpdateService(IGeoLiteClient client, IGeographicLocationRepository locationRepository)
        {
            this.client = client;
            this.locationRepository = locationRepository;
        }

        private readonly IGeoLiteClient client;
        private readonly IGeographicLocationRepository locationRepository;

        public async Task UpdateGeoData()
        {
            var allData = locationRepository.GetAll();

            if (allData == null)
                return;

            foreach (var date in allData.AsEnumerable().OrderBy(data => data.LastModified))
            {
                var newData = await client.UpdateGeoInfo(date);
                await locationRepository.Update(newData);
                await locationRepository.SaveAsync();
            }
        }
    }
}