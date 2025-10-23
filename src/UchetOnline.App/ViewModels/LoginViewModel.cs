using System;
using System.Threading.Tasks;
using System.Windows;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using UchetOnline.Infrastructure.Services;
using Views = UchetOnline.App.Views;

namespace UchetOnline.App.ViewModels;

/// <summary>
///     Модель представления окна входа.
/// </summary>
public partial class LoginViewModel : ObservableObject
{
    private readonly AuthService _authService;
    private readonly IServiceProvider _serviceProvider;

    public LoginViewModel(AuthService authService, IServiceProvider serviceProvider)
    {
        _authService = authService;
        _serviceProvider = serviceProvider;
        UserName = "admin";
    }

    [ObservableProperty]
    private string _userName = string.Empty;

    [ObservableProperty]
    private string _password = string.Empty;

    [ObservableProperty]
    private string _errorMessage = string.Empty;

    [RelayCommand]
    private async Task LoginAsync()
    {
        try
        {
            var user = await _authService.AuthenticateAsync(UserName, Password);
            if (user == null)
            {
                ErrorMessage = "Неверный логин или пароль";
                return;
            }

            ErrorMessage = string.Empty;
            var mainWindow = (Window)_serviceProvider.GetService(typeof(Views.MainWindow))!;
            mainWindow.Show();

            foreach (Window window in Application.Current.Windows)
            {
                if (window is Views.LoginWindow loginWindow)
                {
                    loginWindow.Close();
                    break;
                }
            }
        }
        catch (Exception ex)
        {
            ErrorMessage = "Ошибка входа. Подробности см. в логах.";
            Console.Error.WriteLine(ex);
        }
    }
}
