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
    public class CountryController : BaseController
    {
        private readonly ICountryService countryService;

        public CountryController(ICountryService countryService)
        {
            this.countryService = countryService;
        }

        [Route("GetCountries")]
        [HttpGet]
        public IActionResult GetCountries()
        {
            try
            {
                var lookupList = countryService.GetLookup();
                return Request.CreateResponse(HttpStatusCode.OK, lookupList);
            }
            catch(Exception ex)
            {
                return Request.CreateErrorResponse(ex);
            }
        }
    }
}
