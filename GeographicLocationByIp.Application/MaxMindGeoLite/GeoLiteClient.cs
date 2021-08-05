using System.Threading.Tasks;
using GeographicLocationByIp.Application.MaxMindGeoLite.Interfaces;
using GeographicLocationByIp.Application.MaxMindGeoLite.Settings;
using GeographicLocationByIp.Domain.Entities;
using MaxMind.GeoIP2;
using Microsoft.Extensions.Options;

namespace GeographicLocationByIp.Application.MaxMindGeoLite
{
    public sealed class GeoLiteClient : IGeoLiteClient
    {
        public GeoLiteClient(IOptions<GeoLiteClientSettings> geoLiteClientSettings)
        {
            this.geoLiteClientSettings = geoLiteClientSettings;
        }

        private readonly IOptions<GeoLiteClientSettings> geoLiteClientSettings;

        public async Task<GeographicLocation> GetGeoInfo(string ipAddress)
        {
            using (var client = new WebServiceClient(geoLiteClientSettings.Value.AccountId, geoLiteClientSettings.Value.LicenseKey, host: "geolite.info"))
            {
                var response = await client.CityAsync(ipAddress);

                return new GeographicLocation
                       {
                           IpAddress = ipAddress,
                           CountryName = response.Country.Name,
                           CountryNameRu = response.Country.Names[ "ru" ],
                           CityName = response.City.Name,
                           CityNameRu = response.City.Names[ "ru" ],
                           Latitude = response.Location.Latitude,
                           Longitude = response.Location.Longitude,
                           IsoCode = response.Country.IsoCode,
                           GeoNameId = response.Continent.GeoNameId
                       };
            }
        }
    }
}