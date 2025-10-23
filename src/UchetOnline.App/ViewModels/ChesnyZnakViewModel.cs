using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using UchetOnline.Infrastructure.Services;

namespace UchetOnline.App.ViewModels;

/// <summary>
///     Интеграция с Честным Знаком.
/// </summary>
public partial class ChesnyZnakViewModel : BaseModuleViewModel
{
    private readonly ChesnyZnakService _service;

    public ChesnyZnakViewModel(ChesnyZnakService service)
    {
        _service = service;
        Title = "Честный Знак";
        Description = "Заготовка интеграции с системой маркировки";
    }

    [ObservableProperty]
    private string _gtin = string.Empty;

    [ObservableProperty]
    private string _response = string.Empty;

    [RelayCommand]
    private async Task SendRequestAsync()
    {
        if (string.IsNullOrWhiteSpace(Gtin))
        {
            Response = "Укажите GTIN";
            return;
        }

        Response = await _service.RequestProductLabelAsync(Gtin);
    }
}
