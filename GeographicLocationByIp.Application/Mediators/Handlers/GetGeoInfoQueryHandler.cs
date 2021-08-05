using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using GeographicLocationByIp.Application.Common.Interfaces.Repositories;
using GeographicLocationByIp.Application.Dto;
using GeographicLocationByIp.Application.MaxMindGeoLite.Interfaces;
using GeographicLocationByIp.Application.Mediators.Queries;
using MediatR;

namespace GeographicLocationByIp.Application.Mediators.Handlers
{
    public class GetGeoInfoQueryHandler : IRequestHandler<GetGeoInfoQuery, GeographicLocationDto>
    {
        public GetGeoInfoQueryHandler(IGeoLiteClient client, IGeographicLocationRepository locationRepository, IMapper mapper)
        {
            this.client = client;
            this.locationRepository = locationRepository;
            this.mapper = mapper;
        }

        private readonly IGeoLiteClient client;
        private readonly IGeographicLocationRepository locationRepository;
        private readonly IMapper mapper;

        public async Task<GeographicLocationDto> Handle(GetGeoInfoQuery request, CancellationToken cancellationToken)
        {
            var existingGeoInfo = await locationRepository.FindByIpAsync(request.IpAddress);

            if (existingGeoInfo != null)
                return existingGeoInfo;

            var geoInfo = await client.GetGeoInfo(request.IpAddress);
            await locationRepository.Addasync(geoInfo);
            await locationRepository.SaveAsync();

            return mapper.Map<GeographicLocationDto>(geoInfo);
        }
    }
}