#nullable disable
namespace Forecast.Domain.Entities.Forecasts;

public record HourlyDto
{
    public int Id { get; init; }
    public List<string> Time { get; init; }
    public List<double> Temperature2m { get; init; }
    public List<int> Relativehumidity2m { get; init; }
    public List<double> Windspeed10m { get; init; }
}

