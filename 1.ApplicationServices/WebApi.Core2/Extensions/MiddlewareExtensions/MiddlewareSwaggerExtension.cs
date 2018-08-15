using Microsoft.AspNetCore.Antiforgery;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using NJsonSchema;
using NSwag.AspNetCore;
using System.Reflection;
using WebApi.Core2;
using WebApi.Core2.Middleware;

public static class MiddlewareSwaggerExtension
{
    public static void MiddlewareSwagger(this IApplicationBuilder app, IHostingEnvironment env)
    {
        if (env.IsDevelopment())
        {
            app.UseSwaggerUi(typeof(Startup).GetTypeInfo().Assembly, settings =>
            {
                settings.GeneratorSettings.DefaultPropertyNameHandling = PropertyNameHandling.CamelCase;
            });
        }
    }
}