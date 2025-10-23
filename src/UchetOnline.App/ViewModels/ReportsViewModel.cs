using System.Collections.ObjectModel;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.Input;
using UchetOnline.Domain.Entities;
using UchetOnline.Infrastructure.Services;

namespace UchetOnline.App.ViewModels;

/// <summary>
///     Отчеты.
/// </summary>
public partial class ReportsViewModel : BaseModuleViewModel
{
    private readonly ReportService _reportService;

    public ReportsViewModel(ReportService reportService)
    {
        _reportService = reportService;
        Title = "Отчёты";
        Description = "Конструктор и просмотр отчетов";
        Reports = new ObservableCollection<ReportDefinition>();
        RefreshCommand = new AsyncRelayCommand(LoadAsync);
    }

    public ObservableCollection<ReportDefinition> Reports { get; }

    public IAsyncRelayCommand RefreshCommand { get; }

    private async Task LoadAsync()
    {
        var reports = await _reportService.GetReportsAsync();
        Reports.Clear();
        foreach (var report in reports)
        {
            Reports.Add(report);
        }
    }
}
