using Forecast.Application.ContractServices;
using Forecast.Domain.Contract;
using Forecast.Domain.Entities.Forecasts;

namespace Forecast.Application.ImplementServices;

public class ForecastService : IForecastService
{
    #region Field
    private readonly IForecastExternalService _forecastExternalService;
    private readonly IForecastRepository _forecastRepository;
    #endregion

    public ForecastService(IForecastExternalService forecastExternalService,
                           IForecastRepository forecastRepository)
    {
        _forecastExternalService = forecastExternalService;
        _forecastRepository = forecastRepository;
    }

    public async Task<ForecastDto?> GetForecast(CancellationToken cancellationToken)
    {
        var result = await _forecastExternalService.GetForecastData(cancellationToken).ConfigureAwait(false);

        if (result.Error)
        {
            await _forecastRepository.AddForecast(result.Data!).ConfigureAwait(false);
            return result.Data!;
        }

        var forecastData = await _forecastRepository.GetForecast(cancellationToken).ConfigureAwait(false);
        if(forecastData is null)
        {
            return null;
        }

        return forecastData;
    }
}
