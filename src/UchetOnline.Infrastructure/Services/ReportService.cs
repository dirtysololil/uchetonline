using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using UchetOnline.Domain.Entities;
using UchetOnline.Infrastructure.Data;

namespace UchetOnline.Infrastructure.Services;

/// <summary>
///     Сервис построения отчетов (заготовка).
/// </summary>
public class ReportService
{
    private readonly UchetOnlineContext _context;

    public ReportService(UchetOnlineContext context)
    {
        _context = context;
    }

    public Task<List<ReportDefinition>> GetReportsAsync(CancellationToken cancellationToken = default)
    {
        return _context.Reports.ToListAsync(cancellationToken);
    }
}
