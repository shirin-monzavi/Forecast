#nullable disable
namespace Forecast.Domain.Entities.Forecasts;

public record ForecastDto
{
    public int Id { get; init; }
    public double Latitude { get; init; }
    public double Longitude { get; init; }
    public double GenerationtimeMs { get; init; }
    public int UtcOffinitSeconds { get; init; }
    public string Timezone { get; init; }
    public string TimezoneAbbreviation { get; init; }
    public double Elevation { get; init; }
    public HourlyUnitsDto HourlyUnits { get; init; }
    public HourlyDto Hourly { get; init; }
}

