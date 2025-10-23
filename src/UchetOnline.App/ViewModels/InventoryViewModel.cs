using System.Collections.ObjectModel;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using UchetOnline.Domain.Entities;
using UchetOnline.Infrastructure.Services;

namespace UchetOnline.App.ViewModels;

/// <summary>
///     Модуль склада.
/// </summary>
public partial class InventoryViewModel : BaseModuleViewModel
{
    private readonly InventoryService _inventoryService;

    public InventoryViewModel(InventoryService inventoryService)
    {
        _inventoryService = inventoryService;
        Title = "Склад";
        Description = "Управление остатками и движением";
        Items = new ObservableCollection<InventoryItem>();
        LoadDataCommand = new AsyncRelayCommand(LoadAsync);
        LoadDataCommand.Execute(null);
    }

    public ObservableCollection<InventoryItem> Items { get; }

    public IAsyncRelayCommand LoadDataCommand { get; }

    private async Task LoadAsync()
    {
        var items = await _inventoryService.GetItemsAsync();
        Items.Clear();
        foreach (var item in items)
        {
            Items.Add(item);
        }
    }
}
