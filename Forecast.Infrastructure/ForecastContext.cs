using Forecast.Domain.Entities.Forecasts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Diagnostics;
using System.Net;
using System.Text.Json;

namespace Forecast.Infrastructure;

public class ForecastContext : DbContext
{
    private readonly IConfiguration _configuration;

    public ForecastContext(DbContextOptions<ForecastContext> options, IConfiguration configuration) : base(options)
    {
        _configuration = configuration;
    }

    public DbSet<ForecastDto> ForecastDto { get; set; }
    //public DbSet<HourlyDto> HourlyDto { get; set; }
    public DbSet<HourlyUnitsDto> HourlyUnitsDto { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(_configuration.GetConnectionString("ForecastContext"));
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ForecastDto>()
            .Property(e => e.Hourly)
            .HasConversion(
                  v => JsonSerializer.Serialize(v, new JsonSerializerOptions { PropertyNameCaseInsensitive = false }),
                  v => JsonSerializer.Deserialize<HourlyDto>(v, new JsonSerializerOptions { PropertyNameCaseInsensitive = false })
                  );
    }
}
