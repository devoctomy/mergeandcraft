using Avalonia;
using Avalonia.Media;
using Avalonia.Media.Immutable;
using Avalonia.Rendering.SceneGraph;
using MergeAndCraft.App.Controls;
using MergeAndCraft.App.Services;
using System;

namespace MergeAndCraft.App.Drawing;

public class WorkspaceGridDrawOperation : ICustomDrawOperation
{
    public MergeWorkspaceGrid Parent { get; }
    public Rect Bounds { get; }

    private IGridLayoutService _gridLayoutService;

    public WorkspaceGridDrawOperation(
        MergeWorkspaceGrid parent,
        Rect bounds)
    {
        Parent = parent;
        Bounds = bounds;
        _gridLayoutService = (IGridLayoutService)App.ServiceProvider!.GetService(typeof(IGridLayoutService))!;
    }

    public void Dispose()
    {
        GC.SuppressFinalize(this);
    }

    public bool Equals(ICustomDrawOperation? other)
    {
        // implement equality check
        return false;
    }

    public bool HitTest(Point p) => Bounds.Contains(p);

    public void Render(ImmediateDrawingContext context)
    {
        var drawingOptions = Parent.Model.WorkspaceGridDrawingOptions;
        var grid = _gridLayoutService.Layout(drawingOptions, Bounds);

        var brush = new ImmutableSolidColorBrush(Colors.LightGray);
        var pen = new ImmutablePen(new ImmutableSolidColorBrush(Colors.LightGray), 1);
        for(var x = 0; x < drawingOptions.Width; x++)
        {
            for (var y = 0; y < drawingOptions.Height; y++)
            {
                context.DrawRectangle(brush, pen, grid[x, y]);
            }
        }
    }
}
