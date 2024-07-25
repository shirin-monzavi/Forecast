using Flurl;
using Flurl.Http;
using Forecast.Domain.Contract;
using Forecast.Domain.Entities.Commons;
using Forecast.Domain.Entities.Forecasts;

namespace Forecast.Infrastructure.ExternalServices;

public class ForecastExternalService : IForecastExternalService
{
    public async Task<ResponseBase<ForecastDto>> GetForecastData(CancellationToken cancellationToken)
    {
        try
        {
            var result = await "http://api.open-meteo.com/v1"
                                               .AppendPathSegment("forecast")
                                               .AppendQueryParam("latitude=52.52")
                                               .AppendQueryParam("longitude=13.41")
                                               .AppendQueryParam("hourly=temperature_2m,relativehumidity_2m,windspeed_10m")
                                               .GetJsonAsync<ForecastDto>(cancellationToken: cancellationToken)
                                               .ConfigureAwait(false);

            return new ResponseBase<ForecastDto>()
            {
                 Data = result,
                 Error=true,
            };
        }
        catch (FlurlHttpException ex)
        {
            return new ResponseBase<ForecastDto>()
            {
                Reason=ex.Message
            };
        }
    }
}
