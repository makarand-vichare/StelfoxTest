using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Core2.Middleware
{
    public class CustomExceptionMiddleware
    {
        //constructor and service injection

        public async Task Invoke(HttpContext httpContext)
        {
            //try
            //{
            //    await _next(httpContext);
            //}
            //catch (Exception ex)
            //{
            //    _logger.LogError("Unhandled exception ...", ex);
            //    await HandleExceptionAsync(httpContext, ex);
            //}
        }

        //additional methods
    }
}
