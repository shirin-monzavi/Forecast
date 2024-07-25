using Forecast.Domain.Contract;
using Forecast.Domain.Entities.Forecasts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forecast.Infrastructure.Repositories;

public class ForecastRepository : IForecastRepository
{
    public Task<ForecastDto> AddForecast(ForecastDto forecastDto)
    {
        throw new NotImplementedException();
    }

    public Task<ForecastDto> GetForecast()
    {
        throw new NotImplementedException();
    }
}
