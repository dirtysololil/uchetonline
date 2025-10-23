using System;
using System.Collections.Generic;
using Microsoft.Extensions.DependencyInjection;
using UchetOnline.App.ViewModels;

namespace UchetOnline.App.Services;

/// <summary>
///     Простой сервис навигации между модулями.
/// </summary>
public class NavigationService
{
    private readonly IServiceProvider _serviceProvider;
    private readonly Dictionary<string, Type> _viewModelMap = new();

    public NavigationService(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
        RegisterViewModels();
    }

    public BaseModuleViewModel Resolve(string moduleCode)
    {
        if (_viewModelMap.TryGetValue(moduleCode, out var type))
        {
            return (BaseModuleViewModel)_serviceProvider.GetRequiredService(type);
        }

        return _serviceProvider.GetRequiredService<DashboardViewModel>();
    }

    private void RegisterViewModels()
    {
        _viewModelMap["dashboard"] = typeof(DashboardViewModel);
        _viewModelMap["inventory"] = typeof(InventoryViewModel);
        _viewModelMap["accounting"] = typeof(AccountingViewModel);
        _viewModelMap["sales"] = typeof(SalesViewModel);
        _viewModelMap["purchasing"] = typeof(PurchasingViewModel);
        _viewModelMap["hr"] = typeof(HrViewModel);
        _viewModelMap["payroll"] = typeof(PayrollViewModel);
        _viewModelMap["production"] = typeof(ProductionViewModel);
        _viewModelMap["crm"] = typeof(CrmViewModel);
        _viewModelMap["catalogs"] = typeof(CatalogsViewModel);
        _viewModelMap["constants"] = typeof(ConstantsViewModel);
        _viewModelMap["exchange"] = typeof(ExchangePlansViewModel);
        _viewModelMap["reports"] = typeof(ReportsViewModel);
        _viewModelMap["chesnyznak"] = typeof(ChesnyZnakViewModel);
    }
}
