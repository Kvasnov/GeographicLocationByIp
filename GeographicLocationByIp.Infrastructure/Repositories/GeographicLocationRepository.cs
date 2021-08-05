using System.Threading.Tasks;
using AutoMapper;
using GeographicLocationByIp.Application.Common.Interfaces.Repositories;
using GeographicLocationByIp.Application.Dto;
using GeographicLocationByIp.Domain.Entities;
using GeographicLocationByIp.Infrastructure.Repositories.Common;
using Microsoft.EntityFrameworkCore;

namespace GeographicLocationByIp.Infrastructure.Repositories
{
    public sealed class GeographicLocationRepository : EntityRepository<GeographicLocation>, IGeographicLocationRepository
    {
        public GeographicLocationRepository(IMapper mapper, DatabaseContext.DatabaseContext context) : base(context)
        {
            this.mapper = mapper;
        }

        private readonly IMapper mapper;

        public async Task<GeographicLocationDto> FindByIp(string ipAddress)
        {
            var geoInfo = await Context.GeographicLocations.SingleOrDefaultAsync(location => string.Equals(location.IpAddress, ipAddress));

            return mapper.Map<GeographicLocationDto>(geoInfo);
        }
    }
}