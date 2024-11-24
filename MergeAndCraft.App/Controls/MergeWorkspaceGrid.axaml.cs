using Avalonia;
using Avalonia.Controls;
using Avalonia.Media;
using MergeAndCraft.App.Drawing;
using MergeAndCraft.App.Services;
using MergeAndCraft.App.ViewModels;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace MergeAndCraft.App.Controls;

public partial class MergeWorkspaceGrid : Control
{
    private MergeWorkspaceGridViewModel? _viewModel;

    private IGridLayoutService _gridLayoutService;

    public MergeWorkspaceGridViewModel Model
    {
        get => _viewModel!;
        set
        {
            _viewModel = value;
            DataContext = _viewModel;
        }
    }

    public MergeWorkspaceGrid()
    {
        var viewModelFactory = App.ServiceProvider!.GetRequiredService<Func<int, int, MergeWorkspaceGridViewModel>>();
        Model = viewModelFactory(7, 9);
        _gridLayoutService = (IGridLayoutService)App.ServiceProvider!.GetService(typeof(IGridLayoutService))!;
    }

    public override void Render(DrawingContext context)
    {
        var drawingOptions = Model.WorkspaceGridDrawingOptions;
        var grid = _gridLayoutService.Layout(drawingOptions, Bounds);

        base.Render(context);
        var drawOperation = new WorkspaceGridDrawOperation(this, grid, new Rect(0, 0, Bounds.Width, Bounds.Height));
        context.Custom(drawOperation);

        // Testing drawing SVG
        using var svgStream = GetType().Assembly.GetManifestResourceStream("MergeAndCraft.App.Resources.SVG.Blog-white.svg");
        var test = new WorkspaceGridItemDrawOperation(svgStream!, grid[5,5]);
        context.Custom(test);
    }
}