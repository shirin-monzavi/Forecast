#nullable disable
namespace Forecast.Domain.Entities.Forecasts;

public record HourlyDto
{
    public int Id { get; init; }
    public List<string> Time { get; init; }
    public List<double> Temperature_2m { get; init; }
    public List<int> Relativehumidity_2m { get; init; }
    public List<double> Windspeed_10m { get; init; }
}

