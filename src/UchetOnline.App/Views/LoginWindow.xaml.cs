using System.Windows;
using System.Windows.Controls;
using UchetOnline.App.ViewModels;

namespace UchetOnline.App.Views;

/// <summary>
///     Окно входа.
/// </summary>
public partial class LoginWindow : Window
{
    public LoginWindow(LoginViewModel viewModel)
    {
        InitializeComponent();
        DataContext = viewModel;
    }

    private void PasswordBox_OnPasswordChanged(object sender, RoutedEventArgs e)
    {
        if (DataContext is LoginViewModel vm && sender is PasswordBox passwordBox)
        {
            vm.Password = passwordBox.Password;
        }
    }
}
