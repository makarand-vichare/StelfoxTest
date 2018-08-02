﻿using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

public static class ConfigureIISIntegrationExtension
{
    public static void ConfigureIISIntegration(this IServiceCollection services)
    {
        services.Configure<IISOptions>(options =>
        {

        });
    }
}