using System.Windows;
using System.Windows.Controls;
using UchetOnline.App.ViewModels;

namespace UchetOnline.App.Views;

/// <summary>
///     Главное окно приложения.
/// </summary>
public partial class MainWindow : Window
{
    public MainWindow(MainViewModel viewModel)
    {
        InitializeComponent();
        DataContext = viewModel;
    }

    private void ModuleList_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        if (DataContext is MainViewModel vm && sender is ListBox listBox && listBox.SelectedItem is ModuleMenuItem module)
        {
            vm.ChangeModuleCommand.Execute(module);
        }
    }
}
