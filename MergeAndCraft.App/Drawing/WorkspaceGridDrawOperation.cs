using Avalonia;
using Avalonia.Controls;
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

    private Rect[,] _grid;

    public WorkspaceGridDrawOperation(
        MergeWorkspaceGrid parent,
        Rect[,] grid,
        Rect bounds)
    {
        Parent = parent;
        Bounds = bounds;
        _grid = grid;
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
        var width = _grid.GetLength(0);
        var height = _grid.GetLength(1);
        var brush = new ImmutableSolidColorBrush(Colors.LightGray);
        var pen = new ImmutablePen(new ImmutableSolidColorBrush(Colors.LightGray), 1);
        for(var x = 0; x < width; x++)
        {
            for (var y = 0; y < height; y++)
            {
                context.DrawRectangle(
                    brush,
                    pen,
                    _grid[x, y],
                    Parent.Model.WorkspaceGridDrawingOptions.RadiusX,
                    Parent.Model.WorkspaceGridDrawingOptions.RadiusY);
            }
        }
    }
}
