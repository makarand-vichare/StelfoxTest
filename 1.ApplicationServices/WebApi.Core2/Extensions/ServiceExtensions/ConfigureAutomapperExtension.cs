using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using Net.Core.IDomainServices.AutoMapper;

public static class ConfigureAutomapperExtension
{
    public static void AutomapperExtension(this IServiceCollection services)
    {
        var config = new AutoMapper.MapperConfiguration(cfg =>
        {
            cfg.AddProfile<ModelAutoMapperProfiler>();
        });

        IMapper mapper = config.CreateMapper();

        services.AddSingleton(config);
    }
}