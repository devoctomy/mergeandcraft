using Avalonia;
using MergeAndCraft.App.ViewModels;

namespace MergeAndCraft.App.Services;

public interface IGridLayoutService
{
    Rect[,] Layout(
        WorkspaceGridDrawingOptions drawingOptions,
        Rect bounds);
}
