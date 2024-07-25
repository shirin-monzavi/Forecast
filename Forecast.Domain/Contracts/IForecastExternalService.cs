using Forecast.Domain.Entities.Commons;
using Forecast.Domain.Entities.Forecasts;

namespace Forecast.Domain.Contract;

public interface IForecastExternalService
{
    Task<ResponseBase<ForecastDto>> GetForecastData(CancellationToken cancellationToken);
}
