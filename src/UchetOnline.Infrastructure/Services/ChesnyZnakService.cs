using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace UchetOnline.Infrastructure.Services;

/// <summary>
///     Заглушка интеграции с системой "Честный Знак".
/// </summary>
public class ChesnyZnakService
{
    private readonly ILogger<ChesnyZnakService> _logger;

    public ChesnyZnakService(ILogger<ChesnyZnakService> logger)
    {
        _logger = logger;
    }

    public Task<string> RequestProductLabelAsync(string gtin)
    {
        _logger.LogInformation("Запрошена маркировка для товара {Gtin}", gtin);
        return Task.FromResult("CZ-DEMO-RESPONSE");
    }
}
