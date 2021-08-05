using GeographicLocationByIp.Application.Dto;
using MediatR;

namespace GeographicLocationByIp.Application.Mediators.Queries
{
    public class GetGeoInfoQuery : IRequest<GeographicLocationDto>
    {
        public GetGeoInfoQuery(string ipAddress)
        {
            IpAddress = ipAddress;
        }

        public string IpAddress {get;}
    }
}