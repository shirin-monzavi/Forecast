using Forecast.Domain.Entities.Forecasts;

namespace Forecast.Application.ContractServices;

public interface IForecastService
{
    Task<ForecastDto> GetForecast(CancellationToken cancellationToken);
}
