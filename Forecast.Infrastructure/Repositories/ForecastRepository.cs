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

    public Task<ForecastDto> AddForecast(ForecastDto forecastDto, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public async Task<ForecastDto?> GetForecast(CancellationToken cancellationToken)
    {
       return await _context.ForecastDto.OrderByDescending(x => x.Id)
                                        .AsNoTracking()
                                        .FirstOrDefaultAsync(cancellationToken)
                                        .ConfigureAwait(false);
    }
}
