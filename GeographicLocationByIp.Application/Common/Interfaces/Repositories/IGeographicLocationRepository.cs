using System.Threading.Tasks;
using GeographicLocationByIp.Application.Common.Interfaces.Repositories.Common;
using GeographicLocationByIp.Application.Dto;
using GeographicLocationByIp.Domain.Entities;

namespace GeographicLocationByIp.Application.Common.Interfaces.Repositories
{
    public interface IGeographicLocationRepository : IEntityRepository<GeographicLocation>
    {
        Task<GeographicLocationDto> FindByIpAsync(string ipAddress);
    }
}