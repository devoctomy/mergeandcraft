using Avalonia;
using Avalonia.Media;
using Avalonia.Media.Immutable;
using Avalonia.Rendering.SceneGraph;
using MergeAndCraft.App.Controls;
using System;

namespace MergeAndCraft.App.Drawing
{
    public class WorkspaceGridDrawOperation : ICustomDrawOperation
    {
        public MergeWorkspaceGrid Parent { get; }
        public Rect Bounds { get; }

        public WorkspaceGridDrawOperation(
            MergeWorkspaceGrid parent,
            Rect bounds)
        {
            Parent = parent;
            Bounds = bounds;
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
            var brush = new ImmutableSolidColorBrush(Colors.LightGray);
            var pen = new ImmutablePen(new ImmutableSolidColorBrush(Colors.LightGray), 1);
            var innerRect = new Rect(
                Parent.Model.LeftMargin,
                Parent.Model.TopMargin,
                Bounds.Width - (Parent.Model.LeftMargin + Parent.Model.RightMargin),
                Bounds.Height - (Parent.Model.TopMargin + Parent.Model.BottomMargin));

            var totalSpacingWidth = (Parent.Model.Width - 1) * Parent.Model.HorizontalSpacing;
            var totalSpacingHeight = (Parent.Model.Height - 1) * Parent.Model.VerticalSpacing;
            var maxCellWidth = (innerRect.Width - totalSpacingWidth) / Parent.Model.Width;
            var maxCellHeight = (innerRect.Height - totalSpacingHeight) / Parent.Model.Height;
            var cellSize = Math.Min(maxCellWidth, maxCellHeight); // Ensure cells are square
            var totalGridWidth = (cellSize * Parent.Model.Width) + totalSpacingWidth;
            var totalGridHeight = (cellSize * Parent.Model.Height) + totalSpacingHeight;
            var offsetX = (innerRect.Width - totalGridWidth) / 2 + innerRect.Left;
            var offsetY = (innerRect.Height - totalGridHeight) / 2 + innerRect.Top;

            for (var x = 0; x < Parent.Model.Width; x++)
            {
                for (var y = 0; y < Parent.Model.Height; y++)
                {
                    var xCoord = offsetX + (x * (cellSize + Parent.Model.HorizontalSpacing));
                    var yCoord = offsetY + (y * (cellSize + Parent.Model.VerticalSpacing));
                    context.DrawRectangle(brush, pen, new Rect(xCoord, yCoord, cellSize, cellSize), Parent.Model.RadiusX, Parent.Model.RadiusY);
                }
            }
        }
    }
}
