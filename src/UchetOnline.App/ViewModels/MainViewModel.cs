using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using UchetOnline.App.Services;

namespace UchetOnline.App.ViewModels;

/// <summary>
///     Главная модель представления системы.
/// </summary>
public partial class MainViewModel : ObservableObject
{
    private readonly NavigationService _navigationService;

    public MainViewModel(NavigationService navigationService)
    {
        _navigationService = navigationService;
        Modules = new ObservableCollection<ModuleMenuItem>
        {
            new("dashboard", "Дашборд"),
            new("inventory", "Склад"),
            new("accounting", "Бухгалтерия"),
            new("sales", "Продажи"),
            new("purchasing", "Закупки"),
            new("hr", "Кадры"),
            new("payroll", "Зарплата"),
            new("production", "Производство"),
            new("crm", "CRM"),
            new("catalogs", "Справочники"),
            new("constants", "НСИ и константы"),
            new("exchange", "Планы обмена"),
            new("reports", "Отчёты"),
            new("chesnyznak", "Честный Знак")
        };

        SelectedModule = Modules[0];
        CurrentModule = _navigationService.Resolve(SelectedModule.Code);
    }

    public ObservableCollection<ModuleMenuItem> Modules { get; }

    [ObservableProperty]
    private ModuleMenuItem _selectedModule;

    [ObservableProperty]
    private BaseModuleViewModel _currentModule;

    [RelayCommand]
    private void ChangeModule(ModuleMenuItem? module)
    {
        if (module is null)
        {
            return;
        }

        CurrentModule = _navigationService.Resolve(module.Code);
        SelectedModule = module;
    }
}

/// <summary>
///     Элемент меню модулей.
/// </summary>
public record ModuleMenuItem(string Code, string Title);
