using Microsoft.AspNetCore.Antiforgery;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using WebApi.Core2.Middleware;

public static class MiddlewareAntiforgeryExtension
{
    public static void MiddlewareAntiforgery(this IApplicationBuilder app, IAntiforgery antiforgery)
    {
        app.Use(next => context =>
        {
            string path = context.Request.Path.Value;
            var tokens = antiforgery.GetAndStoreTokens(context);
            context.Response.Cookies.Append("XSRF-TOKEN", tokens.RequestToken,
                 new CookieOptions()
                 {
                     HttpOnly = false,
                     Secure = true
                 }); // set false if not using SSL
            return next(context);
        });
    }
}