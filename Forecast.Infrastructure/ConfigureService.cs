using Forecast.Domain.Contract;
using Forecast.Infrastructure.ExternalServices;
using Forecast.Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forecast.Infrastructure;

public static class ConfigureService
{
    public static IServiceCollection AddInfrastructureService(this IServiceCollection services)
    {
        services.AddScoped<IForecastExternalService, ForecastExternalService>();
        services.AddScoped<IForecastRepository, ForecastRepository>();

        return services;
    }
}
