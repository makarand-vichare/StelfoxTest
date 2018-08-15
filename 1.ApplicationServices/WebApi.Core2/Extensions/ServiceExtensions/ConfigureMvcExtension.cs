using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.Extensions.DependencyInjection;
using WebApi.Core2.ContentNegotiationFormatters;

public static class ConfigureMvcExtension
{
    public static void ConfigureMvc(this IServiceCollection services)
    {
        services.AddMvc(config =>
        {
            // Add XML Content Negotiation
            config.RespectBrowserAcceptHeader = true;
            config.InputFormatters.Add(new XmlSerializerInputFormatter());
            config.OutputFormatters.Add(new XmlSerializerOutputFormatter());
            config.OutputFormatters.Add(new CsvOutputFormatter());
        });
    }
}