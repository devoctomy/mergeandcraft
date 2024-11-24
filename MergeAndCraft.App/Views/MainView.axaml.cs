using Avalonia.Controls;
using MergeAndCraft.App.ViewModels;
using Microsoft.Extensions.DependencyInjection;

namespace MergeAndCraft.App.Views;

public partial class MainView : UserControl
{
    private MainViewModel? _viewModel;

    public MainView()
    {
        InitializeComponent();
        _viewModel = App.ServiceProvider!.GetService<MainViewModel>();
        DataContext = _viewModel;
    }
}
