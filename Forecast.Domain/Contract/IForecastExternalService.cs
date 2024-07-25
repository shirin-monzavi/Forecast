using Forecast.Domain.Entities.Forecasts;

namespace Forecast.Domain.Contract;

public interface IForecastExternalService
{
    Task<ForecastDto> GetForecastData(CancellationToken cancellationToken);
}
