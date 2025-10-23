using CommunityToolkit.Mvvm.ComponentModel;

namespace UchetOnline.App.ViewModels;

/// <summary>
///     Базовая модель представления для модулей.
/// </summary>
public abstract partial class BaseModuleViewModel : ObservableObject
{
    [ObservableProperty]
    private string _title = string.Empty;

    [ObservableProperty]
    private string _description = string.Empty;
}
