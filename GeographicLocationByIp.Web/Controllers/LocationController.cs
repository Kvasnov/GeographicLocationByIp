using System.Threading.Tasks;
using GeographicLocationByIp.Application.Dto;
using GeographicLocationByIp.Application.Mediators.Queries;
using Microsoft.AspNetCore.Mvc;

namespace GeographicLocationByIp.Web.Controllers
{
    public class LocationController : ApiController
    {
        [HttpGet("GetGeoInfo/{ipAddress}")]
        public async Task<ActionResult<GeographicLocationDto>> Get(string ipAddress)
        {
            var query = new GetGeoInfoQuery(ipAddress);
            var result = await Mediator.Send(query);

            return result;
        }
    }
}