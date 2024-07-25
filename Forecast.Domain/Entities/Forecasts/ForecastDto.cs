#nullable disable
namespace Forecast.Domain.Entities.Forecasts;

public record ForecastDto
{
    public int Id { get; init; }
    public double Latitude { get; init; }
    public double Longitude { get; init; }
    public double Generationtime_Ms { get; init; }
    public int Utc_Off_initSeconds { get; init; }
    public string Timezone { get; init; }
    public string Timezone_Abbreviation { get; init; }
    public double Elevation { get; init; }
    public HourlyUnitsDto HourlyUnits { get; init; }
    public HourlyDto Hourly { get; init; }
}

