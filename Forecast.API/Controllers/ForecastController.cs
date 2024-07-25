using Forecast.Application.ContractServices;
using Forecast.Domain.Entities.Forecasts;
using Microsoft.AspNetCore.Mvc;

namespace Forecast.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ForecastController : ControllerBase
{
    #region Const
    private const int OperationTimeout = 5000;
    #endregion

    #region Field
    private readonly IForecastService _forecastService;
    private readonly CancellationTokenSource cancellationTokenSource = new();
    #endregion

    /// <summary>
    /// ForecastController
    /// </summary>
    /// <param name="forecastService"></param>
    public ForecastController(IForecastService forecastService)
    {
        _forecastService = forecastService;
    }

    /// <summary>
    /// Get
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    public async Task<ForecastDto> Get()
    {
        try
        {
            cancellationTokenSource.CancelAfter(OperationTimeout);

            return await _forecastService.GetForecast(cancellationTokenSource.Token);
        }
        catch (Exception ex)
        {
            throw;
        }
        finally
        {
            cancellationTokenSource.Dispose();
        }
    }
}
