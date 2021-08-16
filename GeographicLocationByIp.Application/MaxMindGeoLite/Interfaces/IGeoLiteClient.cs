using System.Threading.Tasks;
using GeographicLocationByIp.Domain.Entities;

namespace GeographicLocationByIp.Application.MaxMindGeoLite.Interfaces
{
    public interface IGeoLiteClient
    {
        Task<GeographicLocation> GetGeoInfo(string ipAddress);
        Task<GeographicLocation> UpdateGeoInfo(GeographicLocation geographicLocation);
    }
}