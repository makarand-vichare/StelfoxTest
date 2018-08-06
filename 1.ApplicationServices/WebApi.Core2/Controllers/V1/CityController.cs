using Microsoft.AspNetCore.Mvc;
using System;
using System.Net;
using Net.Core.Extensions;
using Net.Core.IDomainServices.Services;

namespace WebApi.Core2.Controllers.V1
{
    [ApiVersion("1.0")]
    [Produces("application/json")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class CityController : BaseController
    {
        private readonly ICityService cityService;

        public CityController(ICityService cityService)
        {
            this.cityService = cityService;
        }

        [Route("GetCities")]
        [HttpGet]
        public IActionResult GetCities(long countryId)
        {
            try
            {
                var lookupList = cityService.GetLookup(countryId);
                return Request.CreateResponse(HttpStatusCode.OK, lookupList);
            }
            catch(Exception ex)
            {
                return Request.CreateErrorResponse(ex);
            }
        }
    }
}
