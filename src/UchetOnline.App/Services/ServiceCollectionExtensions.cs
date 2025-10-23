using System;
using System.Linq;
using System.Reflection;
using Microsoft.Extensions.DependencyInjection;

namespace UchetOnline.App.Services;

/// <summary>
///     DI helpers for ViewModels.
/// </summary>
public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddViewModels(this IServiceCollection services)
    {
        var assembly = Assembly.GetExecutingAssembly();
        var viewModelTypes = assembly.GetTypes()
            .Where(t => t.Namespace != null && t.Namespace.Contains("ViewModels", StringComparison.Ordinal)
                        && t.IsClass && !t.IsAbstract && t.Name.EndsWith("ViewModel", StringComparison.Ordinal));

        foreach (var viewModelType in viewModelTypes)
        {
            services.AddTransient(viewModelType);
        }

        return services;
    }
}
