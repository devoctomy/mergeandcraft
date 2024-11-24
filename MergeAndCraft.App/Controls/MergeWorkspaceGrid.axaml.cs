using Avalonia;
using Avalonia.Controls;
using Avalonia.Media;
using MergeAndCraft.App.Drawing;
using MergeAndCraft.App.ViewModels;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace MergeAndCraft.App.Controls;

public partial class MergeWorkspaceGrid : Control
{
    private MergeWorkspaceGridViewModel? _viewModel;

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
        Model = viewModelFactory(10, 10);
    }

    public override void Render(DrawingContext context)
    {
        base.Render(context);
        var drawOperation = new WorkspaceGridDrawOperation(this, new Rect(0, 0, Bounds.Width, Bounds.Height));
        context.Custom(drawOperation);
    }
}