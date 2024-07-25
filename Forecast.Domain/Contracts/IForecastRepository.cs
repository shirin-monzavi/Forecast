using Forecast.Domain.Entities.Forecasts;

namespace Forecast.Domain.Contract;

public interface IForecastRepository
{
    Task<ForecastDto> GetForecast();

    Task<ForecastDto> AddForecast(ForecastDto forecastDto);
}
