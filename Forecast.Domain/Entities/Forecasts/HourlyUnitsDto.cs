#nullable disable
namespace Forecast.Domain.Entities.Forecasts;

public record HourlyUnitsDto
{
    public int Id { get; init; }
    public string Time { get; init; }
    public string Temperature2m { get; init; }
    public string Relativehumidity2m { get; init; }
    public string Windspeed10m { get; init; }
}

