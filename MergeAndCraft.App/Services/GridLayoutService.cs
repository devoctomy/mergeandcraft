using Avalonia;
using MergeAndCraft.App.ViewModels;
using System;

namespace MergeAndCraft.App.Services;

public class GridLayoutService : IGridLayoutService
{
    public Rect[,] Layout(
        WorkspaceGridDrawingOptions drawingOptions,
        Rect bounds)
    {
        var grid = new Rect[drawingOptions.Width, drawingOptions.Height];
        var innerRect = new Rect(
            drawingOptions.LeftMargin,
            drawingOptions.TopMargin,
            bounds.Width - (drawingOptions.LeftMargin + drawingOptions.RightMargin),
            bounds.Height - (drawingOptions.TopMargin + drawingOptions.BottomMargin));

        var totalSpacingWidth = (drawingOptions.Width - 1) * drawingOptions.HorizontalSpacing;
        var totalSpacingHeight = (drawingOptions.Height - 1) * drawingOptions.VerticalSpacing;
        var maxCellWidth = (innerRect.Width - totalSpacingWidth) / drawingOptions.Width;
        var maxCellHeight = (innerRect.Height - totalSpacingHeight) / drawingOptions.Height;
        var cellSize = Math.Min(maxCellWidth, maxCellHeight); // Ensure cells are square
        var totalGridWidth = (cellSize * drawingOptions.Width) + totalSpacingWidth;
        var totalGridHeight = (cellSize * drawingOptions.Height) + totalSpacingHeight;
        var offsetX = (innerRect.Width - totalGridWidth) / 2 + innerRect.Left;
        var offsetY = (innerRect.Height - totalGridHeight) / 2 + innerRect.Top;

        for (var x = 0; x < drawingOptions.Width; x++)
        {
            for (var y = 0; y < drawingOptions.Height; y++)
            {
                var xCoord = offsetX + (x * (cellSize + drawingOptions.HorizontalSpacing));
                var yCoord = offsetY + (y * (cellSize + drawingOptions.VerticalSpacing));
                grid[x, y] = new Rect(xCoord, yCoord, cellSize, cellSize);
            }
        }

        return grid;
    }
}
