using System;
using System.Windows;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using UchetOnline.App.Services;
using UchetOnline.App.ViewModels;
using UchetOnline.Infrastructure.Data;
using UchetOnline.Infrastructure.Extensions;
using UchetOnline.Infrastructure.Services;

namespace UchetOnline.App;

/// <summary>
///     Application entry point.
/// </summary>
public partial class App : Application
{
    private IHost? _host;

    protected override void OnStartup(StartupEventArgs e)
    {
        base.OnStartup(e);

        _host = Host.CreateDefaultBuilder()
            .ConfigureAppConfiguration(builder =>
            {
                builder.SetBasePath(AppDomain.CurrentDomain.BaseDirectory);
                builder.AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
                builder.AddEnvironmentVariables();
            })
            .ConfigureServices((context, services) =>
            {
                services.AddUchetOnlineDataAccess(context.Configuration);

                services.AddScoped<AuthService>();
                services.AddScoped<InventoryService>();
                services.AddScoped<ReportService>();
                services.AddSingleton<PrintService>();
                services.AddSingleton<ChesnyZnakService>();
                services.AddSingleton<NavigationService>();

                services.AddTransient<LoginViewModel>();
                services.AddTransient<MainViewModel>();

                services.AddTransient<Views.LoginWindow>();
                services.AddTransient<Views.MainWindow>();

                services.AddViewModels();
            })
            .Build();

        _host.Start();

        using (var scope = _host.Services.CreateScope())
        {
            var context = scope.ServiceProvider.GetRequiredService<UchetOnlineContext>();
            context.Database.Migrate();

            var auth = scope.ServiceProvider.GetRequiredService<AuthService>();
            auth.EnsureAdminAsync("admin", "admin123!").GetAwaiter().GetResult();
        }

        var loginWindow = _host.Services.GetRequiredService<Views.LoginWindow>();
        loginWindow.Show();
    }

    protected override async void OnExit(ExitEventArgs e)
    {
        if (_host != null)
        {
            await _host.StopAsync();
            _host.Dispose();
        }

        base.OnExit(e);
    }
}
