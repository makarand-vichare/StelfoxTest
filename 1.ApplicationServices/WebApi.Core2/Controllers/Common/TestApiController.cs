﻿using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Net;
using Net.Core.Extensions;
using Net.Core.ViewModels.Identity.WebApi;

namespace WebApi.Core2.Controllers
{
    [ApiVersion("1.0")]
    [Produces("application/json")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class TestApiController : BaseController
    {
        // GET api/values
        [HttpGet]
        public IActionResult Get()
        {
            var result = new List<IdentityUserViewModel>() {
                new IdentityUserViewModel { Id = 1 , UserName ="User1" },
                 new IdentityUserViewModel { Id = 2 , UserName ="User2" },
                new IdentityUserViewModel { Id = 3 , UserName ="User3"},
                new IdentityUserViewModel { Id = 4 , UserName ="User4" }
           };
            if (result.Count > 0)
            {
                return Request.CreateResponse(HttpStatusCode.OK, new { result, message = "found records" });
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, "No Record Found");
            }
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
