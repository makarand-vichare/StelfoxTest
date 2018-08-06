using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Localization.Routing;
using Microsoft.AspNetCore.Routing;
using System.Globalization;

public static class MiddlewareMvcRoutingExtension
{
    public static void ConfigureCustomMvcRouting(this IApplicationBuilder app)
    {

        app.UseRouter(routes =>
        {
            //api/{culture=en}/{*mvcRoute}
            routes.MapMiddlewareRoute("api/{culture=en}/{*mvcRoute}", subApp =>
            {
                var supportedCultures = new[]
                {
                        new CultureInfo("en"),
                        new CultureInfo("ru"),
                    };

                var localizationOptions = new RequestLocalizationOptions
                {
                    DefaultRequestCulture = new RequestCulture("en"),
                    SupportedCultures = supportedCultures,
                    SupportedUICultures = supportedCultures
                };

                var requestProvider = new RouteDataRequestCultureProvider();

                localizationOptions.RequestCultureProviders.Insert(0, requestProvider);

                subApp.UseRequestLocalization(localizationOptions);

                subApp.UseMvcWithDefaultRoute();

            });
        });

    }
}