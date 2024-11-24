using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using MergeAndCraft.App.ViewModels;
using MergeAndCraft.App.Views;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace MergeAndCraft.App;

public partial class App : Application
{
    public static IServiceProvider? ServiceProvider { get; private set; }

    public override void Initialize()
    {
        AvaloniaXamlLoader.Load(this);
    }

    public override void OnFrameworkInitializationCompleted()
    {
        if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
        {
            var serviceCollection = new ServiceCollection();
            ConfigureServices(serviceCollection);
            ServiceProvider = serviceCollection.BuildServiceProvider();

            var mainWindow = ServiceProvider.GetRequiredService<MainWindow>();
            mainWindow.DataContext = ServiceProvider.GetRequiredService<MainView>();
            desktop.MainWindow = mainWindow;
        }
        else if (ApplicationLifetime is ISingleViewApplicationLifetime singleViewPlatform)
        {
            singleViewPlatform.MainView = ServiceProvider!.GetRequiredService<MainView>();
        }

        base.OnFrameworkInitializationCompleted();
    }

    private void ConfigureServices(IServiceCollection services)
    {
        // ViewModels
        services.AddTransient<Func<int, int, MergeWorkspaceGridViewModel>>(sp => (width, height) =>
        {
            return new MergeWorkspaceGridViewModel(width, height, 8, 8, 8, 8, 8, 8, 4, 4);
        });

        services.AddTransient<MergeWorkspaceGridViewModel>();
        services.AddTransient<MainViewModel>();

        // Views
        services.AddTransient<MainWindow>();
        services.AddTransient<MainView>();
    }
}
