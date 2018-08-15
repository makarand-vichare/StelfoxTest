using Microsoft.AspNetCore.Antiforgery;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using WebApi.Core2.Middleware;

public static class MiddlewareRunExtension
{
    public static void MiddlewareRun(this IApplicationBuilder app)
    {
        app.Run(async (context) =>
        {
            context.Response.StatusCode = 404;
            await context.Response.WriteAsync("Page not found");
        });
    }
}