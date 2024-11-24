using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using MergeAndCraft.App.Services;
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
        var serviceCollection = new ServiceCollection();
        ConfigureServices(serviceCollection);
        ServiceProvider = serviceCollection.BuildServiceProvider();
        if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
        {
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

    private static void ConfigureServices(IServiceCollection services)
    {
        // Services
        services.AddTransient<IGridLayoutService, GridLayoutService>();

        // ViewModels - Don't know if i need to be able to inject half this shit so will re-evaluate as things progress
        services.AddTransient<Func<int, int, MergeWorkspaceGridViewModel>>(sp => (width, height) =>
        {
            var workspaceGridDrawingOptions = new WorkspaceGridDrawingOptions
            (
                width,
                height,
                8,
                8,
                8,
                8,
                8,
                8,
                4,
                4
            );
            return new MergeWorkspaceGridViewModel(workspaceGridDrawingOptions);
        });

        services.AddTransient<MergeWorkspaceGridViewModel>();
        services.AddTransient<MainViewModel>();
        services.AddTransient<WorkspaceGridDrawingOptions>();

        // Views
        services.AddTransient<MainWindow>();
        services.AddTransient<MainView>();
    }
}
