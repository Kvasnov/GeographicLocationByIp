namespace GeographicLocationByIp.Application.Dto
{
    public class GeographicLocationDto
    {
        public string CountryNameRu {get; set;}
        public string CityNameRu {get; set;}
        public double? Latitude {get; set;}
        public double? Longitude {get; set;}
        public string IsoCode {get; set;}
        public long? GeoNameId {get; set;}
    }
}