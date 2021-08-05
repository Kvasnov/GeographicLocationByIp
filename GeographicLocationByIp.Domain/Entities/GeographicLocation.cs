using GeographicLocationByIp.Domain.Entities.Common;

namespace GeographicLocationByIp.Domain.Entities
{
    public class GeographicLocation : BaseEntity
    {
        public string IpAddress {get; set;}
        public string CountryName { get; set; }
        public string CountryNameRu { get; set; }
        public string CityName { get; set; }
        public string CityNameRu { get; set; }
        public double? Latitude {get; set;}
        public double? Longitude {get; set;}
        public string IsoCode {get; set;}
        public long? GeoNameId {get; set;}
    }
}