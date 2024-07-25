using Forecast.Application.ContractServices;
using Forecast.Application.ImplementServices;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forecast.Application;

public static class ConfigureService
{
    public  static IServiceCollection AddApplicationService(this IServiceCollection services)
    {
        services.AddScoped<IForecastService, ForecastService>();

        return services;
    }
}
