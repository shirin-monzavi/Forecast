﻿using Forecast.Domain.Entities.Forecasts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Diagnostics;
using System.Net;
using System.Text.Json;

namespace Forecast.Infrastructure;

public class ForecastContext : DbContext
{
    #region Field
    private readonly IConfiguration _configuration;
    #endregion

    public ForecastContext(DbContextOptions<ForecastContext> options, IConfiguration configuration) : base(options)
    {
        _configuration = configuration;
    }

    #region Protected
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(_configuration.GetConnectionString("ForecastContext"));
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ForecastDto>(x =>
        {
            x.HasOne(h=>h.HourlyUnits)
             .WithOne(f=>f.Forecast)
             .HasForeignKey<HourlyUnitsDto>(h=>h.ForecastId);

            x.Property(e => e.Hourly)
             .HasConversion(
                          v => JsonSerializer.Serialize(v, new JsonSerializerOptions { PropertyNameCaseInsensitive = false }),
                          v => JsonSerializer.Deserialize<HourlyDto>(v, new JsonSerializerOptions { PropertyNameCaseInsensitive = false }) ?? new HourlyDto()
                          );
        });
    }
    #endregion

    #region Properties
    public DbSet<ForecastDto> Forecast{ get; set; }

    public DbSet<HourlyUnitsDto> HourlyUnits { get; set; }
    #endregion
}
