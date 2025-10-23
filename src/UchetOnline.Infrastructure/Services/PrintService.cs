using System.Threading.Tasks;

namespace UchetOnline.Infrastructure.Services;

/// <summary>
///     Сервис предварительного просмотра и печати документов.
/// </summary>
public class PrintService
{
    /// <summary>
    ///     Возвращает HTML-представление документа (заглушка).
    /// </summary>
    public Task<string> RenderPreviewAsync(string documentName)
    {
        var html = $"<html><body><h1>{documentName}</h1><p>Предварительный просмотр недоступен в демонстрационной версии.</p></body></html>";
        return Task.FromResult(html);
    }
}
