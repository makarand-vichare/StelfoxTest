using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using WebApi.Core2.Middleware;

public static class MiddlewareCustomExceptionExtension
{
    public static void MiddlewareCustomException(this IApplicationBuilder app, IHostingEnvironment env)
    {
        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
        }
        app.UseMiddleware<CustomExceptionMiddleware>();
    }
}