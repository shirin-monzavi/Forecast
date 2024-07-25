using Forecast.Domain.Entities.Forecasts;

namespace Forecast.Domain.Contract;

public interface IForecastRepository:IDisposable
{
    Task<ForecastDto?> GetForecast(CancellationToken cancellationToken);

    Task<ForecastDto> AddForecast(ForecastDto forecastDto, CancellationToken cancellationToken);
}
