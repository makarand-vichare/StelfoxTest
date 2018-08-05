using Microsoft.Extensions.DependencyInjection;
using StructureMap;
using System;
using WebApi.Core2.StructureMap;

public static class ConfigureIocExtension
{
    public static IServiceProvider ConfigureIoc(this IServiceCollection services)
    {
        var container = StructureMapConfig.RegisterComponents();

        container.Configure(config =>
        {
            //Populate the container using the service collection
            //config.Scan(_ =>
            //{
            //    _.AssemblyContainingType(typeof(Startup));
            //    _.AssembliesFromPath(".\\bin\\Debug\\netcoreapp2.0");
            //    _.WithDefaultConventions();
            //});
            //config.For<ICountryService>().Use<CountryService>();
            //config.For<ICountryRepository>().Use<CountryRepository>();
            config.Populate(services);
        });
        return container.GetInstance<IServiceProvider>();
    }
}