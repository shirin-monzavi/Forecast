using Forecast.Application.ContractServices;
using Forecast.Domain.Contract;
using Forecast.Domain.Entities.Forecasts;

namespace Forecast.Application.ImplementServices;

public class ForecastService : IForecastService
{
    #region Field
    private readonly IForecastExternalService _forecastExternalService;
    #endregion

    public ForecastService(IForecastExternalService forecastExternalService)
    {
        _forecastExternalService = forecastExternalService;
    }

    public async Task<ForecastDto> GetForecast(CancellationToken cancellationToken)
    {
        //Simulation for delay
       //await Task.Delay(6000);

      return await _forecastExternalService.GetForecastData(cancellationToken).ConfigureAwait(false);
    }
}
