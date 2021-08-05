using AutoMapper;
using GeographicLocationByIp.Application.Dto;
using GeographicLocationByIp.Domain.Entities;

namespace GeographicLocationByIp.Application.Common.Helpers.AutoMapperProfiles
{
    public class GeographicLocationProfile : Profile
    {
        public GeographicLocationProfile()
        {
            CreateMap<GeographicLocation, GeographicLocationDto>();
        }
    }
}