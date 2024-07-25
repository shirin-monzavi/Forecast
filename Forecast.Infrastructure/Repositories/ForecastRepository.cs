using Forecast.Domain.Contract;
using Forecast.Domain.Entities.Forecasts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forecast.Infrastructure.Repositories;

public class ForecastRepository : IForecastRepository
{
    #region Field
    private readonly ForecastContext _context;
    #endregion

    public ForecastRepository(ForecastContext context)
    {
        _context = context;
    }

    #region Public
    public async Task<ForecastDto> AddForecast(ForecastDto forecastDto, CancellationToken cancellationToken)
    {
        try
        {
            await _context.Forecast.AddAsync(forecastDto, cancellationToken).ConfigureAwait(false);
            await _context.HourlyUnits.AddAsync(forecastDto.HourlyUnits, cancellationToken).ConfigureAwait(false);

            await _context.SaveChangesAsync(cancellationToken);

            return forecastDto;
        }
        catch (Exception ex)
        {
            throw;
        }
    }

    public async Task<ForecastDto?> GetForecast(CancellationToken cancellationToken)
    {
        return await _context.Forecast.OrderByDescending(x => x.Id)
                                         .AsNoTracking()
                                         .FirstOrDefaultAsync(cancellationToken)
                                         .ConfigureAwait(false);
    }
    #endregion

    #region Dispose
    public void Dispose()
    {
        _context.Dispose();
    }
    #endregion
}
