using Microsoft.Extensions.DependencyInjection;
using Net.Core.Infrastructure;
using Net.Core.Infrastructure.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

    public static class ConfigureLoggerExtension
    {
        public static void ConfigureLoggerService(this IServiceCollection services)
        {
            services.AddSingleton<ILoggerManager, LoggerManager>();
        }
    }
