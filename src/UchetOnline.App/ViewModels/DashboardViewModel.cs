using CommunityToolkit.Mvvm.ComponentModel;

namespace UchetOnline.App.ViewModels;

/// <summary>
///     Дашборд.
/// </summary>
public partial class DashboardViewModel : BaseModuleViewModel
{
    public DashboardViewModel()
    {
        Title = "Дашборд";
        Description = "Добро пожаловать в Учет Онлайн";
    }
}
